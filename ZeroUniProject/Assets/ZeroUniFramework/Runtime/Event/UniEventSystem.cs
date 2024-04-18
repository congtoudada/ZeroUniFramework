/****************************************************
  文件：UniEventSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:24:05
  功能：
*****************************************************/

using System;
using System.Collections.Generic;

namespace ZeroUniFramework.Runtime
{
    public class UniEventSystem : ZeroAbstractSystem
    {
        private class PostWrapper
        {
            public int PostFrame;
            public int EventID;
            public IEventMessage Message;

            public void OnRelease()
            {
                PostFrame = 0;
                EventID = 0;
                Message = null;
            }
        }
        
        private bool _isInitialize = false;
        // private static GameObject _driver = null;
        private readonly Dictionary<int, LinkedList<Action<IEventMessage>>> _listeners = new Dictionary<int, LinkedList<Action<IEventMessage>>>(1000);
        private readonly List<PostWrapper> _postingList = new List<PostWrapper>(100);
        
        public void OnInit()
        {
            throw new NotImplementedException();
        }

        public void OnDeInit()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        public void AddListener<TEvent>(Action<IEventMessage> listener) where TEvent : IEventMessage
        {
            throw new NotImplementedException();
        }

        public void AddListener(Type eventType, Action<IEventMessage> listener)
        {
            throw new NotImplementedException();
        }

        public void AddListener(int eventId, Action<IEventMessage> listener)
        {
            throw new NotImplementedException();
        }

        public void RemoveListener<TEvent>(Action<IEventMessage> listener) where TEvent : IEventMessage
        {
            throw new NotImplementedException();
        }

        public void RemoveListener(Type eventType, Action<IEventMessage> listener)
        {
            throw new NotImplementedException();
        }

        public void RemoveListener(int eventId, Action<IEventMessage> listener)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IEventMessage message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(int eventId, IEventMessage message)
        {
            throw new NotImplementedException();
        }

        public void PostMessage(IEventMessage message)
        {
            throw new NotImplementedException();
        }

        public void PostMessage(int eventId, IEventMessage message)
        {
            throw new NotImplementedException();
        }
    }
}