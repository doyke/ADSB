
/*
版权所有：版权所有(C) 2012
文件名称：IDictItemsBLL.cs
系统编号：BF_SYS002
系统名称：BruceFrame框架
组件编号：BF_CN001
组件名称：基本表
设计作者：自动生成
完成日期：2012-08-11
内容摘要：IDictItemsBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using BruceFramework.Model;

namespace BruceFramework.BLL
{
    /// <summary>
    /// 接口名称：IDictItemsBLL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IDictItemsBLL : IBaseBLL
    {
        DictItems GetModel(string itemID);        
    }
}