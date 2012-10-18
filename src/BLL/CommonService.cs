using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

using ADSB.Common;

namespace ADSB.BLL
{
    public class CommonService
    {
        /// <summary>
        /// 从字典绑定下拉列表
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dictCode"></param>
        public static void BindDropDownList(DropDownList ddl, string dictCode)
        {
            IDictItemsBLL itemBll = new DictItemsBLL();
            WebCommon.BindDropDownList(ddl,
                                       itemBll.GetList(item => item.DictCode == dictCode).OrderBy(item => item.OrderNum), 
                                       "ItemName",
                                       "ItemCode");
        }
    }
}
