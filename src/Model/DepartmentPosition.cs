﻿/*
版权所有：版权所有(C) 2012
文件名称：DepartmentPosition.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：表[DepartmentPosition]对应的实体类
    此文件为工具自动生成，请不要修改其中的代码，否则在更新时会丢失所做的修改。
    如果需要增加功能，请在此基础上建派生类。
*/

using System;

namespace ADSB.Model
{
    /// <summary>
    /// 类 名 称：DepartmentPosition
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含实体的信息,映射数据库[DepartmentPosition]表
    /// </summary>
    [Serializable]
    public class DepartmentPosition
    {
        #region 自动生成
        public virtual System.Int32 DeptPositionID { get; set; }
        public virtual System.String DeptID { get; set; }
        public virtual System.Int32 PositionID { get; set; }
        public virtual System.String CreateBy { get; set; }
        public virtual System.DateTime CreateDate { get; set; }
        public virtual System.String CreatorName { get; set; }
        #endregion
    }
}      
