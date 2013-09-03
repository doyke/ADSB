using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ADSB.UI.Code;

namespace UI
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), DateTime.Now.Ticks.ToString(), "alert('start');", true);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Write(Request.UrlReferrer);
        }
    }
}