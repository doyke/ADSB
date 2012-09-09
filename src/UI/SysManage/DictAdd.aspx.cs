using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;
using ADSB.BLL;
using ADSB.Model;
using NHibernate.Cfg;
using NHibernate;
using ADSB.Common;

namespace ADSB.UI.SysManage
{
    public partial class DictAdd : BasePage
    {
        string operateMode;
        int dictID;
        DictBLL dictBll = new DictBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            operateMode = WebCommon.GetRequest("mode", OperateMode.ADD);
            dictID = TypeParse.Object2Int32(WebCommon.GetRequest("dictid"), 0);

            if (!IsPostBack && operateMode == "update" && dictID != 0)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            Dict dictModel = dictBll.GetModel(dictID);

            if (dictModel == null)
            {
                return;
            }

            txtCode.Value = dictModel.Code;
            txtName.Value = dictModel.DictName;
            txtRemark.Value = dictModel.Remark;

            this.txtCode.Disabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Dict dictModel = new Dict();            
            string code = txtCode.Value.Trim();
            string name = txtName.Value.Trim();
            string remark = txtRemark.Value.Trim();


            if (operateMode == "update")
            {
                dictModel = dictBll.GetModel(dictID);
                dictModel.DictName = name;
                dictModel.Remark = remark;
                dictModel.LastUpdateDate = DateTime.Now;
                dictBll.Update(dictModel);
            }
            else // add
            {
                if (string.IsNullOrEmpty(code))
                {
                    WebCommon.DialogAlertMsg(this, "字典编号不能为空，请重新输入！", string.Format("$('#{0}').focus();", txtCode.ClientID));
                    return;
                }

                if (dictBll.IsExistsCode(code))
                {
                    WebCommon.DialogAlertMsg(this, "字典编号已经存在，请重新输入！", string.Format("$('#{0}').focus();", txtCode.ClientID));
                    return;
                }

                dictModel.Code = code;
                dictModel.CreateDate = DateTime.Now;
                dictModel.DictName = name;
                dictModel.Remark = remark;
                dictModel.LastUpdateDate = DateTime.Now;
                dictBll.Add(dictModel);
                WebCommon.ResetControl(this.form1);
            }

            WebCommon.DialogSuccessMsg(this, "保存成功！");
        }
    }
}