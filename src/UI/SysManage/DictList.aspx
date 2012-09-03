<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictList.aspx.cs" Inherits="BruceFramework.UI.SysManage.DictList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="data_header">
            <div class="title">
                字典列表</div>
            <div class="operate">
                <a href="DictAdd.aspx" class="jui_button">新增</a>
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="data_list"
            OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="编号" />
                <asp:BoundField DataField="DictName" HeaderText="名称" />
                <asp:BoundField DataField="Remark" HeaderText="备注" />
                <asp:BoundField DataField="LastUpdateByName" HeaderText="最后修改人" />
                <asp:BoundField DataField="LastUpdateDate" HeaderText="最后更新时间" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href='DictItemsList.aspx?dictcode=<%# Eval("Code") %>'>查看项</a>
                        <a href='DictAdd.aspx?mode=update&dictid=<%# Eval("DictID") %>'>修改</a>
                        <asp:LinkButton ID="btnDataDelete" runat="server" CssClass="delete" CommandName="del"
                            CommandArgument='<%# Eval("DictID") %>'>删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script type="text/javascript">
       
    </script>
    </form>
</body>
</html>
