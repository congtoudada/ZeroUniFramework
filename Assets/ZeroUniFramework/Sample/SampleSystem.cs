/****************************************************
  文件：SampleSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024/4/6 12:24:43
  功能：
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeroUniFramework;
using ZeroUniFramework.Runtime;

public class SampleSystem :  ZeroAbstractSystem
{
  public override int Priority => -1;

  public bool enableLog = false;
  
  public override void OnInit()
  {
    base.OnInit();
    
    if (enableLog)
    {
      Log.Debug("Debug");
      Log.Info("Info");
      Log.Warn("Warning");
      // ZLogger.Error("Error");
      // ZLogger.Fatal("Fatal");
    }
  }
}