/****************************************************
  文件：BaseLogger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 23:02:30
  功能：
*****************************************************/

namespace ZeroUniFramework.Runtime
{
    public abstract class BaseLogger : ILogger
    {
        public abstract void Debug(object message);
        public abstract void Info(object message);
        public abstract void Warn(object message);
        public abstract void Error(object message);
        public abstract void Fatal(object message);
    }
}