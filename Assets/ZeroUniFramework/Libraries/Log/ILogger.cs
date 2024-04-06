/****************************************************
  文件：ILogger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月03日 22:42:34
  功能：
*****************************************************/

namespace ZeroUniFramework
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        None = -1,
        Debug = 0,
        Info,
        Warn,
        Error,
        Fatal
    }
    
    public interface ILogger
    {
        /// <summary>
        /// Lv1: 打印DEBUG
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);
        /// <summary>
        /// Lv2: 打印Info
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);
        /// <summary>
        /// Lv3: 打印Warn
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);
        /// <summary>
        /// Lv4: 打印Error
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);
        /// <summary>
        /// Lv5: 打印Fatal
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);
        /// <summary>
        /// 打印指定日志等级的日志（默认Debug）
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(object message, LogLevel level = LogLevel.Debug);
    }
}