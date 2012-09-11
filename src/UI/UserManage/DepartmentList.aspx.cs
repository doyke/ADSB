using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.BLL;
using ADSB.Model;
using ADSB.Common;

namespace ADSB.UI.UserManage
{
    public partial class DepartmentList : BasePage
    {
        private IDepartmentBLL deptBll = new DepartmentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            int rowCount;
            int pageCount;

            IList<Department> lstData = deptBll.GetList(null, 1, 1000000, out rowCount, out pageCount);
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
                deptBll.Delete(new Department { DeptID = TypeParse.Object2Int32(arg, 0) });
                WebCommon.DialogSuccessMsg(this, "删除成功！");
            }

            this.BindData();
        }
    }
}