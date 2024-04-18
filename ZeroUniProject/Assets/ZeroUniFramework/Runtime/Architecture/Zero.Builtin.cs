/****************************************************
  文件：GameEntry_Builtin.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024-03-21 20:00:26
  功能：
*****************************************************/

using System.Collections.Generic;

namespace ZeroUniFramework.Runtime
{
    public partial class Zero
    {
        /// <summary>
        /// 获取游戏基础系统
        /// </summary>
        public static BaseSystem Base
        {
            get;
            private set;
        }
        
        /// <summary>
        /// 获取日志系统
        /// </summary>
        public static LogSystem Log
        {
            get;
            private set;
        }
        
        private static void InitBuiltinSystems()
        {
            //各系统赋值给静态变量，方便获取
            Base = GetSystem<BaseSystem>();
            Log = GetSystem<LogSystem>();
            
            //通过BaseComponent，依次调用OnInit
            List<ISystem> sysList = new List<ISystem>(Zero._container.Values);
            sysList.Sort((x, y)=>x.Priority<y.Priority?1:-1); //x<y就交换位置
            for (int i = 0; i < sysList.Count; i++)
            {
                sysList[i].OnInit();
            }
        }
    }
}