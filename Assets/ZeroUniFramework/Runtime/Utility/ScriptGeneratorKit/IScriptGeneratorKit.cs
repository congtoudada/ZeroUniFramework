/****************************************************
  文件：IScriptGeneratorKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 21:14:10
  功能：
*****************************************************/

using System.Collections.Generic;

namespace ZeroUniFramework.Runtime
{
    public interface IScriptGeneratorKit : IUtility
    {
        /// <summary>
        /// 添加字段
        /// </summary>
        /// <param name="access">访问修饰</param>
        /// <param name="typeName">类型</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="annotation">注释</param>
        /// <param name="attributes">特性</param>
        public void AddField(ScriptGeneratorKit.AccessEnum access, string typeName, string fieldName,
            string defaultValue = null, string annotation = null, List<string> attributes = null);

        
        /// <summary>
        /// 添加函数
        /// </summary>
        /// <param name="access">访问修饰</param>
        /// <param name="returnType">返回值类型</param>
        /// <param name="methodName">方法名</param>
        /// <param name="paramsList">参数列表</param>
        /// <param name="body">函数体内容</param>
        /// <param name="annotation">注释</param>
        /// <param name="attributes">特性</param>
        public void AddMethod(ScriptGeneratorKit.AccessEnum access, string returnType, string methodName,
            string paramsList, string body, string annotation = null, List<string> attributes = null);
        
        /// <summary>
        /// 删除所有已缓存内容
        /// </summary>
        public void ClearAll();
        
        /// <summary>
        /// 生成脚本内容
        /// </summary>
        /// <param name="scriptInfo"></param>
        /// <returns></returns>
        public string Generate(ScriptInfo scriptInfo);

        /// <summary>
        /// 生成基本ScriptInfo，不带有命名空间信息
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public ScriptInfo CreateScriptInfo(string filename, string className);
        
        /// <summary>
        /// 生成基本ScriptInfo，带有命名空间信息
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="className"></param>
        /// <param name="namespaceName"></param>
        /// <returns></returns>
        public ScriptInfo CreateScriptInfo(string filename, string className, string namespaceName);
    }
}