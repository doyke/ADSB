<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="ADSB.UI.UserManage.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend class="set_legend">用户</legend>            
            <ul class="two_column">
                <li class="row">
                    <label class="label">用户名：</label>
                    <p class="value"><input type="text" runat="server" id="txtUserName"/></p>
                </li>
                <li class="row">
                    <label class="label">状态：</label>
                    <p class="value"><asp:DropDownList runat="server" ID="ddlStatus"></asp:DropDownList></p>
                </li>
                <li class="row">
                    <label class="label">姓名：</label>
                    <p class="value"><input type="text" runat="server" id="txtName"/></p>
                </li>
                <li class="row">
                    <label class="label">性别：</label>
                    <p class="value"><asp:DropDownList  runat="server" id="ddlSex"></asp:DropDownList></p>
                </li>
                <li class="row">
                    <label class="label">教育程度：</label>
                    <p class="value">
                        <asp:DropDownList runat="server" ID="ddlEducation">
                            
                        </asp:DropDownList>
                    </p>
                </li>
                <li class="row">
                    <label class="label">手机：</label>
                    <p class="value"><input type="text" runat="server" id="txtMobile"/></p>
                </li>
                <li class="row">
                    <label class="label">电话：</label>
                    <p class="value"><input type="text" runat="server" id="txtPhone"/></p>
                </li>
                <li class="row">
                    <label class="label">E-Mail：</label>
                    <p class="value"><input type="text" runat="server" id="txtEmail"/></p>
                </li>
                <li class="row">
                    <label class="label">QQ：</label>
                    <p class="value"><input type="text" runat="server" id="txtQQ"/></p>
                </li>
                <li class="row">
                    <label class="label">生日：</label>
                    <p class="value"><input type="text" runat="server" id="txtBirth" onclick="WdatePicker()" class="Wdate"/></p>
                </li>
                 <li class="row whole_row">
                    <label class="label">联系地址：</label>
                    <p class="value"><input type="text" runat="server" id="txtAddress" style="width:300px;"/></p>
                </li>
                <li class="row">
                    <label class="label">公司：</label>
                    <p class="value"><input type="text" runat="server" id="txtCompany"/></p>
                </li>
                 <li class="row">
                    <label class="label">备注：</label>
                    <p class="value"><input type="text" runat="server" id="txtRemark"/></p>
                </li>                
                <li class="row">
                    <label class="label">安全问题：</label>
                    <p class="value"><asp:DropDownList  runat="server" id="ddlSafeQuestion"></asp:DropDownList></p>
                </li>
                <li class="row">
                    <label class="label">安全问题答案：</label>
                    <p class="value"><input type="text" runat="server" id="txtSafeA"/></p>
                </li> 
                <li class="row">
                    <label class="label">部门：</label>
                    <p class="value">
                        <asp:DropDownList runat="server" ID="ddlDept">
                            
                        </asp:DropDownList>
                    </p>
                </li> 
                <li class="row whole_row">
                    <label class="label"></label>
                    <p class="value"><input type="submit" runat="server" class="bt_submit jui_button" value="保存" id="Submit1" onserverclick="btnSubmit_Click"/><a href="UserList.aspx" class="jui_button">返回</a></p>
                </li>
            </ul>
        </fieldset>
    </div>
    </form>
    <script type="text/javascript" src="../javascript/my97datepicker/wdatepicker.js"></script>
    <script type="text/javascript">
        $(function () {
        })
    </script>
</body>
</html>
