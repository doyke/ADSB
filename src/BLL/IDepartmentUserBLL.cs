/*
版权所有：版权所有(C) 2012
文件名称：IDepartmentUserBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：IDepartmentUserBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IDepartmentUserBLL
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IDepartmentUserBLL
    {
        #region 自动生成
        object Add(DepartmentUser model);
        DepartmentUser GetModel(System.Int32 key);
        void Update(DepartmentUser model);
        void Delete(DepartmentUser model);
        bool IsExists(Expression<Func<DepartmentUser, bool>> condition);
        IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition);
        IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition, int pageIndex, int pageSize, out int rowCount);
        IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion
    }
}    