using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSL.UI.Code;
using ADSL.Common;
using ADSL.BLL;
using ADSL.Model;

namespace ADSL.UI.SysManage
{
    public partial class DictItemsEdit : BasePage
    {
        protected string dictCode;
        string itemID;
        string mode;
        IDictItemsBLL diBll = new DictItemsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            dictCode = WebCommon.GetRequest("dictcode");
            itemID = WebCommon.GetRequest("itemid");
            mode = WebCommon.GetRequest("mode", OperateMode.ADD);

            if (string.IsNullOrEmpty(dictCode))
            {
                return;
            }

            if (!IsPostBack)
            {
                this.LoadData();
            }
        }

        private void LoadData()
        {
            switch (mode)
            {
                case OperateMode.ADD: // 新增
                    {
                        txtCode.Value = dictCode;
                        break;
                    }
                case OperateMode.UPDATE: // 修改
                    {
                        DictItems itemModel = diBll.GetModel(itemID);

                        if (itemModel == null)
                        {
                            WebCommon.DialogAlertMsg(this, "不存在该字典！", "window.history.go(-1);");
                            return;
                        }

                        txtCode.Value = itemModel.DictCode;
                        txtItemCode.Value = itemModel.ItemCode;
                        txtName.Value = itemModel.ItemName;
                        txtItemValue.Value = itemModel.ItemValue;
                        txtRemark.Value = itemModel.Remark;
                        break;
                    }
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            DictItems itemModel = new DictItems();
            string dictCode = txtCode.Value.Trim();
            string itemCode = txtItemCode.Value.Trim();
            string name = txtName.Value.Trim();
            string itemValue = txtItemValue.Value.Trim();
            string remark = txtRemark.Value.Trim();

            // 修改
            if (mode == OperateMode.UPDATE)
            {
                itemModel = diBll.GetModel(dictCode);                
                itemModel.ItemCode = itemCode;
                itemModel.ItemName = name;
                itemModel.ItemValue = itemValue;
                itemModel.Remark = remark;
                itemModel.LastUpdateDate = DateTime.Now;
                diBll.Update(itemModel);
            }
            else // 新增
            {
                if (string.IsNullOrEmpty(itemCode))
                {
                    WebCommon.DialogAlertMsg(this, "项编号不能为空，请重新输入！", string.Format("$('#{0}').focus();", txtItemCode.ClientID));
                    return;
                }

                if (diBll.IsExists<DictItems>(item => item.DictCode == dictCode && item.ItemCode == itemCode))
                {
                    WebCommon.DialogAlertMsg(this, "项编号已经存在，请重新输入！", string.Format("$('#{0}').focus();", txtItemCode.ClientID));
                    return;
                }

                itemModel.DictCode = dictCode;
                itemModel.CreateDate = DateTime.Now;
                itemModel.ItemCode = itemCode;
                itemModel.ItemName = name;
                itemModel.ItemValue = itemValue;
                itemModel.Remark = remark;
                itemModel.LastUpdateDate = DateTime.Now;
                diBll.Add(itemModel);
                WebCommon.ResetControl(this.form1);
            }

            WebCommon.DialogSuccessMsg(this, "保存成功！");
        }
    }
}