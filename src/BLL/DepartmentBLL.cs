/*
版权所有：版权所有(C) 2012
文件名称：DepartmentBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-09-10
内容摘要：DepartmentBLL业务类
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
    /// 类 名 称：DepartmentBLL
    /// 完成日期：2012-09-10
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class DepartmentBLL : IDepartmentBLL
    {
        #region 变量区
        IDepartmentDAL dal = new DepartmentDAL();
        #endregion

        #region 方法区
        #region 自动生成
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>主键值</returns>
        public object Add(Department model)
        {
            return dal.Add<Department>(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">实体</param>
        public void Update(Department model)
        {
            dal.Update<Department>(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        public void Delete(Department model)
        {
            dal.Delete<Department>(model);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<Department, bool>> condition)
        {
            return dal.IsExists<Department>(condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns>数据列表</returns>
        public IList<Department> GetList(Expression<Func<Department, bool>> condition)
        {
            return dal.GetList<Department>(condition);
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
        public IList<Department> GetList(Expression<Func<Department, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return dal.GetList<Department>(condition, pageIndex, pageSize, out rowCount, out pageCount);
        }
        #endregion

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="deptID">部门编号</param>
        /// <returns></returns>
        public Department GetModel(int deptID)
        {
            IList<Department> lstData = dal.GetList<Department>(dept => dept.DeptID == deptID);

            if (lstData != null && lstData.Count > 0)
            {
                return lstData[0];
            }

            return null;
        }
        #endregion
    }
}