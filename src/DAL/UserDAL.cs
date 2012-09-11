/*
版权所有：版权所有(C) 2012
文件名称：UserDAL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
内容摘要：UserDAL数据类
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Data;

using NHibernate;

using ADSB.Model;

namespace ADSB.DAL
{
    /// <summary>
    /// 类 名 称：UserDAL
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class UserDAL : BaseDAL, IUserDAL
    {
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="rowCount">总记录数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>数据列表</returns>
        public DataTable GetList(string condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            throw new NotImplementedException();
        }
    }
}