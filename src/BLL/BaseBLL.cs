/*
版权所有：版权所有(C) 2012
文件名称：BaseBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN001
组件名称：基本表
设计作者：自动生成
完成日期：2012-08-11
内容摘要：基础业务实现类
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using ADSL.DAL;

namespace ADSL.BLL
{
    /// <summary>
    /// 类 名 称：BaseBLL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：IBaseBLL实现
    /// </summary>    
    public class BaseBLL : IBaseBLL
    {
        IBaseDAL dal = new BaseDAL();

        public object Add<T>(T model) where T : class
        {
            return dal.Add<T>(model);
        }

        public void Update<T>(T model) where T : class
        {
            dal.Update<T>(model);
        }

        public void Delete<T>(T model) where T : class
        {
            dal.Delete<T>(model);
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return dal.GetList<T>(condition);
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> where, int pageIndex, int pageSize, out int rowCount, out int pageCount) where T : class
        {
            return dal.GetList<T>(where,pageIndex, pageSize, out rowCount, out pageCount);
        }

        /// <summary>
        /// 是否已经存在
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="where">判断重复的条件</param>
        public bool IsExists<T>(Expression<Func<T, bool>> existsCondition) where T : class
        {
            return dal.IsExists<T>(existsCondition);
        }
    }
}
