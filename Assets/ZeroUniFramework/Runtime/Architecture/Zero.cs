/****************************************************
  文件：Architecture.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-21 19:57:38
  功能：
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public partial class Zero : PreSingletonMono<Zero>, IArchitecture
    {
        public static bool IsInitialized
        {
            get;
            private set;
        }

        private void Start()
        {
            Init();
        }

        public static void Init()
        {
            if (!IsInitialized)
            {
                InitBuiltinSystems();
                IsInitialized = true;
            }
        }
        
        private void OnDestroy()
        {
            DestroyGame();
        }

        /// <summary>
        /// 重置游戏
        /// </summary>
        public static void ResetGame()
        {
            DestroyGame();
            Init();
        }
        
        /// <summary>
        /// 销毁游戏
        /// </summary>
        private static void DestroyGame()
        {
            foreach (var key in _container.Keys)
            {
                (_container.Get(key) as ISystem)?.OnDeInit();
            }
            _container.Clear();
            _container = new Container<ISystem>();
            IsInitialized = false;
        }

    }
}