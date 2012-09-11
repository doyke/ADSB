using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using ADSB.Common;

namespace ADSB.UI.Code
{
    public class BasePage : Page
    {
        /// <summary>
        /// 当前操作:add,update,delete,show
        /// </summary>
        public string Mode 
        { 
            get 
            {
                return WebCommon.GetRequest("mode", OperateMode.ADD);
            } 
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.Theme = "default";

            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            int i = 0;

            this.AddCommonJs(ResolveUrl("~/javascript/jquery-1.7.2.min.js"), ++i);
            this.AddCommonJs(ResolveUrl("~/javascript/jquery-ui-1.8.22.custom.min.js"), ++i);
            this.AddCommonJs(ResolveUrl("~/javascript/main.js"), ++i);
            this.AddCommonJs(ResolveUrl("~/javascript/Jquery.Common.js"), ++i);
            this.AddCommonCss(ResolveUrl("~/CSS/JqueryUI/jquery.ui.all.css"), -1);

            base.OnLoad(e);
        }

        /// <summary>
        /// 添加通用js路径引用
        /// </summary>
        /// <param name="jsAbsolutePath">js路径</param>
        public void AddCommonJs(string jsAbsolutePath, int order)
        {
            // 如果Header不为空，向Header中添加通用Js
            if (this.Header != null)
            {
                string script = @"<script type=""text/javascript"" src=""{0}""></script>";
                string sbJsReference;
                LiteralControl litJsReference = new LiteralControl();

                sbJsReference = Environment.NewLine;
                sbJsReference += string.Format(script, jsAbsolutePath);
                litJsReference.Text = sbJsReference;
                order = order > 0 ? order - 1 : -1;

                if (order > -1)
                {
                    this.Header.Controls.AddAt(order, litJsReference);
                    return;
                }

                this.Header.Controls.Add(litJsReference);
            }
        }

        /// <summary>
        /// 释放jQuery对$的控制权
        /// </summary>
        private void ReleaseJqueryConflict(int order)
        {
            if (this.Header != null)
            {
                // 释放$的控制权
                string strScript = @"<script type=""text/javascript"">jQuery.noConflict();</script>";
                LiteralControl litJsScript = new LiteralControl();

                litJsScript.Text = Environment.NewLine;
                litJsScript.Text += strScript;
                order = order > 0 ? order - 1 : -1;
                this.Header.Controls.AddAt(order, litJsScript);
            }
        }

        /// <summary>
        /// 添加通用css引用
        /// </summary>
        /// <param name="cssAbsolutePath">css路径</param>
        private void AddCommonCss(string cssAbsolutePath, int order)
        {
            // 如果Header不为空，向Header中添加通用Css
            if (this.Header != null)
            {
                string script = @"<link href=""{0}"" rel=""stylesheet"" type=""text/css"" />";

                string sbCssReference;
                LiteralControl litCssReference = new LiteralControl();

                sbCssReference = Environment.NewLine;
                sbCssReference += string.Format(script, cssAbsolutePath);
                litCssReference.Text = sbCssReference;
                order = order > 0 ? order - 1 : -1;

                if (order > -1)
                {
                    this.Header.Controls.AddAt(order, litCssReference);
                    return;
                }

                this.Header.Controls.Add(litCssReference);
                // this.Header.Controls.AddAt(0, litCssReference);
            }
        }
    }
}