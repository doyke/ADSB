using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using NHibernate;

using ADSL.Model;

namespace ADSL.DAL
{
    public class DictDAL : BaseDAL, IDictDAL
    {
        public DictDAL()
        {
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="dictID"></param>
        /// <returns></returns>
        public Dict GetModel(int dictID)
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<Dict>().Where(dict => dict.DictID == dictID).SingleOrDefault();
            }
        }

        public bool IsExistsCode(string code)
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<Dict>().Where(entity => entity.Code == code).RowCount() > 0;
            }
        }
    }
}
