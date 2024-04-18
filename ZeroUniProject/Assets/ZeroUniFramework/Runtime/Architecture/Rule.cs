/****************************************************
  文件：Rule.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-26 23:45:55
  功能：
*****************************************************/

namespace ZeroUniFramework.Runtime
{
    public static class Rule
    {
        //系统之间可以通过Architecture互相访问
        public static T GetSystem<T>(this ISystem system) where T : ISystem
        {
            return Zero.GetSystem<T>();
        }
    }
}