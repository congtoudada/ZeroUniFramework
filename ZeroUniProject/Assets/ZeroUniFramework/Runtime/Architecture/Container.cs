/****************************************************
  文件：IOCContainer.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 16:19:34
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZeroUniFramework
{
    /// <summary>
    /// 容器
    /// </summary>
    public class Container<TV> where TV : class
    {
        private Dictionary<Type, TV> _container = new Dictionary<Type, TV>();

        public IEnumerable<Type> Keys => _container.Keys;

        public IEnumerable<TV> Values => _container.Values;

        public void Register<T>(T instance) where T : TV
        {
            var key = instance.GetType();
            if (_container.ContainsKey(key))
            {
                _container[key] = instance;
            }
            else
            {
                _container.Add(key, instance);
            }
        }
        
        public void UnRegister<T>() where T : TV
        {
            var key = typeof(T);
            if (_container.ContainsKey(key))
            {
                _container.Remove(key);
            }
        }

        public bool Contains<T>()  where T : TV
        {
            var key = typeof(T);
            if (_container.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public T Get<T>()  where T : TV
        {
            var key = typeof(T);
            if (_container.TryGetValue(key, out var retInstance))
            {
                return (T) retInstance;
            }
            return default(T);
        }
        
        public object Get(Type key)
        {
            if (_container.TryGetValue(key, out var retInstance))
            {
                return retInstance;
            }
            return null;
        }
        
        public void Clear() => _container.Clear();
    }
}
