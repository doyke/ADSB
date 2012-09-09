using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;
using ADSB.DAL;

namespace ADSB.BLL
{
    public class DictBLL : IDictBLL
    {
        IDictDAL dal = new DictDAL();

        public Dict GetModel(int dictID)
        {
            return dal.GetModel(dictID);
        }

        public bool IsExistsCode(string code)
        {
            return dal.IsExistsCode(code);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>主键值</returns>
        public object Add(Dict model)
        {
            return dal.Add<Dict>(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">实体</param>
        public void Update(Dict model)
        {
            dal.Update<Dict>(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        public void Delete(Dict model)
        {
            dal.Delete<Dict>(model);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<Dict, bool>> condition)
        {
            return dal.IsExists<Dict>(condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="condition">过滤条件</param>
        /// <returns>数据列表</returns>
        public IList<Dict> GetList(Expression<Func<Dict, bool>> condition)
        {
            return dal.GetList<Dict>(condition);
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
        public IList<Dict> GetList(Expression<Func<Dict, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            return dal.GetList<Dict>(condition, pageIndex, pageSize, out rowCount, out pageCount);
        }
    }
}
