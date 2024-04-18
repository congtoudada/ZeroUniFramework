/****************************************************
  文件：ScriptInfo.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 21:15:59
  功能：
*****************************************************/

using System;
using System.Globalization;
using System.IO;

namespace ZeroUniFramework.Runtime
{
    /// <summary>
    /// 脚本生成信息
    /// </summary>
    public class ScriptInfo
    {
        //必填字段
        private string filename;
        private string className; //类名（包括继承信息）
        private int innerTemplateTag; //当模板路径为null时内置模板 (0:基础C#脚本 1:带命名空间的C#脚本）
        private string templatePath; //模板路径（和innerTemplateTag二选一填）

        private string author = "聪头";
        private string email = "1322080797@qq.com";
        private string datetime = DateTime.UtcNow.AddHours(8).ToString(CultureInfo.InvariantCulture);
        private string description = "该脚本为ZeroUniFramework自动生成脚本，请勿修改内容！";
        private string namespaceName;
        
        public ScriptInfo(string filename, string className)
        {
            this.Filename = filename;
            this.ClassName = className;
        }

        public string Filename
        {
            get => filename;
            set => filename = value;
        }

        public string ClassName
        {
            get => className;
            set => className = value;
        }

        public string TemplatePath
        {
            get => templatePath;
            set => templatePath = value;
        }

        public int InnerTemplateTag
        {
            get => innerTemplateTag;
            set => innerTemplateTag = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Datetime
        {
            get => datetime;
            set => datetime = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string NamespaceName
        {
            get => namespaceName;
            set => namespaceName = value;
        }
    }
}