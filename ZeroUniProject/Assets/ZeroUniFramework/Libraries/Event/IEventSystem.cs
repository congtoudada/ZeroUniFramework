/****************************************************
  文件：IEventSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:19:41
  功能：
*****************************************************/

namespace ZeroUniFramework
{
    public interface IEventSystem : ISystem
    {
        /// <summary>
        /// 清空所有监听
        /// </summary>
        void ClearAll();

        /// <summary>
        /// 添加监听
        /// </summary>
        void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage;

        /// <summary>
        /// 添加监听
        /// </summary>
        void AddListener(System.Type eventType, System.Action<IEventMessage> listener);

        /// <summary>
        /// 添加监听
        /// </summary>
        void AddListener(int eventId, System.Action<IEventMessage> listener);


        /// <summary>
        /// 移除监听
        /// </summary>
        void RemoveListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage;

        /// <summary>
        /// 移除监听
        /// </summary>
        void RemoveListener(System.Type eventType, System.Action<IEventMessage> listener);

        /// <summary>
        /// 移除监听
        /// </summary>
        void RemoveListener(int eventId, System.Action<IEventMessage> listener);


        /// <summary>
        /// 实时广播事件
        /// </summary>
        void SendMessage(IEventMessage message);

        /// <summary>
        /// 实时广播事件
        /// </summary>
        void SendMessage(int eventId, IEventMessage message);

        /// <summary>
        /// 延迟广播事件
        /// </summary>
        void PostMessage(IEventMessage message);

        /// <summary>
        /// 延迟广播事件
        /// </summary>
        void PostMessage(int eventId, IEventMessage message);
    }
}