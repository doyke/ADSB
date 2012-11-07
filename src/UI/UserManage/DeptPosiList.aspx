<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptPosiList.aspx.cs" Inherits="ADSB.UI.UserManage.DeptPosiList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门岗位</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="data_header">
            <div class="title">
                部门岗位列表</div>
            <div class="operate">
                <a class="jui_button" id="addPosition">添加岗位</a>
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="data_list"
            OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PositionName" HeaderText="岗位名称" />
                <asp:BoundField DataField="Remark" HeaderText="备注" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDataDelete" runat="server" 
                            CssClass="delete" 
                            CommandName="del"
                            CommandArgument='<%# Eval("DepartmentPositionId") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#addPosition").click(function () {
                openUrl("PositionList.aspx", "t", 700, 500);
            });
        })
    </script>
</body>
</html>
