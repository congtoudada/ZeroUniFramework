/****************************************************
  文件：PreSingletonMono.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024/4/3 20:12:00
  功能：
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class PreSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance => _instance;

        //子类记得重写父类，并调用base.Awake()
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
    }
}