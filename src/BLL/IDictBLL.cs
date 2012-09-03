using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using BruceFramework.Model;

namespace BruceFramework.BLL
{
    public interface IDictBLL : IBaseBLL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
    }
}
