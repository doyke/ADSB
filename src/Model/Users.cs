/*
版权所有：版权所有(C) 2012
文件名称：User.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
内容摘要：表[User]对应的实体类
    此文件为工具自动生成，请不要修改其中的代码，否则在更新时会丢失所做的修改。
    如果需要增加功能，请在此基础上建派生类。
*/

using System;

namespace ADSB.Model
{
    /// <summary>
    /// 类 名 称：User
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含实体的信息,映射数据库[User]表
    /// </summary>
    [Serializable]
    public class Users
    {
        public virtual System.String UserID { get; set; }
        public virtual System.String UserName { get; set; }
        public virtual System.String RealName { get; set; }
        public virtual System.String Password { get; set; }
        public virtual System.Int32 Age { get; set; }
        public virtual System.Int32? Sex { get; set; }
        public virtual System.String Education { get; set; }
        public virtual System.String Tel { get; set; }
        public virtual System.String Email { get; set; }
        public virtual System.String Mobile { get; set; }
        public virtual System.String QQ { get; set; }
        public virtual System.DateTime? Birthday { get; set; }
        public virtual System.Int32? Status { get; set; }
        public virtual System.String Address { get; set; }
        public virtual System.String Company { get; set; }
        public virtual System.String LastLoginIP { get; set; }
        public virtual System.DateTime? LastLoginDate { get; set; }
        public virtual System.String Question { get; set; }
        public virtual System.String Answer { get; set; }
        public virtual System.String Remark { get; set; }
        public virtual System.Boolean IsEnable { get; set; }
        public virtual System.String CreateBy { get; set; }
        public virtual System.DateTime CreateDate { get; set; }
        public virtual System.String CreatorName { get; set; }
        public virtual System.String LastUpdateBy { get; set; }
        public virtual System.String LastUpdateByName { get; set; }
        public virtual System.DateTime LastUpdateDate { get; set; }
    }
}      
