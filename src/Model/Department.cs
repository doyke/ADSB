/*
版权所有：版权所有(C) 2012
文件名称：Department.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-11
内容摘要：表[Department]对应的实体类
    此文件为工具自动生成，请不要修改其中的代码，否则在更新时会丢失所做的修改。
    如果需要增加功能，请在此基础上建派生类。
*/

using System;

namespace ADSB.Model
{
    /// <summary>
    /// 类 名 称：Department
    /// 完成日期：2012-09-11
    /// 编码作者：自动生成
    /// 内容摘要：包含实体的信息,映射数据库[Department]表
    /// </summary>
    [Serializable]
    public class Department
    {
        #region 自动生成
        public virtual System.Int32 DeptID { get; set; }
        public virtual System.String DeptName { get; set; }
        public virtual System.String ShotDeptName { get; set; }
        public virtual System.Int32 ParentDept { get; set; }
        public virtual System.String Address { get; set; }
        public virtual System.String Tel { get; set; }
        public virtual System.String Fax { get; set; }
        public virtual System.String Remark { get; set; }
        public virtual System.Boolean? IsEnable { get; set; }
        public virtual System.String CreateBy { get; set; }
        public virtual System.DateTime CreateDate { get; set; }
        public virtual System.String CreatorName { get; set; }
        public virtual System.String LastUpdateBy { get; set; }
        public virtual System.String LastUpdateByName { get; set; }
        public virtual System.DateTime LastUpdateDate { get; set; }
        #endregion
    }
}      
