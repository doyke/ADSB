<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionList.aspx.cs" Inherits="ADSB.UI.UserManage.PositionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>岗位管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="data_header">
            <div class="title">
                字典列表</div>
            <div class="operate">
                <a href="PositionEdit.aspx" class="jui_button">新增</a>
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="data_list"
            OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:BoundField DataField="PositionName" HeaderText="岗位名称" />               
                <asp:BoundField DataField="Remark" HeaderText="备注" />                
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>                        
                        <a href='PositionEdit.aspx?mode=update&id=<%# Eval("PositionID") %>'>修改</a>
                        <%-- <asp:LinkButton ID="btnDataDelete" runat="server" CssClass="delete" CommandName="del"
                            CommandArgument='<%# Eval("PositionID") %>'>删除</asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <anp:AspNetPager ID="anpPager" runat="server" 
            onpagechanged="anpPager_PageChanged" />
    </div>
    </form>
</body>
</html>
