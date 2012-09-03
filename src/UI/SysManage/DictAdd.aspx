<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictAdd.aspx.cs" Inherits="BruceFramework.UI.SysManage.DictAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend class="set_legend">字典</legend>
        <ul>
            <li class="row">
                <label class="label require">字典编号：</label>
                <p class="value"><input type="text" runat="server" id="txtCode"/></p>
            </li>
            <li class="row">
                <label class="label">字典名称：</label>
                <p class="value"><input type="text" runat="server" id="txtName"/></p>
            </li>
            <li class="row">
                <label class="label">备注：</label>
                <p class="value"><input type="text" runat="server" id="txtRemark"/></p>
            </li>
            <li class="row">
                <label class="label"></label> 
                <p class="value"><input type="submit" runat="server" class="bt_submit jui_button" value="保存" id="btnSubmit" onserverclick="btnSubmit_Click"/><a href="DictList.aspx" class="jui_button">返回</a></p>
               
            </li>
        </ul>
    </fieldset>
    </div>
    <script type="text/javascript">
       
    </script>
    </form>
</body>
</html>
