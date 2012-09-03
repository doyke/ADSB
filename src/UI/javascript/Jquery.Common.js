/// 内容摘要：绑定对象鼠标悬浮在元素上的图片，处鼠标离开时的图片
/// 完成日期：2011-04-23
/// objSource:事件对象
/// overSrc:鼠标悬浮显示的图片
/// outSrc:鼠标离开时的图片
function BindMouseOverChangeImg(objSource, overSrc, outSrc)
{
    var jSource = $(objSource);

    jSource.hover(
        function()
        {
            jSource.attr("src", overSrc);
        },
        function()
        {
            jSource.attr("src", outSrc);
        }
    );
}

function emptySelect(objSelect)
{
    objSelect.options.length = 0;
}

function addOption(objSelect, i, text, value)
{
    objSelect.options[i] = new Option(text, value);
}

String.format = function()
{
    if (arguments.length == 0)
    {
        return null;
    }

    var str = arguments[0];

    for (var i = 1; i < arguments.length; i++)
    {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }

    return str;
}

String.prototype.parseInt = function()
{
    try
    {
        return parseInt(this);
    }
    catch (e)
    {
        return 0;
    }
}

Request = {
    QueryString: function(item)
    {
        var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)", "i"));

        return svalue ? svalue[1] : svalue;
    }
}

///常用JS
var lang = new Array();
var userAgent = navigator.userAgent.toLowerCase();
var is_opera = userAgent.indexOf('opera') != -1 && opera.version();
var is_moz = (navigator.product == 'Gecko') && userAgent.substr(userAgent.indexOf('firefox') + 8, 3);
var is_ie = (userAgent.indexOf('msie') != -1 && !is_opera) && userAgent.substr(userAgent.indexOf('msie') + 5, 3);
var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
var VarPage = 0; //默认分辨率显示多少
var clientHeight = window.screen.height; //客户端分辨率高度
var MaxPageSize = 20; //默认20条每页

function getVarPage()
{
    //alert(clientHeight);
    var x = clientHeight - 768;
    var temp = (x - (x * 0.14)) / 24;
    //alert(temp);
    VarPage = parseInt(temp);
    //alert(VarPage);
    MaxPageSize += VarPage;

}

function openUrl(url, w, h, stype)
{
    var left = (window.screen.width - w) / 2;
    var top = (window.screen.height - h) / 2 - 30;
    //alert(left);alert(top);
    var win = null;
    if (window.showModalDialog && stype == 'm')
    {
        w = w + 10;
        h = h + 55;
        win = window.showModalDialog(url, "", "dialogWidth:" + w + "px;dialogheight:" + h + "px");
    }
    else if (stype == 'n')
    {
        win = window.open(url, "xWindow", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,copyhistory=no,modal=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
    }
    else if (stype == 't')
    {
        win = window.open(url, "xWindow", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,modal=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
    }
    else if (stype == 's')
    {
        win = window.open(url, "newWindow", "toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=no,resizable=no,copyhistory=no,modal=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
    }
    else if (stype == 'f')
    {
        win = window.open(url, "fWindow", "toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,modal=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
    }
    else
    {
        win = window.open(url, "newWindow", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,copyhistory=no,modal=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
    }
    win.focus();
    //openMode(url,w,h);
}

function openNewWindow(url, w, h)
{
    var left = (window.screen.width - w) / 2;
    var top = (window.screen.height - h) / 2 - 40;
    //alert(left);alert(top);
    window.open(url, "newWindow2", "toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left + "");
}

function openIndex(url, op)
{
    var left = 0; //(window.screen.width-w)/2;
    var top = 0; //(window.screen.height-h)/2;
    //alert(left);alert(top);
    var name = "Index";
    if (op != 0)
    {
        //name = "NewIndex"+op;
        name = op;
    }
    //alert(name);
    var win = window.open(url, name, "toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=no,resizable=yes,copyhistory=no,top=" + top + ",left=" + left + "");
    win.moveTo(0, 0);
    win.resizeTo(screen.availWidth, screen.availHeight);

}

/*===============函数说明=====================
1.为模式窗口设置参数
function setValues(iHeight, iWidth, resizable)

2.在内框架中显示页面
function openModalDialog(innerPageURL, title, frameURL, dialogWidth, dialogHeight, resizable)

3.在客户端选择dataGrid中的一行。
txtSelectIndex域记录了行号, optional
function getDgdSelectIndex(txtSelectIndex)

4.选定DataGrid的行，并将该行的CheckBox置为选择状态
lastSelectedRowIndex: 最后选定行在当前页的索引, optional
function checkDgdRow(lastSelectedRowIndex)
==========================================*/

//====全局变量===
var values = new Array();
var iHeight;
var iWidth;
var urlFrame = '/Common/frame.htm';
//===============

//1.为模式窗口设置参数
function setValues(iHeight, iWidth, resizable)
{
    var features = "dialogHeight: " + iHeight + "px;";
    features += "dialogWidth: " + iWidth + "px;";
    features += "help: no; status: no; scroll: no;";
    features += "resizable: " + resizable;

    return features;
}

//2.在内框架中显示页面
function openModalDialog(innerPageURL, title, dialogWidth, dialogHeight)
{
    var inPara = new Array();
    inPara[0] = innerPageURL;
    inPara[1] = title;

    var features = setValues(dialogHeight, dialogWidth, 'no');
    values = window.showModalDialog(urlFrame, inPara, features);
    return values;
}

// 获取iframe的document对象
function getSubDocument(selector)
{
    return jQuery(selector).get(0).contentDocument || jQuery(selector).get(0).contentWindow.document;
}

// 选择所有复选框
function checkAll(objSource, selector)
{
    if (objSource.checked)
    {
        jQuery(selector).each(function()
        {
            this.checked = true;
        })
    }
    else
    {
        jQuery(selector).each(function()
        {
            this.checked = false;
        })
    }
}

// 设置TreeView选中和鼠标经过设置背景
function treeHoverAndSelected()
{
    var currentSelectedItem;
    
    return function(selector)
    {
        selector = selector + " a:not(" + selector + " a[href^='javascript:TreeView_ToggleNode'])";
        var menuItem = jQuery(selector);

        menuItem.hover(
            function()
            {
                $(this).addClass("hover");
            },
            function()
            {
                $(this).removeClass("hover");
            }
        );

        menuItem.click(function()
        {
            jQuery(currentSelectedItem).removeClass("selected");
            currentSelectedItem = this;
            jQuery(this).addClass("selected");
        });
    }
}

// setTreeHoverAndSelected调用
function setTreeHoverAndSelected(selector)
{
    treeHoverAndSelected()(selector);
}

function showScrollTop(selector)
{
    var scrollObj = jQuery(selector);

    scrollObj.scroll(function()
    {
        var scropLink = jQuery("#scrolltop");

        if (scrollObj.get(0).scrollTop > 50)
        {            
            scropLink.removeClass("hide");
            scropLink.addClass("scroll_top");
        }
        else
        {
            scropLink.removeClass("scroll_top");
            scropLink.addClass("hide");
        }
    });
}

function scrollTop(selector)
{
     jQuery(selector).get(0).window.scroll(0,0)
}