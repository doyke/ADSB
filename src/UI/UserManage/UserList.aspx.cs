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
        IUserBLL userBll = new UserBLL();

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void LoadData()
        {
            string condition = null;
            int curIndex = 1;
            int pageSize = 10;
            int rowCount = 0;
            int pageCount = 0;

            gvList.DataSource = userBll.GetList(condition, curIndex, pageSize, out rowCount, out pageCount);
            gvList.DataBind();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}