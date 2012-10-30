/*
版权所有：版权所有(C) 2012
文件名称：DepartmentUserBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：DepartmentUserBLL业务类
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;

using ADSB.Model;
using ADSB.DAL;

namespace ADSB.BLL
{
    /// <summary>
    /// 类 名 称：DepartmentUserBLL
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class DepartmentUserBLL : IDepartmentUserBLL
    {
        IDepartmentUserDAL dal = new DepartmentUserDAL();
        
        #region 自动生成
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>主键值</returns>
        public object Add(DepartmentUser model)
        {
            return dal.Add<DepartmentUser>(model);
        }
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="key">关键字值</param>
        /// <returns>实体</returns>
        public DepartmentUser GetModel(System.Int32 key)
        {
            IList<DepartmentUser> lstData = dal.GetList<DepartmentUser>(m => m.DeptUserID == key);

            if (lstData != null && lstData.Count > 0)
            {
                return lstData[0];
            }

            return null;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">实体</param>
        public void Update(DepartmentUser model)
        {
            dal.Update<DepartmentUser>(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        public void Delete(DepartmentUser model)
        {
            dal.Delete<DepartmentUser>(model);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<DepartmentUser, bool>> condition)
        {
            return dal.IsExists<DepartmentUser>(condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns>数据列表</returns>
        public IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition)
        {
            return dal.GetList<DepartmentUser>(condition);
        }
        
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="rowCount">总记录数</param>        
        /// <returns>数据列表</returns>
        public IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition, int pageIndex, int pageSize, out int rowCount)
        {
            return dal.GetList<DepartmentUser>(condition, pageIndex, pageSize, out rowCount);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="rowCount">总记录数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>数据列表</returns>
        public IList<DepartmentUser> GetList(Expression<Func<DepartmentUser, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return dal.GetList<DepartmentUser>(condition, pageIndex, pageSize, out rowCount, out pageCount);
        }
        #endregion
    }
}