/****************************************************
  文件：ScriptGeneratorKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2024年04月04日 21:11:33
  功能：
*****************************************************/

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace ZeroUniFramework.Runtime
{
  public class ScriptGeneratorKit : IScriptGeneratorKit
  {
    /// <summary>
    /// 访问修饰符枚举
    /// </summary>
    public enum AccessEnum
    {
      Public,
      Protected,
      Private
    }
    
    private List<string> _fields = new List<string>();
    private List<string> _methods = new List<string>();
    private List<string> fields
    {
      get
      {
        if (_fields == null)
          _fields = new List<string>();
        return _fields;
      }
      set => _fields = value;
    }

    private List<string> methos
    {
      get
      {
        if (_methods == null)
          _methods = new List<string>();
        return _methods;
      }
      set => _methods = value;
    }
    private StringBuilder _stringBuilder = new StringBuilder();


    public void AddField(AccessEnum access, string typeName, string fieldName, string defaultValue = null,
      string annotation = null, List<string> attributes = null)
    {
      _stringBuilder.Clear();
      
      //添加特性（如果有）
      TryAddAttributes(_stringBuilder, attributes);
      
      //添加访问修饰
      AddAccessEnum(_stringBuilder, access);
      
      //添加类型和字段名（如果有默认值则赋值默认值）
      _stringBuilder.Append(defaultValue == null
        ? $"{typeName} {fieldName};"
        : $"{typeName} {fieldName} = {defaultValue};");
      
      //添加注释（如果有）
      if (!string.IsNullOrEmpty(annotation))
        _stringBuilder.Append($" //{annotation}");
      
      //加入结果集
      fields.Add(_stringBuilder.ToString());
    }

    public void AddMethod(AccessEnum access, string returnType, string methodName, string paramsList, string body,
      string annotation = null, List<string> attributes = null)
    {
      //TODO:暂不实现
    }

    public void ClearAll()
    {
      fields.Clear();
      methos.Clear();
      fields = null;
      methos = null;
    }

    public string Generate(ScriptInfo scriptInfo)
    {
      if (scriptInfo == null) return "";
      string templateFilePath = scriptInfo.TemplatePath;
      if (string.IsNullOrEmpty(templateFilePath))
      {
        templateFilePath = GetDefaultTemplate(scriptInfo.InnerTemplateTag);
      }
      int fieldTabCount = string.IsNullOrEmpty(scriptInfo.NamespaceName) ? 1 : 2;
      // if (!File.Exists(templateFilePath))
      // {
      //   Debug.LogWarning("创建失败，找不到脚本！请检查: " + Path.GetDirectoryName(templateFilePath));
      //   EditorUtility.RevealInFinder(templateFilePath);
      //   return "";
      // }
      string template = File.ReadAllText(templateFilePath); //文本模板
      _stringBuilder.Clear();
      _stringBuilder.Append(template);
      _stringBuilder.Replace("$FILENAME$", scriptInfo.Filename);
      _stringBuilder.Replace("$AUTHOR$", scriptInfo.Author);
      _stringBuilder.Replace("$EMAIL$", scriptInfo.Email);
      _stringBuilder.Replace("$DATETIME$", scriptInfo.Datetime);
      _stringBuilder.Replace("$DESCRIPTION$", scriptInfo.Description); 
      _stringBuilder.Replace("$NAME_SPACE$", scriptInfo.NamespaceName);
      _stringBuilder.Replace("$CLASS$", scriptInfo.ClassName);
      string content = _stringBuilder.ToString();
      //填充字段
      _stringBuilder.Clear();
      for (int i = 0; i < fields.Count; i++)
      {
        if (i != 0)
        {
          for (int j = 0; j < fieldTabCount; j++)
            _stringBuilder.Append("\t");
        }
        _stringBuilder.Append(fields[i]).AppendLine();
      }

      _stringBuilder.Append("//Field End");
      return content.Replace("//Field End", _stringBuilder.ToString());
    }

    public ScriptInfo CreateScriptInfo(string filename, string className)
    {
      return new ScriptInfo(filename, className);
    }
    
    public ScriptInfo CreateScriptInfo(string filename, string className, string namespaceName)
    {
      var info = new ScriptInfo(filename, className)
      {
        InnerTemplateTag = 1,
        NamespaceName = namespaceName
      };
      return info;
    }

    #region 辅助函数

    private string GetDefaultTemplate(int tag)
    {
      if (tag == 1)
      {
        return Path.Combine(PathKit.Instance.GetZeroFolderAbsolute(),
          "Runtime/Utility/ScriptGeneratorKit/Templates/PlainScriptNameSpaceTemplate.txt");
      }
      else
      {
        return Path.Combine(PathKit.Instance.GetZeroFolderAbsolute(),
          "Runtime/Utility/ScriptGeneratorKit/Templates/PlainScriptTemplate.txt");
      }
    }
    
    private void TryAddAttributes(StringBuilder stringBuilder, List<string> attrs)
    {
      if (attrs == null) return;
      stringBuilder.Append($"[");
      for (int i = 0; i < attrs.Count; i++)
      {
        stringBuilder.Append(attrs[i]);
        if (i != attrs.Count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("] ");
    }

    private void AddAccessEnum(StringBuilder stringBuilder, AccessEnum access)
    {
      switch (access)
      {
        case AccessEnum.Public:
          stringBuilder.Append("public ");
          break;
        case AccessEnum.Protected:
          stringBuilder.Append("protected ");
          break;
        case AccessEnum.Private:
          stringBuilder.Append("private ");
          break;
      }
    }
    #endregion
  }
}

