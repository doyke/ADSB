/*
版权所有：版权所有(C) 2012
文件名称：DepartmentPositionUserBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN002
组件名称：权限设计
设计作者：自动生成
完成日期：2012-10-31
内容摘要：DepartmentPositionUserBLL业务类
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
    /// 类 名 称：DepartmentPositionUserBLL
    /// 完成日期：2012-10-31
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class DepartmentPositionUserBLL : IDepartmentPositionUserBLL
    {
        IDepartmentPositionUserDAL dal = new DepartmentPositionUserDAL();
        
        #region 自动生成
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>主键值</returns>
        public object Add(DepartmentPositionUser model)
        {
            return dal.Add<DepartmentPositionUser>(model);
        }
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="key">关键字值</param>
        /// <returns>实体</returns>
        public DepartmentPositionUser GetModel(System.String key)
        {
            IList<DepartmentPositionUser> lstData = dal.GetList<DepartmentPositionUser>(m => m.SeqNo == key);

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
        public void Update(DepartmentPositionUser model)
        {
            dal.Update<DepartmentPositionUser>(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        public void Delete(DepartmentPositionUser model)
        {
            dal.Delete<DepartmentPositionUser>(model);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<DepartmentPositionUser, bool>> condition)
        {
            return dal.IsExists<DepartmentPositionUser>(condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns>数据列表</returns>
        public IList<DepartmentPositionUser> GetList(Expression<Func<DepartmentPositionUser, bool>> condition)
        {
            return dal.GetList<DepartmentPositionUser>(condition);
        }
        
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="rowCount">总记录数</param>        
        /// <returns>数据列表</returns>
        public IList<DepartmentPositionUser> GetList(Expression<Func<DepartmentPositionUser, bool>> condition, int pageIndex, int pageSize, out int rowCount)
        {
            return dal.GetList<DepartmentPositionUser>(condition, pageIndex, pageSize, out rowCount);
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
        public IList<DepartmentPositionUser> GetList(Expression<Func<DepartmentPositionUser, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return dal.GetList<DepartmentPositionUser>(condition, pageIndex, pageSize, out rowCount, out pageCount);
        }
        #endregion
    }
}