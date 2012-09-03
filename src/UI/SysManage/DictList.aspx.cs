using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSL.BLL;
using ADSL.Model;
using ADSL.UI.Code;
using ADSL.Common;

namespace ADSL.UI.SysManage
{
    public partial class DictList : BasePage
    {
        IDictBLL dictBll = new DictBLL();
		
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }
		
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            int rowCount;
            int pageCount;

            IList<Dict> lstData = dictBll.GetList<Dict>(dict => dict.DictID == dict.DictID, 1, 1000000, out rowCount, out pageCount);
            gvList.DataSource = lstData;
            gvList.DataBind();
        }
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            object arg = e.CommandArgument;

            if (e.CommandName == "del")
            {
                dictBll.Delete<Dict>(new Dict { DictID = TypeParse.Object2Int32(arg, 0) });
                WebCommon.DialogSuccessMsg(this, "删除成功！");
            }

            this.BindData();
        }
    }
}