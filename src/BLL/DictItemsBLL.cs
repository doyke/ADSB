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

using ADSL.Model;
using ADSL.DAL;
using ADSL.Common;

namespace ADSL.BLL
{
    /// <summary>
    /// 类 名 称：DictItemsBLL
    /// 完成日期：2012-08-11
    /// 编码作者：自动生成
    /// 内容摘要：包含接口操作的实现
    /// </summary>    
    public class DictItemsBLL : BaseBLL, IDictItemsBLL
    {
        IDictItemsDAL dal = new DictItemsDAL();

        public DictItems GetModel(string itemID)
        {
            IList<DictItems> lstItems = GetList<DictItems>(item => item.DictItemID == TypeParse.Object2Int32(itemID,0));

            if (lstItems != null && lstItems.Count > 0)
            {
                return lstItems[0];
            }

            return null;
        }
    }
}