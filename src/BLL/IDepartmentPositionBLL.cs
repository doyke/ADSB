﻿/*
版权所有：版权所有(C) 2012
文件名称：IDepartmentPositionBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：IDepartmentPositionBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IDepartmentPositionBLL
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IDepartmentPositionBLL
    {
        #region 自动生成
        object Add(DepartmentPosition model);
        DepartmentPosition GetModel(System.Int32 key);
        void Update(DepartmentPosition model);
        void Delete(DepartmentPosition model);
        bool IsExists(Expression<Func<DepartmentPosition, bool>> condition);
        IList<DepartmentPosition> GetList(Expression<Func<DepartmentPosition, bool>> condition);
        IList<DepartmentPosition> GetList(Expression<Func<DepartmentPosition, bool>> condition, int pageIndex, int pageSize, out int rowCount);
        IList<DepartmentPosition> GetList(Expression<Func<DepartmentPosition, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion
    }
}    