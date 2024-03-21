/****************************************************
  文件：GameRootSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-21 20:34:51
  功能：
*****************************************************/

using System;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class GameRootSystem : MonoBehaviour, ISystem
    {
        private void Awake()
        {
            GameEntry.RegisterSystem(this);
        }
    }
}