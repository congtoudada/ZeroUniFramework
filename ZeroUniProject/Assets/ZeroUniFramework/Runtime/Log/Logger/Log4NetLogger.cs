/****************************************************
  文件：Log4NetLogger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 22:54:27
  功能：
*****************************************************/

using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class Log4NetLogger : BaseLogger
    {
        private static bool _isInitialized = false;
        private ILog _logger = log4net.LogManager.GetLogger(typeof(Log4NetLogger));
        
        public Log4NetLogger()
        {
            if (!_isInitialized)
            {
                UnityEngine.Debug.LogError("Log4netLogger没有初始化！");
            }
        }
        
        public static void Init(string configPath, string outputPath)
        {
            // GlobalContext.Properties["ApplicationLogPath"] = Path.Combine(Application.streamingAssetsPath, "ZeroUniFramework/Log/");
            // FileInfo file = new System.IO.FileInfo(Path.Combine(Application.streamingAssetsPath, "ZeroUniFramework/Log/log4net.xml")); //获取log4net配置文件
            if (string.IsNullOrEmpty(configPath) || string.IsNullOrEmpty(outputPath))
            {
                UnityEngine.Debug.LogError("Log4net错误，配置或输出路径为空！");
                return;
            }
            
            GlobalContext.Properties["ApplicationLogPath"] = outputPath;
            FileInfo file = new System.IO.FileInfo(configPath); //获取log4net配置文件
            XmlConfigurator.ConfigureAndWatch(file); //加载log4net配置文件
            Application.quitting += () =>
            {
                LogManager.ShutdownRepository();
                LogManager.Shutdown();
            };
            _isInitialized = true;
        }

        public override void Debug(object message)
        {
            _logger?.Debug(message);
        }

        public override void Info(object message)
        {
            _logger?.Info(message);
        }

        public override void Warn(object message)
        {
            _logger?.Warn(message);
        }

        public override void Error(object message)
        {
            _logger?.Error(message);
        }

        public override void Fatal(object message)
        {
            _logger?.Fatal(message);
        }
        
        
    }
}