/****************************************************
  文件：ListLogger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 22:54:32
  功能：
*****************************************************/

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class LoggerManager : BaseLogger
    {
        public List<ILogger> loggers = new List<ILogger>();

        public override void Debug(object message)
        {
            for (int i = 0; i < loggers.Count; ++i)
            {
                loggers[i].Debug(message);
            }
        }

        public override void Info(object message)
        {
            for (int i = 0; i < loggers.Count; ++i)
            {
                loggers[i].Info(message);
            }
        }

        public override void Warn(object message)
        {
            for (int i = 0; i < loggers.Count; ++i)
            {
                loggers[i].Warn(message);
            }
        }

        public override void Error(object message)
        {
            for (int i = 0; i < loggers.Count; ++i)
            {
                loggers[i].Error(message);
            }
        }

        public override void Fatal(object message)
        {
            for (int i = 0; i < loggers.Count; ++i)
            {
                loggers[i].Fatal(message);
            }
        }
    }
}