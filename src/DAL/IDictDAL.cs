using System;
using System.Collections.Generic;
using System.Text;

using ADSL.Model;
using System.Linq.Expressions;

namespace ADSL.DAL
{
    public interface IDictDAL : IBaseDAL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
    }
}
