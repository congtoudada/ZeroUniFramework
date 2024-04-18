/****************************************************
  文件：Architecture_System.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-27 00:03:38
  功能：
*****************************************************/

using System;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public partial class Zero
    {
        private static Container<ISystem> _container = new Container<ISystem>();
        
        /// <summary>
        /// 注册系统
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        public static void RegisterSystem<T>(T instance) where T : ISystem
        {
            _container.Register<T>(instance);
            //运行时注册的系统会直接调用OnInit
            if (IsInitialized)
            {
                instance.OnInit();
            }
        }
        
        /// <summary>
        /// 解绑系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void UnRegisterSystem<T>() where T : ISystem
        {
            _container.UnRegister<T>();
        }
        
        /// <summary>
        /// 是否包含某系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool ContainsSystem<T>() where T : ISystem
        {
            return _container.Contains<T>();
        }
        
        /// <summary>
        /// 根据泛型获取系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetSystem<T>() where T : ISystem
        {
            return _container.Get<T>();
        }
        
        /// <summary>
        /// 根据类型获取系统
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object GetSystem(Type type)
        {
            return _container.Get(type);
        }
    }
}