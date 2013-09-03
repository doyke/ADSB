<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图书管理系统</title>

    <link href="css/index.css" rel="stylesheet" type="text/css" />
    
    <script src="javascript/index.js" type="text/javascript"></script>

    <script type="text/javascript">
        function showNowTime()
        {
            var now = new Time().getLongTime();
            document.getElementById("curTime").innerHTML = now;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btn" runat="server" Text="点击我" OnClick="btn_Click" />
    <!-- 顶部 -->
    <div id="top">
        <div id="sysinfo">
            <img id="logo" alt="logo" src="images/logo.jpg" />
            <asp:Label ID="lblVersion" runat="server">V1.0</asp:Label>
        </div>
        <div id="headerNav">
            <ul>
                <li>
                    <img src="images/tabv.gif" style="vertical-align: middle" alt="" /></li>
                <li><a id="lnkHome">首页</a><span>.</span></li>
                <li><a id="lnkHelp">帮助文档</a><span>.</span></li>
                <li><a id="lnkFeedBack">反馈</a><span>.</span></li>
                <li><a id="lnkVerInfo">版本信息</a><span>.</span></li>
                <!--<li><a>锁屏</a><span>.</span></li>-->
                <li><a id="lnkModifyPwd" title="修改密码">修改密码</a><span>.</span></li><!-- href="#TB_inline?height=170&width=220&inlineId=modifyPwd"-->
                <li><a onclick="reLogin();">退出</a><span>.</span></li>
                <!--<li><a onclick="exit();">退出</a></li>-->
            </ul>
        </div>
        <div id="menu">
            <div id="info">
                用户名：<asp:Label ID="lblUserName" runat="server"></asp:Label>
                <span id="curTime"></span>

                <script type="text/javascript">
                    showNowTime();
                    setInterval(showNowTime, 1000);
                </script>

            </div>
            <div id="mainMenu">
                <%--<asp:Label ID="lblMenuContainer" runat="server"></asp:Label>--%>            
                <span id="lblMenuContainer"><div menuindex="1" class=""><a>流通系统</a></div><div menuindex="2" class=""><a>编目系统</a></div><div menuindex="3" class=""><a>典藏管理</a></div><div menuindex="4" class=""><a>期刊系统</a></div><div menuindex="5" class="curSelected"><a>系统管理</a></div></span>            
            </div>
        </div>
    </div>
    <!-- 下面 -->
    <div id="down">
        <!-- 左边 -->
        <div id="left" state="1">
            <div class="menuSep">
                <img src="images/expand-all.gif" alt="全部展开" title="全部展开" class="expendAll" />
                <img src="images/collapse-all.gif" alt="全部折叠" title="全部折叠" class="collapseAll" />
            </div>
            <!-- 菜单导航 -->
            <%--<asp:Panel ID="pnlMenuItem" runat="server">
            </asp:Panel>--%>
            <div id="pnlMenuItem">
	
            <div id="menuNav1" class="leftMenu" style="display: block; ">
		<a href="#ctl04_SkipLink"><img alt="Skip Navigation Links." src="/WebResource.axd?d=brkW-3LlPaSj-8IvArRJ0FxxgVzi2uClV5Y3FdgHnJHQrppNv2rTqwQ9mwf8f1JKZUVx3FkYMb7nBe1UKWWCBmVj3kY1&amp;t=634604713351482412" width="0" height="0" style="border-width:0px;"></a><div id="ctl04">
			<table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl04n0" href="javascript:TreeView_ToggleNode(ctl04_Data,0,document.getElementById('ctl04n0'),' ',document.getElementById('ctl04n0Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 图书流通" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl04_Data,0,document.getElementById('ctl04n0'),' ',document.getElementById('ctl04n0Nodes'))"><a class="ctl04_0" href="#" id="ctl04t0">图书流通</a></td>
				</tr>
			</tbody></table><div id="ctl04n0Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookBorrow.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t1');" id="ctl04t1">图书流通</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookBorrowQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t2');" id="ctl04t2">当前流通</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookBorrowOverdueQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t3');" id="ctl04t3">逾期未还</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookReserve.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t4');" id="ctl04t4">当前预借</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookTopQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t5');" id="ctl04t5">借阅排行</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/OperationalLogbook.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t6');" id="ctl04t6">操作日志</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="Circulation/BookClassTopQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t7');" id="ctl04t7">分类借阅排行</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl04n8" href="javascript:TreeView_ToggleNode(ctl04_Data,8,document.getElementById('ctl04n8'),' ',document.getElementById('ctl04n8Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 读者管理" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl04_Data,8,document.getElementById('ctl04n8'),' ',document.getElementById('ctl04n8Nodes'))"><a class="ctl04_0" href="#" id="ctl04t8">读者管理</a></td>
				</tr>
			</tbody></table><div id="ctl04n8Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="SystemManage/Reader/ReaderManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t9');" id="ctl04t9">读者管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl04_0" href="SystemManage/Reader/RoleManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl04_Data, this,'ctl04t10');" id="ctl04t10">读者角色</a></td>
					</tr>
				</tbody></table>
			</div>
		</div><a id="ctl04_SkipLink"></a>
	</div><div id="menuNav2" class="leftMenu" style="display: none; ">
		<a href="#ctl05_SkipLink"><img alt="Skip Navigation Links." src="/WebResource.axd?d=brkW-3LlPaSj-8IvArRJ0FxxgVzi2uClV5Y3FdgHnJHQrppNv2rTqwQ9mwf8f1JKZUVx3FkYMb7nBe1UKWWCBmVj3kY1&amp;t=634604713351482412" width="0" height="0" style="border-width:0px;"></a><div id="ctl05">
			<table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl05n0" href="javascript:TreeView_ToggleNode(ctl05_Data,0,document.getElementById('ctl05n0'),' ',document.getElementById('ctl05n0Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 图书编目" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl05_Data,0,document.getElementById('ctl05n0'),' ',document.getElementById('ctl05n0Nodes'))"><a class="ctl05_0" href="#" id="ctl05t0">图书编目</a></td>
				</tr>
			</tbody></table><div id="ctl05n0Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl05_0" href="Directory/Add.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl05_Data, this,'ctl05t1');" id="ctl05t1">图书编目</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl05_0" href="Directory/DirectoryManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl05_Data, this,'ctl05t2');" id="ctl05t2">编目管理</a></td>
					</tr>
				</tbody></table>
			</div>
		</div><a id="ctl05_SkipLink"></a>
	</div><div id="menuNav3" class="leftMenu" style="display: none; ">
		<a href="#ctl06_SkipLink"><img alt="Skip Navigation Links." src="/WebResource.axd?d=brkW-3LlPaSj-8IvArRJ0FxxgVzi2uClV5Y3FdgHnJHQrppNv2rTqwQ9mwf8f1JKZUVx3FkYMb7nBe1UKWWCBmVj3kY1&amp;t=634604713351482412" width="0" height="0" style="border-width:0px;"></a><div id="ctl06">
			<table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl06n0" href="javascript:TreeView_ToggleNode(ctl06_Data,0,document.getElementById('ctl06n0'),' ',document.getElementById('ctl06n0Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 图书典藏" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl06_Data,0,document.getElementById('ctl06n0'),' ',document.getElementById('ctl06n0Nodes'))"><a class="ctl06_0" href="#" id="ctl06t0">图书典藏</a></td>
				</tr>
			</tbody></table><div id="ctl06n0Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/BookCollecting.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t1');" id="ctl06t1">图书典藏</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/AddOnly.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t2');" id="ctl06t2">快速典藏</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/CollectManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t3');" id="ctl06t3">典藏管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/BookInventories.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t4');" id="ctl06t4">图书清点</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/BookClassInventories.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t5');" id="ctl06t5">分类清点</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl06n6" href="javascript:TreeView_ToggleNode(ctl06_Data,6,document.getElementById('ctl06n6'),' ',document.getElementById('ctl06n6Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 其他设置" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl06_Data,6,document.getElementById('ctl06n6'),' ',document.getElementById('ctl06n6Nodes'))"><a class="ctl06_0" href="#" id="ctl06t6">其他设置</a></td>
				</tr>
			</tbody></table><div id="ctl06n6Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/CodeCreate.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t7');" id="ctl06t7">条码打印</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/TagPrint.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t8');" id="ctl06t8">书标打印</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/SystemCodeCreate.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t9');" id="ctl06t9">系统条码</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl06_0" href="Collect/SystemTag.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl06_Data, this,'ctl06t10');" id="ctl06t10">系统书标</a></td>
					</tr>
				</tbody></table>
			</div>
		</div><a id="ctl06_SkipLink"></a>
	</div><div id="menuNav4" class="leftMenu" style="display: none; ">
		<a href="#ctl07_SkipLink"><img alt="Skip Navigation Links." src="/WebResource.axd?d=brkW-3LlPaSj-8IvArRJ0FxxgVzi2uClV5Y3FdgHnJHQrppNv2rTqwQ9mwf8f1JKZUVx3FkYMb7nBe1UKWWCBmVj3kY1&amp;t=634604713351482412" width="0" height="0" style="border-width:0px;"></a><div id="ctl07">
			<table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl07n0" href="javascript:TreeView_ToggleNode(ctl07_Data,0,document.getElementById('ctl07n0'),' ',document.getElementById('ctl07n0Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 期刊编目" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl07_Data,0,document.getElementById('ctl07n0'),' ',document.getElementById('ctl07n0Nodes'))"><a class="ctl07_0" href="#" id="ctl07t0">期刊编目</a></td>
				</tr>
			</tbody></table><div id="ctl07n0Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Catalogue/Add.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t1');" id="ctl07t1">期刊编目</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Catalogue/CatalogueManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t2');" id="ctl07t2">编目管理</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl07n3" href="javascript:TreeView_ToggleNode(ctl07_Data,3,document.getElementById('ctl07n3'),' ',document.getElementById('ctl07n3Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 期刊典藏" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl07_Data,3,document.getElementById('ctl07n3'),' ',document.getElementById('ctl07n3Nodes'))"><a class="ctl07_0" href="#" id="ctl07t3">期刊典藏</a></td>
				</tr>
			</tbody></table><div id="ctl07n3Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Collect/AddOnly.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t4');" id="ctl07t4">期刊典藏</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Collect/CollectManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t5');" id="ctl07t5">典藏管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Collect/Inventories.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t6');" id="ctl07t6">期刊清点</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl07n7" href="javascript:TreeView_ToggleNode(ctl07_Data,7,document.getElementById('ctl07n7'),' ',document.getElementById('ctl07n7Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 期刊流通" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl07_Data,7,document.getElementById('ctl07n7'),' ',document.getElementById('ctl07n7Nodes'))"><a class="ctl07_0" href="#" id="ctl07t7">期刊流通</a></td>
				</tr>
			</tbody></table><div id="ctl07n7Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/Circulate.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t8');" id="ctl07t8">期刊流通</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/BorrowQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t9');" id="ctl07t9">当前流通</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/BorrowOverdueQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t10');" id="ctl07t10">逾期未还</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/BookReserve.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t11');" id="ctl07t11">当前预借</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/TopQuery.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t12');" id="ctl07t12">借阅排行</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl07_0" href="Magazine/Circulate/OperationalLogbook.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl07_Data, this,'ctl07t13');" id="ctl07t13">操作日志</a></td>
					</tr>
				</tbody></table>
			</div>
		</div><a id="ctl07_SkipLink"></a>
	</div><div id="menuNav5" class="leftMenu" style="display: none; ">
		<a href="#ctl08_SkipLink"><img alt="Skip Navigation Links." src="/WebResource.axd?d=brkW-3LlPaSj-8IvArRJ0FxxgVzi2uClV5Y3FdgHnJHQrppNv2rTqwQ9mwf8f1JKZUVx3FkYMb7nBe1UKWWCBmVj3kY1&amp;t=634604713351482412" width="0" height="0" style="border-width:0px;"></a><div id="ctl08">
			<table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl08n0" href="javascript:TreeView_ToggleNode(ctl08_Data,0,document.getElementById('ctl08n0'),' ',document.getElementById('ctl08n0Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 基本管理" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl08_Data,0,document.getElementById('ctl08n0'),' ',document.getElementById('ctl08n0Nodes'))"><a class="ctl08_0" href="#" id="ctl08t0">基本管理</a></td>
				</tr>
			</tbody></table><div id="ctl08n0Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/User/UserManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t1');" id="ctl08t1">系统用户管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/User/RoleManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t2');" id="ctl08t2">系统角色管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Collection/CollectionManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t3');" id="ctl08t3">馆藏设置</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Bookclass/BookclassManage.aspx?op=manbc" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t4');" id="ctl08t4">分类设置</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0 selected" href="SystemManage/Publisher/PublisherManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t5');" id="ctl08t5">出版社管理</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl08n6" href="javascript:TreeView_ToggleNode(ctl08_Data,6,document.getElementById('ctl08n6'),' ',document.getElementById('ctl08n6Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 系统设置" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl08_Data,6,document.getElementById('ctl08n6'),' ',document.getElementById('ctl08n6Nodes'))"><a class="ctl08_0" href="#" id="ctl08t6">系统设置</a></td>
				</tr>
			</tbody></table><div id="ctl08n6Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Sys/SystemInfo.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t7');" id="ctl08t7">基本设置</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Sys/MenuMainFrame.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t8');" id="ctl08t8">系统菜单框架</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Sys/DbConnectionStringSetting.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t9');" id="ctl08t9">数据连接</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl08n10" href="javascript:TreeView_ToggleNode(ctl08_Data,10,document.getElementById('ctl08n10'),' ',document.getElementById('ctl08n10Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 其他管理" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl08_Data,10,document.getElementById('ctl08n10'),' ',document.getElementById('ctl08n10Nodes'))"><a class="ctl08_0" href="#" id="ctl08t10">其他管理</a></td>
				</tr>
			</tbody></table><div id="ctl08n10Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/DataDict/Default.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t11');" id="ctl08t11">数据词典</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Backup/BackupManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t12');" id="ctl08t12">备份管理</a></td>
					</tr>
				</tbody></table><table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Post/PostManage.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t13');" id="ctl08t13">公告管理</a></td>
					</tr>
				</tbody></table>
			</div><table cellpadding="0" cellspacing="0" style="border-width:0;">
				<tbody><tr>
					<td><a id="ctl08n14" href="javascript:TreeView_ToggleNode(ctl08_Data,14,document.getElementById('ctl08n14'),' ',document.getElementById('ctl08n14Nodes'))"><img src="/WebResource.axd?d=pbMw4GkoE50FlEXNU3CO_OZDZgrXpu0qbotNBM-_ex0yyH6IqNJUVtkmlS0QkaU9gFEZqiLImf5EgIYkQl9FLHy4RyxhpvX79Wc9czmMXUbscsKx0&amp;t=634604713351482412" alt="Collapse 工具" style="border-width:0;"></a></td><td style="white-space:nowrap;" onclick="javascript:TreeView_ToggleNode(ctl08_Data,14,document.getElementById('ctl08n14'),' ',document.getElementById('ctl08n14Nodes'))"><a class="ctl08_0" href="#" id="ctl08t14">工具</a></td>
				</tr>
			</tbody></table><div id="ctl08n14Nodes" style="display:block;">
				<table cellpadding="0" cellspacing="0" style="border-width:0;">
					<tbody><tr>
						<td><div style="width:20px;height:1px"></div></td><td><img src="/WebResource.axd?d=HqrLbjm1WbY5JRmqzbc-xldLs6Qh8lSDXL1NkVwIQaw6bKDVEkmX9LsvgXQGOPsPuewSJTdNoum-rxwGULOc7K_1OeroeaM9XsDvbW2q1t8DXNdf0&amp;t=634604713351482412" alt=""></td><td style="white-space:nowrap;"><a class="ctl08_0" href="SystemManage/Sys/RunSql.aspx" target="main" onclick="javascript:TreeView_SelectNode(ctl08_Data, this,'ctl08t15');" id="ctl08t15">运行Sql</a></td>
					</tr>
				</tbody></table>
			</div>
		</div><a id="ctl08_SkipLink"></a>
	</div>
</div>
        </div>
        <!-- 折叠 -->
        <div id="shrink">
            <div id="shrink_btn">
                <img src="images/shrink-btn-close.gif" onclick="setLeftWidth(1);"/>
                <img src="images/shrink-btn-open.gif" onclick="setLeftWidth(-1);"/>                
            </div>
        </div>
        <!-- 内容 -->
        <div id="content">
            <div class="down_right">
                <div class="menuSep">
                    <div id="notice">
                        1、我的图书管理系统，想用的就Call我，嘿嘿。
                    </div>
                    <div id="pageDo">
                        <span>
                            <img alt="后退" src="images/back.png" id="imgBack" /></span> <span>
                                <img alt="前进" src="images/foward.png" id="imgFoward" /></span> <span>
                                    <img alt="刷新" src="images/reflesh.png" id="imgReflesh" /></span>
                    </div>
                </div>
                <div id="curLocationNav">
                    <span>&nbsp;&nbsp;当前位置：首页</span>
                </div>
                <a class="hide" id="scrolltop" href="javascript:;">Top</a>
                <div id="sysOperateMsg" class="hide">
                    正在处理中，请稍后...</div>
                <div id="main_frame_box">
                    <iframe id="main" name="main" src="QuickLaunch.aspx" class="mainFrame" frameborder="0" scrolling="no"></iframe>                    
                </div>
            </div>
        </div>
    </div>
    <div id="modifyPwd" class="hide" style="width: 230px;">
        <form name="test" action='' style="padding: 5px;">
        <div class="thickBoxContent">
            <div class="row">
                <span class="tdRight">旧密码：</span><input type="password" class="txt120" id="pass"
                    name="pass" tabindex="1" /></div>
            <div class="row">
                <span class="tdRight">新密码：</span><input type="password" class="txt120" id="npass1"
                    name="npass1" tabindex="2" /></div>
            <div class="row">
                <span class="tdRight">确认密码：</span><input type="password" class="txt120" onkeyup="if(event.keyCode==13&&this.value!='')UpdatePass();"
                    id="npass2" name="npass2" />
            </div>
            <div id='sMsg' class="row error">
            </div>
            <div class="row">
                <div class="buttonLeft">
                    <span class="tdRight"></span>
                    <input type="button" name="ok" class="button60" onclick="UpdatePass();" value="确定" />
                    <input type="button" name="ok" class="button60" onclick="jQuery('.close').click();" value="关闭" /></div>
            </div>
        </div>
        </form>
    </div>
    </form>

    <script type="text/javascript" src="javascript/index.js"></script>

</body>
</html>