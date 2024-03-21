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

namespace Zero
{
    /// <summary>
    /// IOC容器类
    /// </summary>
    public class Container<TV> where TV : class
    {
        private Dictionary<Type, TV> _container = new Dictionary<Type, TV>();

        public void Register<T>(T instance) where T : TV
        {
            var key = typeof(T);

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

        public void Clear() => _container.Clear();
    }
}
