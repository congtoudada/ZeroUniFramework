/****************************************************
  文件：LogSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月03日 22:19:57
  功能：格式化Debug.Log，并监听输出，重定向到其他日志工具（log4net）
*****************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class LogSystem : ZeroAbstractSystem
    {
        public override int Priority => 100;
        public LogConfig config;
        private LoggerManager _loggerManager;
        private UnityLogger _unityLogger;
        private StringBuilder _stringBuilder = new StringBuilder();

        protected new void Awake()
        {
            base.Awake();
            _loggerManager = new LoggerManager();
            _unityLogger = new UnityLogger();

            if (config == null)
            {
                Debug.LogWarning("找不到LogConfig！");
                return;
            }
            
            if (config.enableLog4net)
            {
                IPathKit pk = PathKit.Instance;
                Log4NetLogger.Init(pk.ResolvePath(config.log4netConfigPath), pk.ResolvePath(config.log4netOutput));
                ILogger log4NetLogger = new Log4NetLogger();
                _loggerManager.loggers.Add(log4NetLogger);
            }

            if (_loggerManager.loggers.Count > 0)
            {
                //Application.logMessageReceivedThreaded += LogHandle;
                Application.logMessageReceived += LogHandle;
                Application.quitting += ()=>
                {
                    Application.logMessageReceived += LogHandle;
                    //Application.logMessageReceivedThreaded -= LogHandle;
                };
            }
            Log.Instance.SetLogger(_unityLogger).SetConfig(config);;
            
        }

        private void LogHandle(string condition, string stacktrace, LogType type)
        {
            if (Log.Instance.LogType == LogLevel.None)
            {
                return;
            }
            //Debug.Log($"<color=#00FF00>{stacktrace}</color>");
            //第四行为有效栈顶信息，加上类别和行号信息
            // ..../BaseSystem.cs:26

            // _stringBuilder.Clear();
            string pattern = @">(.*?)<";
            string msg = condition;
            Match match = Regex.Match(condition, pattern);
            if (match.Success)  
            {  
                msg = match.Groups[1].Value;
            }  
            if (config.enableStackTopInfo)
            {
                msg += "\n" + stacktrace.Split('\n')[4];;
            }
            switch (Log.Instance.LogType)
            {
                case LogLevel.Debug:
                    _loggerManager.Debug(msg);
                    break;
                case LogLevel.Info:
                    _loggerManager.Info(msg);
                    break;
                case LogLevel.Warn:
                    _loggerManager.Warn(msg);
                    break;
                case LogLevel.Error:
                    _loggerManager.Error(msg);
                    break;
                case LogLevel.Fatal:
                    _loggerManager.Fatal(msg);
                    break;
            }
        }
    }
}