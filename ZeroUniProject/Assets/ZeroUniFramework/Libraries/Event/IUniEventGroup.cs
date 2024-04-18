/****************************************************
  文件：IUniEventGroup.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:19:06
  功能：
*****************************************************/

namespace ZeroUniFramework
{
    public interface IUniEventGroup
    {
        /// <summary>
        /// 同时在Group和UniEvent添加监听
        /// </summary>
        /// <param name="listener"></param>
        /// <typeparam name="TEvent"></typeparam>
        void AddListener<TEvent>(System.Action<IEventMessage> listener) where TEvent : IEventMessage;
        
        /// <summary>
        /// 同时在Group和UniEvent移除所有监听
        /// </summary>
        void RemoveAllListener();
    }
}