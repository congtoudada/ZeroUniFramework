/****************************************************
  文件：LogData.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024/4/3 22:52:48
  功能：
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    [CreateAssetMenu(menuName=("ZeroFramework/System/LogConfig"), fileName=("LogConfig_Builtin"))]
    public class LogConfig : ZeroConfig
    {
        [Header("日志过滤等级"), FoldoutGroup("日志全局配置", expanded: true)]
        [InfoBox("大于该等级的日志才会被打印：None < Debug < Info < Warn < Error < Fatal")]
        public LogLevel filterLevel = LogLevel.None;

        [Header("选择指定tag打印，为空表示全部打印"), FoldoutGroup("日志全局配置")]
        public List<int> selectTag = new List<int>() { 0 };
        
        // [Header("固定打印前缀"), FoldoutGroup("日志全局配置")]
        // public string prefix = "";
        
        [Header("是否记录栈顶信息"), FoldoutGroup("日志全局配置")]
        public bool enableStackTopInfo = true;

        // [Header("是否启用UnityEngine的Debug"), FoldoutGroup("Unity")]
        // public bool enableUnity = true;

        [Header("是否启用Log4net"), FoldoutGroup("Log4net")]
        [InfoBox("如果启用log4net，需手动复制下述地址，导入log4net.dll，并在Package/manifest.json里面删除com.unity.collab-proxy，不然会有dll冲突")]
        [InfoBox("https://logging.apache.org/log4net/download_log4net.html")]
        public bool enableLog4net = false;
        
        [Header("配置文件路径"), FoldoutGroup("Log4net")]
        [FilePath]
        public string log4netConfigPath = "";

        [Header("输出目录"), FoldoutGroup("Log4net")]
        [FolderPath]
        public string log4netOutput = "";
        
    }
}
