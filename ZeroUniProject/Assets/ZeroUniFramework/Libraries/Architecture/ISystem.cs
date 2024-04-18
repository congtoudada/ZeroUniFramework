/****************************************************
  文件：ISystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-21 20:26:09
  功能：
*****************************************************/

namespace ZeroUniFramework
{
    public interface ISystem
    {
        /// <summary>
        /// 系统初始化时调用
        /// </summary>
        void OnInit();

        /// <summary>
        /// 系统销毁时调用
        /// </summary>
        void OnDeInit();
        
        /// <summary>
        /// 获取初始化优先级，只在游戏启动时有效，优先级越高越靠前初始化
        /// </summary>
        int Priority { get; }
    }
}