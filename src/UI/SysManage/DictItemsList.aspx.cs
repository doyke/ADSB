using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BruceFramework.UI.Code;
using BruceFramework.BLL;
using BruceFramework.Common;
using BruceFramework.Model;

namespace BruceFramework.UI.SysManage
{
    public partial class DictItemsList : BasePage
    {
        protected string dictCode;
        IDictItemsBLL diBll = new DictItemsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            dictCode = WebCommon.GetRequest("dictcode");

            if (string.IsNullOrEmpty(dictCode))
            {
                return;
            }

            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            IList<DictItems> lstData = diBll.GetList<DictItems>(entity => entity.DictCode == dictCode);

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
                diBll.Delete<DictItems>(new DictItems { DictItemID = TypeParse.Object2Int32(arg, 0) });
                WebCommon.DialogSuccessMsg(this, "删除成功！");
            }

            this.BindData();
        }
    }
}