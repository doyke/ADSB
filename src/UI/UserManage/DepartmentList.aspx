<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="ADSB.UI.UserManage.DepartmentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="data_header">
            <div class="title">
                部门列表</div>
            <div class="operate">
                <a href="DepartmentEdit.aspx" class="jui_button">新增</a>
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="data_list"
            OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:BoundField DataField="DeptName" HeaderText="部门名称" />
                <asp:BoundField DataField="ShotDeptName" HeaderText="简称" />
                <asp:BoundField DataField="Tel" HeaderText="电话" />
                <asp:BoundField DataField="Fax" HeaderText="传真" />
                <asp:BoundField DataField="Remark" HeaderText="备注" />                
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href='UserList.aspx?deptid=<%# Eval("DeptID") %>'>查看用户</a>
                        <a href='DepartmentEdit.aspx?mode=update&deptid=<%# Eval("DeptID") %>'>修改</a>
                        <asp:LinkButton ID="btnDataDelete" runat="server" CssClass="delete" CommandName="del"
                            CommandArgument='<%# Eval("DeptID") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <anp:AspNetPager id="anpPager" runat="server" 
            onpagechanged="anpPager_PageChanged"></anp:AspNetPager>
    </div>
    </form>
</body>
</html>
