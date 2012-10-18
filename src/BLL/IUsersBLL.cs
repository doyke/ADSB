/*
版权所有：版权所有(C) 2012
文件名称：IUserBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
内容摘要：IUserBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Data;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IUserBLL
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IUsersBLL
    {
        #region 自动生成
        object Add(Users model);
        Users GetModel(System.String key);
        void Update(Users model);
        void Delete(Users model);
        bool IsExists(Expression<Func<Users, bool>> condition);
        IList<Users> GetList(Expression<Func<Users, bool>> condition);
        IList<Users> GetList(Expression<Func<Users, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="rowCount">总行数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>返回符合条件的记录</returns>
        DataTable GetList(string condition, int pageIndex, int pageSize, out int rowCount);
    }
}    