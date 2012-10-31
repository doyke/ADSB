using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADSB.Common;

namespace ADSB.UI.UserManage
{
    public partial class DeptPosiList : System.Web.UI.Page
    {
        private int deptId;

        protected void Page_Load(object sender, EventArgs e)
        {
            deptId = TypeParse.Object2Int32(WebCommon.GetRequest("dept"), 0);

            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}