using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.Model;
using ADSB.BLL;
using ADSB.Common;

namespace ADSB.UI.UserManage
{
    public partial class UserEdit : BasePage
    {
        private string id;
        private IUsersBLL bll = new UsersBLL();
        private IDictItemsBLL itemBll = new DictItemsBLL();
        private IDepartmentBLL deptBll = new DepartmentBLL();
        private IDepartmentUserBLL duBll = new DepartmentUserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = WebCommon.GetRequest("id");

            if (!IsPostBack)
            {
                InitUI();
                // this.BindDept();
            }
        }

        /// <summary>
        /// 绑定部门下拉列表
        /// </summary>
        private void BindDept()
        {
            IList<Department> lstDept = deptBll.GetList(null);
            WebCommon.BindDropDownList(ddlDept, lstDept, "DeptName", "DeptID");
        }

        private void InitUI()
        {
            CommonService.BindDropDownList(ddlSex, "Sex");
            CommonService.BindDropDownList(ddlSafeQuestion, "SafeQuestion");
            CommonService.BindDropDownList(ddlEducation, "Education");
            CommonService.BindDropDownList(ddlStatus, "UserStatus");

            if (Mode == OperateMode.UPDATE)
            {
                InitModel();
            }
        }

        /// <summary>
        /// 编辑加载数据
        /// </summary>
        public void InitModel()
        {
            Users model = bll.GetModel(id);

            txtUserName.Disabled = true;

            if (model != null)
            {
                txtUserName.Value = model.UserName;
                txtName.Value = model.RealName;
                ddlStatus.SelectedValue = model.Status == null ? string.Empty : model.Status.ToString();
                ddlSex.SelectedValue = model.Sex == null ? string.Empty : model.Sex.ToString();
                ddlEducation.SelectedValue = model.Education == null ? string.Empty : model.Education.ToString();
                txtMobile.Value = model.Mobile;
                txtPhone.Value = model.Tel;
                txtEmail.Value = model.Email;
                txtQQ.Value = model.QQ;
                txtBirth.Value = TypeParse.Object2DateTimeString(model.Birthday,"yyyy-MM-dd");
                txtAddress.Value = model.Address;
                txtCompany.Value = model.Company;
                ddlSafeQuestion.SelectedValue = model.Question;
                txtSafeA.Value = model.Answer;
                txtRemark.Value = model.Remark;

                // ddlDept.SelectedValue = duBll.GetModel(id).DeptID.ToString();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Users user = new Users();

            if (Mode == OperateMode.UPDATE)
            {
                user = bll.GetModel(id);
            }
            else
            {
                user.UserName = txtUserName.Value.Trim();
            }

            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                user.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            }

            user.RealName = txtName.Value.Trim();

            if (!string.IsNullOrEmpty(ddlSex.SelectedValue))
            {
                user.Sex = TypeParse.Object2Int32(ddlSex.SelectedValue, 0);
            }

            if (!string.IsNullOrEmpty(ddlEducation.SelectedValue))
            {
                user.Education = ddlEducation.SelectedValue;
            }

            user.Mobile = txtMobile.Value.Trim();
            user.Tel = txtPhone.Value.Trim();
            user.Email = txtEmail.Value.Trim();
            user.QQ = txtQQ.Value.Trim();

            if (!string.IsNullOrEmpty(txtBirth.Value.Trim()))
            {
                user.Birthday = TypeParse.Object2DateTime(txtBirth.Value.Trim(), DateTime.MinValue);
            }
            
            user.Company = txtCompany.Value.Trim();
            user.Remark = txtRemark.Value.Trim();
            user.Question = ddlSafeQuestion.SelectedValue;
            user.Answer = txtSafeA.Value.Trim();
            user.LastUpdateDate = DateTime.Now;

            // 新增
            if (Mode == OperateMode.ADD)
            {
                user.UserID = Guid.NewGuid().ToString();
                user.CreateDate = DateTime.Now;
                object userID = bll.Add(user);
                // this.SaveDepartmentUser((user as Users).UserID);
                WebCommon.ResetControl(this.form1);
            }
            else if (Mode == OperateMode.UPDATE) // 更新
            {
                bll.Update(user);
                // this.SaveDepartmentUser(id);
            }

            WebCommon.DialogSuccessMsg(this, "保存成功！");
        }

        /// <summary>
        /// 新增、更新用户部门
        /// </summary>
        /// <param name="userId"></param>
        private void SaveDepartmentUser(string userId)
        {   
            //string dept = ddlDept.SelectedValue;
            //DepartmentUser duModel = new DepartmentUser();

            //if (string.IsNullOrEmpty(dept)) 
            //{
            //    return;
            //}

            //duModel.UserID = userId;
            //duModel.UserName = txtUserName.Value.Trim();
            //duModel.DeptID = dept;
            //duModel.DeptName = ddlDept.SelectedItem.Text;

            //if (Mode == OperateMode.ADD)
            //{
            //    duBll.Add(duModel);
            //}
            //else
            //{
            //    duBll.Update(duModel);
            //}
        }
    }
}