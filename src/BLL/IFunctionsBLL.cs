/*
版权所有：版权所有(C) 2012
文件名称：IFunctionsBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
内容摘要：IFunctionsBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IFunctionsBLL
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IFunctionsBLL
    {
        object Add(Functions model);
        void Update(Functions model);
        void Delete(Functions model);
        bool IsExists(Expression<Func<Functions, bool>> condition);
        IList<Functions> GetList(Expression<Func<Functions, bool>> condition);
        IList<Functions> GetList(Expression<Func<Functions, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
    }
}    