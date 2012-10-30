/*
版权所有：版权所有(C) 2012
文件名称：Authorization.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：表[Authorization]对应的实体类
    此文件为工具自动生成，请不要修改其中的代码，否则在更新时会丢失所做的修改。
    如果需要增加功能，请在此基础上建派生类。
*/

using System;

namespace ADSB.Model
{
    /// <summary>
    /// 类 名 称：Authorization
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含实体的信息,映射数据库[Authorization]表
    /// </summary>
    [Serializable]
    public class Authorization
    {
        #region 自动生成
        public virtual System.String FunctionID { get; set; }
        public virtual System.String FunctionName { get; set; }
        public virtual System.String Url { get; set; }
        public virtual System.Int32 Category { get; set; }
        public virtual System.Int32? AuthorityType { get; set; }
        public virtual System.String Command { get; set; }
        public virtual System.String User { get; set; }
        public virtual System.String Department { get; set; }
        public virtual System.String Position { get; set; }
        public virtual System.String DeptPosition { get; set; }
        public virtual System.String LastUpdateBy { get; set; }
        public virtual System.String LastUpdateByName { get; set; }
        public virtual System.DateTime LastUpdateDate { get; set; }
        #endregion
    }
}      
