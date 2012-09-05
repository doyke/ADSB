using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using ADSL.Model;

namespace ADSL.BLL
{
    public interface IDictBLL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
    }
}
