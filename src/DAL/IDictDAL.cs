using System;
using System.Collections.Generic;
using System.Text;

using BruceFramework.Model;
using System.Linq.Expressions;

namespace BruceFramework.DAL
{
    public interface IDictDAL : IBaseDAL
    {
        Dict GetModel(int dictID);
        bool IsExistsCode(string code);
    }
}
