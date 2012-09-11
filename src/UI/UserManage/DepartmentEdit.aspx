<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="ADSB.UI.UserManage.DepartmentEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend class="set_legend">部门信息</legend>
        <ul>
            <li class="row">
                <label class="label require"><span>*</span>部门名称：</label>
                <p class="value"><input type="text" runat="server" id="txtCode" disabled="true"/></p>
            </li>
            <li class="row">
                <label class="label">简称：</label>
                <p class="value"><input type="text" runat="server" id="txtItemCode"/></p>
            </li>            
            <li class="row">
                <label class="label">地址：</label>
                <p class="value"><input type="text" runat="server" id="txtAddress"/></p>
            </li>  
            <li class="row">
                <label class="label">电话：</label>
                <p class="value"><input type="text" runat="server" id="txtPhone"/></p>
            </li>  
            <li class="row">
                <label class="label">传真：</label>
                <p class="value"><input type="text" runat="server" id="txtFax"/></p>
            </li>  
            <li class="row">
                <label class="label">备注：</label>
                <p class="value"><input type="text" runat="server" id="txtRemark"/></p>
            </li>
            <li class="row">
                <label class="label"></label> 
                <p class="value">
                    <input type="submit" runat="server" class="bt_submit jui_button" value="保存" id="btnSubmit" onserverclick="btnSubmit_Click"/>
                    <a href="DepartmentList.aspx" class="jui_button">返回</a>
                </p>
            </li>
        </ul>
    </fieldset>
    </div>
    </form>
</body>
</html>
