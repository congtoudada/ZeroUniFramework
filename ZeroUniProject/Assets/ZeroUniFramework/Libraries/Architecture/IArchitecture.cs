/****************************************************
  文件：CLASS.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:36:48
  功能：
*****************************************************/

using System;

namespace ZeroUniFramework
{
    public interface IArchitecture
    {
        #region 系统相关
        /// <summary>
        /// 注册系统
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        void _RegisterSystem<T>(T instance) where T : ISystem;

        /// <summary>
        /// 解绑系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void _UnRegisterSystem<T>() where T : ISystem;
        
        /// <summary>
        /// 是否包含某系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool _ContainsSystem<T>() where T : ISystem;
        
        /// <summary>
        /// 根据泛型获取系统
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T _GetSystem<T>() where T : ISystem;
        
        /// <summary>
        /// 根据类型获取系统
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object _GetSystem(Type type);
        #endregion
    }
}