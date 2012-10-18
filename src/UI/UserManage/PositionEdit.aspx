<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionEdit.aspx.cs" Inherits="ADSB.UI.UserManage.PositionEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>岗位管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
            <legend class="set_legend">岗位</legend>            
            <ul>
                <li class="row">
                    <label class="label">岗位名称：</label>
                    <p class="value"><input type="text" runat="server" id="txtPositionName"/></p>
                </li>
                <li class="row">
                    <label class="label">备注：</label>
                    <p class="value">
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtRemark"></asp:TextBox></p>
                </li>                
                <li class="row">
                    <label class="label"></label>
                    <p class="value"><input type="submit" runat="server" class="bt_submit jui_button" value="保存" id="Submit1" onserverclick="btnSubmit_Click"/><a href="PositionList.aspx" class="jui_button">返回</a></p>
                </li>      
            </ul>
        </fieldset>
    </div>
    </form>
</body>
</html>
