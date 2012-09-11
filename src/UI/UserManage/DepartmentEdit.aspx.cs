using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.BLL;
using ADSB.Common;
using ADSB.Model;

namespace ADSB.UI.UserManage
{
    /// <summary>
    /// 类 名 称：DepartmentEdit
    /// 编码作者：shawn
    /// 内容摘要：新增、编辑部门信息
    /// </summary>
    public partial class DepartmentEdit : BasePage
    {
        private IDepartmentBLL deptBll = new DepartmentBLL();
        private int DeptID;

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DeptID = TypeParse.Object2Int32(WebCommon.GetRequest("deptid"), 0);

            if (!IsPostBack)
            {
                this.InitUI();
            }
        }

        /// <summary>
        /// 初始化页面内容
        /// </summary>
        private void InitUI()
        {
            // 编辑时加载数据
            if (Mode == OperateMode.UPDATE)
            {
                Department deptModel = deptBll.GetModel(DeptID);

                if (deptModel == null)
                {
                    WebCommon.DialogAlertMsg(this, "不存在该部门！", "window.history.go(-1);");
                    return;
                }
            }
        }
    }
}