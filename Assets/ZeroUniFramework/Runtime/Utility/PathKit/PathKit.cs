/****************************************************
  文件：PathKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 22:00:48
  功能：
*****************************************************/

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
    public class PathKit : LazySingleton<PathKit>, IPathKit
    {
        private string ZERO_FOLDER_ABSOLUTE;
        private string ZERO_FOLDER_RELATIVE;

        private Dictionary<string, string> _replaceRule;

        private PathKit()
        {
            
        }

        public override void OnSingletonInit()
        {
            base.OnSingletonInit();
            UpdateZeroFolder();
        }

        public string GetZeroFolderAbsolute()
        {
            return ZERO_FOLDER_ABSOLUTE;
        }

        public string GetZeroFolderRelative()
        {
            return ZERO_FOLDER_RELATIVE;
        }

        public string AssetsRelativeToAbsolute(string assetRelativePath)
        {
            if (assetRelativePath.StartsWith("Assets"))
            {
                return Path.Combine(Path.GetDirectoryName(Application.dataPath)!, assetRelativePath)
                    .Replace("\\", "/");
            }
            
            return Path.Combine(Application.dataPath, assetRelativePath)
                .Replace("\\", "/");
        }
        
        /// <summary>
        /// 处理路径，处理string里面的${}
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ResolvePath(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            //替换${}里的内容
            string pattern = "\\$\\{([^}]*)\\}"; // 匹配 ${...} 内的内容  
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string content = match.Groups[1].Value.ToLower(); // 提取 ${...} 内的内容  
                if (_replaceRule != null && _replaceRule.TryGetValue(content, out string replacementValue))
                {
                    input = input.Replace(match.Value, replacementValue); // 替换匹配的字符串  
                }
            }
            return input;
        }
        
        #region 辅助函数
        private void UpdateZeroFolder()
        {
            var folders = Directory.GetDirectories("Assets", "ZeroUniFramework", SearchOption.AllDirectories);
            if (folders.Length == 0)
            {
                Debug.LogError("项目内没有找到ZeroUniFramework!");
                return;
            }
            string zeroFolder = folders[0];
            ZERO_FOLDER_ABSOLUTE = AssetsRelativeToAbsolute(zeroFolder);
            ZERO_FOLDER_RELATIVE = zeroFolder.Replace("\\", "/");
            
            _replaceRule = new Dictionary<string, string>()
            {
                //运行时
                { "Streaming".ToLower(), Application.streamingAssetsPath },
                { "Persistent".ToLower(), Application.persistentDataPath },
                { "StreamingPath".ToLower(), Application.streamingAssetsPath },
                { "PersistentPath".ToLower(), Application.persistentDataPath },
                { "StreamingAssetsPath".ToLower(), Application.streamingAssetsPath },
                { "PersistentDataPath".ToLower(), Application.persistentDataPath },
#if UNITY_EDITOR
                //编辑器
                { "ZeroAbsolutePath".ToLower(), ZERO_FOLDER_ABSOLUTE },
                { "ZeroAbsolute".ToLower(), ZERO_FOLDER_ABSOLUTE },
                { "ZeroRelativePath".ToLower(), ZERO_FOLDER_RELATIVE },
                { "Zero".ToLower(), ZERO_FOLDER_RELATIVE }
#endif
            };
        }
        
        
#if UNITY_EDITOR
        public class AssetMoveListener : UnityEditor.AssetModificationProcessor //必须继承这个
        {
            /// <summary>
            /// 监听资源移动事件
            /// </summary>
            /// <param name="oldPath">旧路径</param>
            /// <param name="newPath">新路径</param>
            /// <returns></returns>
            public static AssetMoveResult OnWillMoveAsset(string oldPath,string newPath)
            {
                if (oldPath.EndsWith("ZeroFramework"))
                {
                    PathKit.Instance.UpdateZeroFolder();
                    Debug.Log("Detect ZeroFramework Move! Location: " + newPath);
                }
                return AssetMoveResult.DidNotMove;
            }
        }
#endif
        #endregion
    }
}