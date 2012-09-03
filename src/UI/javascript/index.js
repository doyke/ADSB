var contentFrame = jQuery("#main"); // 主内容框架
var curLocationNav = jQuery("#curLocationNav"); // 当前位置导航

$(function()
{
    ShowFirstMenu();
    initLeftMenuHover();
    initLeftMenuClose();
    
    window.onload = initHeight;
    window.onresize = initHeight;

    BindMouseOverChangeImg(".expendAll", "images/expand-all-hover.gif", "images/expand-all.gif");
    BindMouseOverChangeImg(".collapseAll", "images/collapse-all-hover.gif", "images/collapse-all.gif");
})

$("#main").load(function()
{
    setSubBody();
    showScrollTop(getSubDocument("#main").body);
})

$("#scrolltop").hover(
    function() { $("#scrolltop").addClass("scroll_top_hover"); },
    function() { $("#scrolltop").removeClass("scroll_top_hover"); }
).click(function()
{
    $("#scrolltop").attr("class", "hide");
    getSubDocument("#main").body.scrollTop = 0;
}); 

// 显示第一个菜单，隐藏其他所有的菜单
function ShowFirstMenu()
{
    $("#mainMenu div:first").addClass("curSelected");

    var menuNavs = $("div[id^='menuNav']");
    var len = menuNavs.length;

    if (len > 1)
    {
        for (var i = 1; i < len; i++)
        {
            menuNavs.eq(i).hide();
        }
    }
}

$("#mainMenu div").click(
    function()
    {
        changeMenu(this);
    }
)

// 切换菜单
function changeMenu(sender)
{
    var menuIndex = $(".curSelected").attr("menuIndex");
    $(".curSelected").removeClass("curSelected");
    sender.className = "curSelected";

    $("#menuNav" + menuIndex).hide();
    $("#menuNav" + sender.getAttribute("menuIndex")).show();
}

// 设置鼠标放到按钮上时css class
function initLeftMenuHover()
{
    setTreeHoverAndSelected(".leftMenu");
}

// 将图片的展开关闭树节点事件绑定到图片后面的文本上
function initLeftMenuClose()
{
    var index = 0;
    var closeImg = $(".leftMenu a[href^='javascript:TreeView_ToggleNode']");
    $(".leftMenu a[href^='javascript:TreeView_ToggleNode']").parent().next().each(
        function()
        {
            var clickMethod = closeImg.eq(index++).attr("href");
            this.setAttribute("onclick", clickMethod);
        });
}

// 折叠、关闭左边栏
function setLeftWidth(type)
{
    var initVal = 50 * type;
    var jLeft = $("#left");
    var jContent = $("#content");
    var jShrink = $("#shrink");

    if (type == -1 && parseInt(jShrink.css("left")) == 200)
    {
        jLeft.width("0");
        jShrink.css("left", "0");
        return;
    }

    if (type == 1 && parseInt(jShrink.css("left")) == 0)
    {
        jLeft.width("200px");
        jShrink.css("left", "200px");
        return;
    }

    var changeVal = (parseInt(jShrink.css("left")) + initVal).toString() + "px";

    jLeft.width(changeVal);
    jShrink.css("left", changeVal);    
}

// 初始化窗口高度
function initHeight()
{
    var htmlHeight = document.documentElement.clientHeight - $("#top").get(0).scrollHeight - 1;
    var minHeight = document.body.style.minHeight;

    if (htmlHeight < minHeight)
    {
        htmlHeight = minHeight;
        $(document.body).css("scroll-y", "scroll");
    }
    else
    {
        $(document.body).css("scroll-y", "hidden");
    }

    $("#left").height(htmlHeight);
    $("#shrink").height(htmlHeight);
    $(".down_right").height(htmlHeight);

    var mainHeight = htmlHeight;

    mainHeight -= $(".menuSep").height();
    mainHeight -= $("#curLocationNav").height() - 2;

    $("#main_frame_box").height(mainHeight);    
    
    mainHeight -= $("#main").css("paddingTop").parseInt();
    mainHeight -= $("#main").css("paddingBottom").parseInt();

    $("#main").height(mainHeight - 5);
    //$("#main").height($("#main").get(0).contentDocument.height);

    setSubBody();
}

function setSubBody()
{
    var domSubBody = document.getElementById("main").contentDocument || document.getElementById("main").contentWindow.document;
    var subBody = $(domSubBody.body);

    subBody.height($("#main").height() - 5);
    subBody.css("overflow-y", "auto");
    subBody.attr("class", "subBody");
}

/*====================== 事件绑定 =========================*/
$("#pageDo img").each(function(i)
{
    $(this).hover(
        function()
        {
            var locPx = 1;

            if (i == 1)
            {
                locPx = -1;
            }

            $(this).css({ marginRight: locPx + "px" });
        },
        function()
        {
            $(this).css({ marginRight: "0px" });
        }
    );
});

// 后退
$("#imgBack").click(function()
{
    history.go(-1);
})

// 向前
$("#imgFoward").click(function()
{
    history.go(1);
})

// 刷新
$("#imgReflesh").click(function()
{
    var reloadHref = contentFrame.get(0).contentWindow.location.href;
    main.location.href = reloadHref;
})

//系统退出
function exit()
{
    var flag = confirm("是否要退出系统？");
    //alert(flag);
    if (flag)
    {
        try
        {
            var res = BookManage.Web.Index.UserExit();
            //alert(res);
            if (res.value == true)
            {
                window.close();
            }
        }
        catch (e)
        { }
    }
}

//切换用户
function reLogin()
{
    try
    {
        var res = BookManage.Web.Index.UserExit();
        if (res.value == true)
        {
            window.location.href = "login.aspx";            
        }
    } catch (e)
    {
    }

    window.location.href = "login.aspx";    
}

// 首页
jQuery("#lnkHome").click(function()
{
    contentFrame.attr("src", "QuickLaunch.aspx");
})

// 帮助
jQuery("#lnkHelp").click(function()
{
    openNewWindow("Help.htm", 920, 620);
})

// 修改密码
jQuery("#lnkModifyPwd").click(function()
{
    new Boxy(jQuery("#modifyPwd"), { title: "修改密码", modal: true,width:"620px"});
    document.getElementById("sMsg").innerHTML = "";
    document.getElementById("pass").focus();
})

// 反馈
jQuery("#lnkFeedBack").click(function()
{
    openNewWindow("FeedBack.aspx", 920, 620);
})

jQuery("#lnkVerInfo").click(function()
{
    openNewWindow("Version.aspx", 920, 620);
})

// 设置菜单导航
jQuery("#pnlMenuItem a[target]").click(function()
{
    var splitChar = "&nbsp;>&nbsp;";
    var navString = "&nbsp;&nbsp;当前位置：";

    var rootMenuItemParentText = jQuery(this).closest("div").prev().find("td").eq(1).find("a").html();
    navString += rootMenuItemParentText + splitChar;
    navString += this.innerHTML;
    curLocationNav.html(navString);
})

// 折叠所有
jQuery(".collapseAll").click(function()
{
    var objClosed = jQuery("#pnlMenuItem .leftMenu::visible img[alt^='折叠']").parent();

    objClosed.each(function()
    {
        if (jQuery(this).attr("href") == "#")
        {
            return;
        }

        // jQuery(this).attr("onclick", jQuery(this).attr("href"));
        this.setAttribute("onclick", jQuery(this).attr("href"));
        jQuery(this).attr("href", "#");
    })

    objClosed.click();
})

// 展开所有
jQuery(".expendAll").click(function()
{
    var objClosed = jQuery("#pnlMenuItem .leftMenu::visible img[alt^='展开']").parent();

    objClosed.each(function()
    {
        if (jQuery(this).attr("href") == "#")
        {
            return;
        }

        //jQuery(this).attr("onclick", jQuery(this).attr("href"));
        this.setAttribute("onclick", jQuery(this).attr("href"));
        jQuery(this).attr("href", "#");
    })

    objClosed.click();
})

//修改密码处理
function UpdatePass()
{
    var pass = document.getElementById("pass");
    var n1 = document.getElementById("npass1");
    var n2 = document.getElementById("npass2");
    var sMsg = document.getElementById("sMsg");
    
    if (pass.value == "")
    {
        sMsg.innerHTML = "请输入原密码！";
        pass.focus();
        return false;
    }
    if (n1.value == "")
    {
        sMsg.innerHTML = "新密码不能为空！";
        n1.focus();
        return false;
    }

    if (n2.value == "")
    {
        sMsg.innerHTML = "确认密码不能为空！";
        n2.focus();
        return false;
    }
    
    if (n1.value != n2.value)
    {
        sMsg.innerHTML = "两次输入的密码不一致！";
        n1.focus();
        return false;
    }    
    
    var res = BookManage.Web.Index.ChanagePass(pass.value, n1.value, n2.value);
    if (res.error)
    {
        sMsg.innerHTML = res.error.Message;        
        return;
    }
    if (res.value == true)
    {
        sMsg.innerHTML = "密码修改成功!";
        pass.value = "";
        n1.value = "";
        n2.value = "";
    }
    else
    {
        sMsg.innerHTML = "修改失败,原密码不正确!";
        pass.value = "";
        pass.focus();
    }
}