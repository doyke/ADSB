/*
版权所有：版权所有(C) 2012
文件名称：IFunctionCategoryBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：IFunctionCategoryBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IFunctionCategoryBLL
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IFunctionCategoryBLL
    {
        #region 自动生成
        object Add(FunctionCategory model);
        FunctionCategory GetModel(System.Int32 key);
        void Update(FunctionCategory model);
        void Delete(FunctionCategory model);
        bool IsExists(Expression<Func<FunctionCategory, bool>> condition);
        IList<FunctionCategory> GetList(Expression<Func<FunctionCategory, bool>> condition);
        IList<FunctionCategory> GetList(Expression<Func<FunctionCategory, bool>> condition, int pageIndex, int pageSize, out int rowCount);
        IList<FunctionCategory> GetList(Expression<Func<FunctionCategory, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion
    }
}    