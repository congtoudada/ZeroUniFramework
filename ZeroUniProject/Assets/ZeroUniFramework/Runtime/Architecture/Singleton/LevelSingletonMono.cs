/****************************************************
  文件：PreSingletonMono.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024/4/3 19:38:09
  功能：关卡单例，每次进入关卡会重新加载，切换关卡被销毁
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class LevelSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance => _instance;

        //子类记得重写父类，并调用base.Awake()
        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}