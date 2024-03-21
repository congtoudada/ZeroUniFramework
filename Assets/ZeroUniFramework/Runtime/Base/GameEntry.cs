/****************************************************
  文件：GameEntry.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-21 19:57:38
  功能：
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Zero;

namespace ZeroUniFramework.Runtime
{
    public partial class GameEntry : MonoBehaviour
    {
        private static Container<ISystem> _container;

        private void Start()
        {
            InitBuiltinSystems();
        }

        public static  void RegisterSystem<T>(T instance) where T : ISystem
        {
            _container.Register(instance);
        }

        public static void UnRegisterSystem<T>() where T : ISystem
        {
            _container.UnRegister<T>();
        }

        public static bool ContainsSystem<T>() where T : ISystem
        {
            return _container.Contains<T>();
        }

        public static T GetSystem<T>() where T : ISystem
        {
            return _container.Get<T>();
        }

        public static void DeInit()
        {
            _container.Clear();
        }
    }
}