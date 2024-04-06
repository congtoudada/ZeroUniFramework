/****************************************************
  文件：ZeroSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月03日 20:17:21
  功能：
*****************************************************/

using System;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public abstract class ZeroAbstractSystem : MonoBehaviour, ISystem
    {
        public virtual int Priority { get; } = 0;
        
        /// <summary>
        /// 将自己添加到Zero，此时还不能访问其他System
        /// 不建议在Awake，Start里访问其他System，如果要访问其他系统，建议在OnInit内实现
        /// </summary>
        protected void Awake()
        {
            Zero.RegisterSystem(this);
        }
        
        /// <summary>
        /// 初始化时：在Start函数内调用，根据优先级依次调用
        /// 运行时：会在注册到系统时立即调用
        /// </summary>
        public virtual void OnInit()
        {
            Debug.Log("[ Zero ] 启动系统: " + gameObject.name + "System - Priority: " + this.Priority);
        }

        public virtual void OnDeInit()
        {
            
        }
    }
}