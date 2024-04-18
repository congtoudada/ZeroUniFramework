/****************************************************
  文件：IPathKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 22:00:40
  功能：
*****************************************************/

namespace ZeroUniFramework.Runtime
{
    public interface IPathKit : IUtility
    {
        /// <summary>
        /// 获取ZeroUniFrameowrk的绝对路径
        /// </summary>
        /// <returns></returns>
        string GetZeroFolderAbsolute();

        /// <summary>
        /// 返回ZeroUniFrameowrk相对于Asstes的路径（含Assets）
        /// </summary>
        /// <returns></returns>
        string GetZeroFolderRelative();
        
        /// <summary>
        /// 将Assets相对路径转换为绝对路径 (Assets/xxx --> E:/yyy/Assets/xxx)
        /// </summary>
        /// <param name="assetRelativePath"></param>
        /// <returns></returns>
        string AssetsRelativeToAbsolute(string assetRelativePath);

        /// <summary>
        /// 处理路径，处理string里面的${}
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ResolvePath(string input);
    }
}