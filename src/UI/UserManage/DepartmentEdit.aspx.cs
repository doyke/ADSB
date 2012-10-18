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

                txtName.Disabled = true;
                txtName.Value = deptModel.DeptName;
                txtShortName.Value = deptModel.ShotDeptName;
                txtAddress.Value = deptModel.Address;
                txtPhone.Value = deptModel.Tel;
                txtFax.Value = deptModel.Fax;
                txtRemark.Value = deptModel.Remark;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSubmit_Click(object sender, EventArgs e) 
        {
            string name = txtName.Value.Trim();
            string shortName = txtShortName.Value.Trim();
            string address = txtAddress.Value.Trim();
            string phone = txtPhone.Value.Trim();
            string fax = txtFax.Value.Trim();
            string remark = txtRemark.Value.Trim();
            Department model = new Department();

            // 更新获取数据
            if (Mode == OperateMode.UPDATE)
            {
                model = deptBll.GetModel(DeptID);
            }

            model.DeptName = name;
            model.ShotDeptName = shortName;
            model.Address = address;
            model.Tel = phone;
            model.Fax = fax;
            model.Remark = remark;
            model.LastUpdateDate = DateTime.Now;

            if (Mode == OperateMode.ADD)
            {
                model.CreateDate = DateTime.Now;
                deptBll.Add(model);
                WebCommon.ResetControl(this.form1);
            }
            else
            {
                deptBll.Update(model);                
            }

            WebCommon.DialogSuccessMsg(this, "保存成功！");
        }
    }
}