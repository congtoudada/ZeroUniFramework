/****************************************************
  文件：Architecture_Impl.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:51:13
  功能：
*****************************************************/

using System;

namespace ZeroUniFramework.Runtime
{
    public partial class Zero
    {
        #region 系统相关
        public void _RegisterSystem<T>(T instance) where T : ISystem
        {
            RegisterSystem(instance);
        }
        
        public void _UnRegisterSystem<T>() where T : ISystem
        {
            UnRegisterSystem<T>();
        }
        
        public bool _ContainsSystem<T>() where T : ISystem
        {
            return ContainsSystem<T>();
        }
        
        public T _GetSystem<T>() where T : ISystem
        {
            return GetSystem<T>();
        }

        public object _GetSystem(Type type)
        {
            return GetSystem(type);
        }
        #endregion
        
        
    }
}