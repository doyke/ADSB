/*
版权所有：版权所有(C) 2012
文件名称：DictItemsBLL.cs
系统编号：BF_SYS002
系统名称：ADSB框架
组件编号：BF_CN001
组件名称：基本表
设计作者：自动生成
完成日期：2012-08-11
内容摘要：DictItemsBLL业务类
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;

using ADSB.Model;
using ADSB.DAL;
using ADSB.Common;

namespace ADSB.BLL
{
    /// <summary>
    /// 类 名 称：DictItemsBLL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class DictItemsBLL : IDictItemsBLL
    {
        IDictItemsDAL dal = new DictItemsDAL();

        public DictItems GetModel(string itemID)
        {
            IList<DictItems> lstItems = dal.GetList<DictItems>(item => item.DictItemID == TypeParse.Object2Int32(itemID,0));

            if (lstItems != null && lstItems.Count > 0)
            {
                return lstItems[0];
            }

            return null;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>主键值</returns>
        public object Add(DictItems model)
        {
            return dal.Add<DictItems>(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">实体</param>
        public void Update(DictItems model)
        {
            dal.Update<DictItems>(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        public void Delete(DictItems model)
        {
            dal.Delete<DictItems>(model);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<DictItems, bool>> condition)
        {
            return dal.IsExists<DictItems>(condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns>数据列表</returns>
        public IList<DictItems> GetList(Expression<Func<DictItems, bool>> condition)
        {
            return dal.GetList<DictItems>(condition);
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
        public IList<DictItems> GetList(Expression<Func<DictItems, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return dal.GetList<DictItems>(condition, pageIndex, pageSize, out rowCount, out pageCount);
        }
    }
}