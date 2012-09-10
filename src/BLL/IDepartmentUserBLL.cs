/*
版权所有：版权所有(C) 2012
文件名称：IDepartmentUserBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
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
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IDepartmentUserBLL
    {
        object Add(DepartmentUser model);
        void Update(DepartmentUser model);
        void Delete(DepartmentUser model);
        bool IsExists(Expression<Func<DepartmentUser, bool>> condition);
        IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition);
        IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
    }
}    