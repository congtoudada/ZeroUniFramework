/****************************************************
  文件：UnityLogger.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 22:54:17
  功能：
*****************************************************/

using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class UnityLogger : BaseLogger
    {
        public override void Debug(object message)
        {
            UnityEngine.Debug.Log($"<color=#00FFFF>{message}</color>");
        }

        public override void Info(object message)
        {
            UnityEngine.Debug.Log($"<color=#00FF00>{message}</color>");
        }

        public override void Warn(object message)
        {
            UnityEngine.Debug.LogWarning($"<color=#FFFF00>{message}</color>");
        }

        public override void Error(object message)
        {
            UnityEngine.Debug.LogError($"<color=#FF0000>{message}</color>");
        }

        public override void Fatal(object message)
        {
            UnityEngine.Debug.LogError($"<color=#C32728>{message}</color>");
        }
    }
}