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
    public partial class PositionEdit : BasePage
    {
        PositionBLL bll = new PositionBLL();
        int Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Id = TypeParse.Object2Int32(WebCommon.GetRequest("id"), 0);

            if (!IsPostBack)
            {
                this.InitUI();
            }
        }

        private void InitUI()
        {
            // 更新加载数据
            if (Mode == OperateMode.UPDATE)
            {
                Position model = bll.GetModel(Id);

                if (model == null)
                {
                    return;
                }

                txtPositionName.Value = model.PositionName;
                txtRemark.Text = model.Remark;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtPositionName.Value.Trim();
            string remark = txtRemark.Text.Trim();
            Position model = new Position();

            if (Mode == OperateMode.UPDATE)
            {
                model = bll.GetModel(Id);
            }

            model.PositionName = name;
            model.Remark = remark;
            model.LastUpdateDate = DateTime.Now;

            // 新增
            if (Mode == OperateMode.ADD)
            {
                model.CreateDate = DateTime.Now;
                bll.Add(model);
                WebCommon.ResetControl(this.form1);
            }
            else
            {
                bll.Update(model);
            }

            WebCommon.DialogSuccessMsg(this, "保存成功！");
        }
    }
}