/****************************************************
  文件：Logger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月05日 19:53:34
  功能：
*****************************************************/

using System.Diagnostics;

namespace ZeroUniFramework.Runtime
{
    public class ZLogger : LazySingleton<ZLogger>
    {
        private ILogger _logger = null;
        private LogConfig _config = null;
        public LogLevel LogType
        {
            get;
            private set;
        } = LogLevel.None;

        public bool IsCallLog
        {
            get;
            private set;
        } = false;

        private ZLogger()
        {
        }

        #region 外部接口
        [Conditional("UNITY_EDITOR")]
        public static void Debug(object message, int tag = 0)
        {
            Instance._Debug(message, tag);
        }

        public static void Info(object message, int tag = 0)
        {
            Instance._Info(message, tag);
        }
        
        public static void Warn(object message, int tag = 0)
        {
            Instance._Warn(message, tag);
        }

        public static void Error(object message, int tag = 0)
        {
            Instance._Error(message, tag);
        }

        public static void Fatal(object message, int tag = 0)
        {
            Instance._Fatal(message, tag);
        }

        public static void Log(object message, LogLevel level = LogLevel.Debug, int tag = 0)
        {
            Instance._Log(message, level, tag);
        }
        #endregion
        
        #region 框架内部

        public ZLogger SetLogger(ILogger logger)
        {
            _logger = logger;
            return Instance;
        }

        public ZLogger SetConfig(LogConfig config)
        {
            _config = config;
            return Instance;
        }
        
        [Conditional("UNITY_EDITOR")]
        private void _Debug(object message, int tag = 0)
        {
            if (!Check(LogLevel.Debug, tag))
                return;
            LogType = LogLevel.Debug;
            _logger.Debug(PreProcessMsg(message.ToString()));
            LogType = LogLevel.None;
        }

        private void _Info(object message, int tag = 0)
        {
            if (!Check(LogLevel.Debug, tag))
                return;
            LogType = LogLevel.Info;
            _logger.Info(PreProcessMsg(message.ToString()));
            LogType = LogLevel.None;
        }
        
        private void _Warn(object message, int tag = 0)
        {
            if (!Check(LogLevel.Debug, tag))
                return;
            LogType = LogLevel.Warn;
            _logger.Warn(PreProcessMsg(message.ToString()));
            LogType = LogLevel.None;
        }

        private void _Error(object message, int tag = 0)
        {
            if (!Check(LogLevel.Debug, tag))
                return;
            LogType = LogLevel.Error;
            _logger.Error(PreProcessMsg(message.ToString()));
            LogType = LogLevel.None;
        }

        private void _Fatal(object message, int tag = 0)
        {
            if (!Check(LogLevel.Debug, tag))
                return;
            LogType = LogLevel.Fatal;
            _logger.Fatal(PreProcessMsg(message.ToString()));
            LogType = LogLevel.None;
        }

        private void _Log(object message, LogLevel level = LogLevel.Debug, int tag = 0)
        {
            IsCallLog = true;
            switch(level)
            {
                case LogLevel.Debug:
                    Debug(message, tag);
                    break;
                case LogLevel.Info:
                    Info(message, tag);
                    break;
                case LogLevel.Warn:
                    Warn(message, tag);
                    break;
                case LogLevel.Error:
                    Error(message, tag);
                    break;
                case LogLevel.Fatal:
                    Fatal(message, tag);
                    break;
            }
            IsCallLog = false;
        }

        private bool Check(LogLevel level, int tag)
        {
            if (_logger == null)
                return false;
            if (_config != null)
            {
                if (level <= _config.filterLevel)
                    return false;
                if (_config.selectTag.Count > 0)
                {
                    if (!_config.selectTag.Contains(tag))
                        return false;
                }
            }
            return true;
        }

        private string PreProcessMsg(string msg)
        {
            if (_config != null)
            {
                return $"{_config.prefix}{msg}";
            }

            return msg;
        }
        
        #endregion
    }
}