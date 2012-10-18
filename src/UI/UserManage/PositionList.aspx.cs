using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.Model;
using ADSB.BLL;

namespace ADSB.UI.UserManage
{
    public partial class PositionList : BasePage
    {
        PositionBLL bll = new PositionBLL();

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
            int rowCount, pageCount;
            IList<Position> lstData = bll.GetList(null, anpPager.CurrentPageIndex, anpPager.PageSize, out rowCount, out pageCount);

            anpPager.RecordCount = rowCount;
            gvList.DataSource = lstData;
            gvList.DataBind();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpPager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}