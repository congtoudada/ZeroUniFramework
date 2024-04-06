/****************************************************
  文件：BaseSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:37:31
  功能：
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZeroUniFramework.Runtime
{
    public class BaseSystem : ZeroAbstractSystem
    {
        public override int Priority => 1;

        public override void OnInit()
        {
            base.OnInit();
            
        }
    }
}