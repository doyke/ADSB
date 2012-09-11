/*
版权所有：版权所有(C) 2012
文件名称：IDepartmentBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-11
内容摘要：IDepartmentBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IDepartmentBLL
    /// 完成日期：2012-09-11
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IDepartmentBLL
    {
        #region 自动生成
        object Add(Department model);
        Department GetModel(System.Int32 key);
        void Update(Department model);
        void Delete(Department model);
        bool IsExists(Expression<Func<Department, bool>> condition);
        IList<Department> GetList(Expression<Func<Department, bool>> condition);
        IList<Department> GetList(Expression<Func<Department, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion
    }
}    