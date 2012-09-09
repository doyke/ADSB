/*
版权所有：版权所有(C) 2012
文件名称：IBaseDAL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN001
组件名称：基本表
设计作者：自动生成
完成日期：2012-08-11
内容摘要：IBaseDAL基接口
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ADSB.DAL
{
    /// <summary>
    /// 接口名称：IBaseDAL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IBaseDAL
    {
        object Add<T>(T model) where T : class;
        void Update<T>(T model) where T : class;
        void Delete<T>(T model) where T : class;
        bool IsExists<T>(Expression<Func<T, bool>> where) where T : class;
        IList<T> GetList<T>(Expression<Func<T, bool>> condition) where T : class;
        IList<T> GetList<T>(Expression<Func<T, bool>> where, int pageIndex, int pageSize, out int rowCount, out int pageCount) where T : class;
    }
}