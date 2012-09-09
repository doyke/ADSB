using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    public interface IDictBLL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
        object Add(Dict model);
        void Update(Dict model);
        void Delete(Dict model);
        bool IsExists(Expression<Func<Dict, bool>> condition);
        IList<Dict> GetList(Expression<Func<Dict, bool>> condition);
        IList<Dict> GetList(Expression<Func<Dict, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);

    }
}
