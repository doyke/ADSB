using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.BLL;

namespace ADSB.UI.UserManage
{
    public partial class UserList : BasePage
    {
        IUsersBLL userBll = new UsersBLL();

        /// <summary>
        /// 加载
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
            string condition = null;
            int curIndex = anpPager.CurrentPageIndex;
            int pageSize = anpPager.PageSize;
            int rowCount = 0;            

            gvList.DataSource = userBll.GetList(condition, curIndex, pageSize, out rowCount);
            gvList.DataBind();

            anpPager.RecordCount = rowCount;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void anpPager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}