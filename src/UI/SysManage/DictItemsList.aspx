<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictItemsList.aspx.cs"
    Inherits="ADSB.UI.SysManage.DictItemsList" %>

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
                字典项列表</div>
            <div class="operate">
                <a href="DictItemsEdit.aspx?dictcode=<%= dictCode %>" class="jui_button">新增</a>
                <a href="DictList.aspx" class="jui_button">查看字典</a>
            </div>
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" 
            CssClass="data_list" onrowcommand="gvList_RowCommand">
            <Columns>
                <asp:BoundField DataField="DictCode" HeaderText="字典编号" />
                <asp:BoundField DataField="ItemCode" HeaderText="项编号" />
                <asp:BoundField DataField="ItemName" HeaderText="项名称" />                
                <asp:BoundField DataField="Remark" HeaderText="备注" />
                <asp:BoundField DataField="LastUpdateByName" HeaderText="最后修改人" />
                <asp:BoundField DataField="LastUpdateDate" HeaderText="最后更新时间" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href='DictItemsEdit.aspx?mode=update&dictcode=<%# Eval("DictCode") %>&itemid=<%# Eval("DictItemID") %>'>修改</a>
                        <asp:LinkButton ID="btnDataDelete" runat="server" CssClass="delete" CommandName="del"
                                        CommandArgument='<%# Eval("DictItemID") %>'>删除</asp:LinkButton>
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
