using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BruceFramework.Common
{
    public class WebCommon
    {
        /// <summary>
        /// 显示弹出消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        public static void ShowMessage(Page page, string message)
        {
            message = message.Replace("\r", "").Replace("'", "'+unescape('%27')+'").Replace("\n", "'+unescape('%0A')+'");
            page.ClientScript.RegisterStartupScript(page.GetType(),
                                                    DateTime.Now.Ticks.ToString(),
                                                    string.Format("alert('{0}');", message),
                                                    true);
        }

        /// <summary>
        /// 执行javascript脚本
        /// </summary>
        /// <param name="page"></param>
        /// <param name="script"></param>
        public static void ExecuteJavaScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), DateTime.Now.Ticks.ToString(), script, true);
        }

        /// <summary>
        /// 执行javascript脚本
        /// </summary>
        /// <param name="ctrl">UpdatePanel控件</param>
        /// <param name="script"></param>
        public static void ExecuteJavaScript(Control ctrl, string script)
        {
            ScriptManager.RegisterStartupScript(ctrl, typeof(UpdatePanel), DateTime.Now.Ticks.ToString(), script, true);
        }

        /// <summary>
        /// 清空指定控件里的控件的值，除控件id为exceptIDs指定的控件
        /// 控件必须可用
        /// </summary>
        /// <param name="ctrl">要清空的控件</param>
        /// <param name="exceptIDs">排除的控件id，以,分隔</param>
        public static void ResetControl(Control ctrl, string exceptIDs)
        {
            foreach (Control tempCtrl in ctrl.Controls)
            {
                if (!string.IsNullOrEmpty(exceptIDs) && Utils.InArray(tempCtrl.ID, exceptIDs))
                {
                    continue;
                }

                if (tempCtrl as TextBox != null && (tempCtrl as TextBox).Enabled == true)
                {
                    (tempCtrl as TextBox).Text = string.Empty;
                }
                else if (tempCtrl as HtmlInputText != null && (tempCtrl as HtmlInputText).Disabled == false)
                {
                    (tempCtrl as HtmlInputText).Value = string.Empty;
                }
                else if (tempCtrl as HtmlTextArea != null && (tempCtrl as HtmlTextArea).Disabled == false)
                {
                    (tempCtrl as HtmlTextArea).Value = string.Empty;
                }
                else
                {
                    DropDownList tempDdl = tempCtrl as DropDownList;

                    if (tempDdl != null && tempDdl.Items.Count > 0 && tempDdl.Enabled == true)
                    {
                        tempDdl.SelectedIndex = 0;
                    }
                }

                ResetControl(tempCtrl, exceptIDs);
            }
        }

        public static void ResetControl(Control[] ctrls, string exceptIDs)
        {
            foreach (Control tempCtrl in ctrls)
            {
                ResetControl(tempCtrl, exceptIDs);
            }
        }

        public static void ResetControl(Control[] ctrls)
        {
            ResetControl(ctrls, null);
        }

        public static void ResetControl(Control ctrl)
        {
            ResetControl(ctrl, null);
        }

        public static string GetRequest(string name)
        {
            return GetRequest(name, null);
        }

        public static string GetRequest(string name, string defaultVal)
        {
            return GetRequest(null, name, defaultVal, false);
        }

        public static string GetRequest(string name, bool decode)
        {
            return GetRequest(null, name, null, decode);
        }

        public static string GetRequest(HttpRequest request, string name, string defaultVal, bool decode)
        {
            if (name == null || name.Trim().Length == 0)
            {
                throw new ArgumentException("name");
            }

            string val;

            if (request == null)
            {
                val = HttpContext.Current.Request.QueryString[name];
            }
            else
            {
                val = request.QueryString[name];
            }

            if (val == null)
            {
                return string.IsNullOrEmpty(defaultVal) ? string.Empty : defaultVal;
            }

            if (decode)
            {
                val = HttpUtility.UrlDecode(val);
            }

            return val.Trim();
        }

        #region Jquery Dialog Message
        /// <summary>
        /// Jquery Dialog 错误消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void DialogSuccessMsg(Page page, string msg)
        {
            DialogMsg(page, 1, msg, null);
        }

        /// <summary>
        /// Jquery Dialog 错误消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="callback"></param>
        public static void DialogAlertMsg(Page page, string msg, string callback)
        {
            DialogMsg(page, 2, msg, callback);
        }

        /// <summary>
        /// Jquery Dialog 提示消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void DialogAlertMsg(Page page, string msg)
        {
            DialogMsg(page, 2, msg, null);
        }

        /// <summary>
        /// Jquery Dialog消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        /// <param name="callback"></param>
        public static void DialogMsg(Page page, int msgType, string msg, string callback)
        {
            string script = msg.Replace("'", "\'");
            string callbackScript = Utils.StrIsNullOrEmpty(callback) ? "null" : callback;

            if (!Utils.StrIsNullOrEmpty(callback) && !callback.EndsWith(";"))
            {
                callbackScript += ";";
            }

            callbackScript = "function(){" + callbackScript + "}";
            script = string.Format("dialogMessage('{0}',{1},{2});", script, callbackScript, msgType);
            ExecuteJavaScript(page, script);
        }
        #endregion
    }
}
