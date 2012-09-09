using System;
using System.Collections.Generic;
using System.Text;

using ADSB.Model;
using System.Linq.Expressions;

namespace ADSB.DAL
{
    public interface IDictDAL : IBaseDAL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
    }
}
