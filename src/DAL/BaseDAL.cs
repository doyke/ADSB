/*
版权所有：版权所有(C) 2012
文件名称：IBaseDAL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN001
组件名称：基本表
设计作者：自动生成
完成日期：2012-08-11
内容摘要：基础数据访问实现
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace ADSB.DAL
{
    /// <summary>
    /// 类 名 称：BaseDAL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：BaseDAL接口
    /// </summary> 
    public class BaseDAL : IBaseDAL
    {
        private static ISessionFactory fac;

        static BaseDAL()
        {
            Configuration cfg = new Configuration().Configure();
            fac = cfg.BuildSessionFactory();
        }

        public BaseDAL()
        {
            
        }

        public ISession OpenSession()
        {
            return fac.OpenSession();
        }

        #region IBasicDAL实现
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<T> GetList<T>(Expression<Func<T, bool>> condition) where T : class
        {
            IList<T> result = null;

            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    if (condition == null)
                    {
                        result = session.QueryOver<T>().List<T>();
                    }
                    else
                    {
                        result = session.QueryOver<T>().Where(condition).List<T>();
                    }

                    tran.Commit();
                }
            }

            return result;
        }

        /// <summary>
        /// 获取分布列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public IList<T> GetList<T>(Expression<Func<T, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount) where T : class
        {
            rowCount = 0;
            pageCount = 1;

            IList<T> result = null;

            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    rowCount = session.QueryOver<T>().Where(condition).RowCount();
                    pageCount = this.GetPageCount(rowCount, pageCount);

                    if (condition == null)
                    {
                        result = session.QueryOver<T>().Skip((pageIndex - 1) * pageSize).List<T>();
                    }
                    else
                    {
                        result = session.QueryOver<T>().Where(condition).Skip((pageIndex - 1) * pageSize).List<T>();
                    }

                    tran.Commit();
                }
            }

            return result;
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="rowCount">行总数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public int GetPageCount(int rowCount, int pageSize)
        {
            if (rowCount >= pageSize && rowCount % pageSize == 0)
            {
                return rowCount / pageSize;
            }
            else
            {
                return rowCount / pageSize + 1;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public object Add<T>(T model) where T : class
        {
            using (ISession session = OpenSession())
            {
                ITransaction tran = session.BeginTransaction();
                object objDictID = session.Save(model);

                tran.Commit();
                return objDictID;
            }      
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">实体</param>
        public void Update<T>(T model) where T : class
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(model);
                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">实体</param>
        public void Delete<T>(T model) where T : class
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(model);
                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 是否已经存在
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="where">判断重复的条件</param>
        public bool IsExists<T>(Expression<Func<T, bool>> existsCondition) where T :class
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<T>().Where(existsCondition).RowCount() > 0;
            }
        }
        #endregion
    }
}
