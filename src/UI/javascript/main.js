jQuery(document).ready(function() {
    initDatagrid();
    InsteadOfHTMLComponent();
    buttonHover();
    setFirstInputFocus();
    initSysOperateMsg();
    setCheckSubmit();
    setJButton();
    setDelete();
})

function setDelete() {
    $(".delete").click(function() {
        return confirm("确认删除？");
    })
}

function setJButton() {
    $(".jui_button").button();
}

function setCheckSubmit() {
    $(".bt_submit[type='submit']").bind("click", checkSubmit);
    $(".bt_submit[type='button']").attr("onclick", "if (!checkSubmit(event)){return false;}" + $(".bt_submit[type='button']").attr("onclick"));
}

// 检测提交，兼容ie/firefox/chrome

function checkSubmit(event) {
    // 防止重复提交
    if ($(this).attr("submitState") == "1") {
        return false;
    }

    var oEvent = event;

    // 如果是jquery.event
    if (event.originalEvent) {
        oEvent = event.originalEvent;
    }

    // 检查必填项
    checkInput(oEvent);

    if (!oEvent.returnValue) {
        return false;
    }

    // 设置提交状态
    $(this).attr("submitState", "1").val("正在提交");
    return true;
}

function checkInput(e) {
    var curEvent = e;

    curEvent.returnValue = true;

    $("label.require").each(function() {
        var theLabel = this;
        var toValidate = $(this).next("p").find(":text,select").first();

        if ($.trim(toValidate.val()).length == 0) {
            var msg = $(this).text();

            if (msg.substr(0, 1) == "*") {
                msg = msg.substr(1);
            }

            var subfix = toValidate.get(0).tagName == "SELECT" ? "选择" : "输入";

            dialogAlertMessage(msg + "不能为空，请重新" + subfix + "！", function() {
                toValidate.focus();
            });
            curEvent.returnValue = false;
            return false;
        }
    });
}

//鼠标点击文本框变色

function InsteadOfHTMLComponent() {
    var inputs = jQuery(":text,:password,textarea");

    if (inputs.length == 0) {
        return;
    }

    inputs.each(function() {
        if (jQuery(this).attr("readonly")) {
            return;
        }

        jQuery(this).bind("focus", function() {
            jQuery(this).addClass("text_active");
        });

        jQuery(this).bind("blur", function() {
            jQuery(this).removeClass("text_active");
        });
    });
}

// 鼠标移到按钮上方，改变背景图片

function buttonHover() {
    jQuery(".button60").hover(
        function() {
            jQuery(this).addClass("button60Hover");
        },
        function() {
            jQuery(this).removeClass("button60Hover");
        }
    );
}

///////datagrid选中行变色与鼠标经过行变色///////////////

function initDatagrid() {
    var tbList = jQuery(".data_list");
    jQuery("tr:odd:not(:first)", tbList).addClass("trEven"); // 奇数行，行数：（1，3，5...）
    jQuery("tr:even", tbList).addClass("trOdd"); // 偶数行，行数：（2，4，6...）

    // 鼠标经过的行变色
    jQuery("tr:not(:first)", tbList).hover(
        function() {
            jQuery(this).addClass('trHover');
        },
        function() {
            jQuery(this).removeClass('trHover');
        }
    );

    // 选择行变色
    jQuery("tr", tbList).click(
        function() {
            tbList.find(".trSelected").removeClass('trSelected');

            if (jQuery("tr:first").is($(this))) {
                return;
            }

            jQuery(this).addClass('trSelected');
        }
    );
}

// 回车执行设置默认按钮事件

function setDefaultButton(selector) {
    jQuery(document).keydown(function(e) {
        if (e.keyCode == 13) {
            jQuery(selector).click();
        }
    });
}

// 设置文本框焦点：默认第一个文本框

function setFirstInputFocus(selector) {
    try {
        if (selector) {
            jQuery(selector).focus();
        } else {
            if (jQuery(document).find(":text:first").length > 0) {
                jQuery(document).find(":text:first").get(0).focus();
            }
        }
    } catch (e) {
        return;
    }
}

jQuery(".check-all").live("click", function() {
    checkAll(this, "#tbList :checkbox:not(.check-all)");
})

// 清空搜索输入框，绑定到btnReset按钮
jQuery("#btnReset").live("click", function() {
    resetInput("#conditionContainer");
});

// 清空搜索输入框

function resetInput(selector) {
    jQuery(selector + " :text").val("");
}

//按键处理

function keyDown(e) {
    if (!ie) {
        var nkey = e.which;
        if (nkey == 116) {
            window.location.reload();
            e.preventDefault(); //屏蔽Firefox默认处理
        }
        if ((nkey == 17 || nkey == 82)) {
            e.preventDefault(); //屏蔽Firefox默认处理
        }
    }
    if (ie) {
        var nkey = event.keyCode;
        if (nkey == 116) {
            event.keyCode = 0;
            window.location.reload();
            event.cancelBubble = true;
            return false;
        }
        if ((event.ctrlKey && event.keyCode == 82) ||
            (event.ctrlKey) && (event.keyCode == 78) ||
            (event.shiftKey) && (event.keyCode == 121)) {
            //event.keyCode = 0; 
            //event.cancelBubble = true; 
            return false;
        }
    }
}
//获取KEYCODE

function keyCode(evt) {
    var code = 0;
    //var evt;
    evt = evt || window.event;
    var a = evt.srcElement || evt.target;
    code = evt.keyCode || evt.which;
    // alert(code);
    return code;
}

//Enter键自动下一到输入框

function autoNext(evt) {
    evt = evt || window.event;
    var a = evt.srcElement || evt.target;

    if (evt.keyCode == 13) {
        //alert(a.type);
        if (a.type != "button" && a.type != "sublit" && a.type != "reset" && a.type != "file") {
            if (ie)
                evt.keyCode = 9;
            //else
            //evt.which = 9;
        }
    }
}

/* ======================== 系统专用方法 Start ======================== */

var jSysOperateMsg;

var noDataWarmHtml = "<div class='noDataWarm'>对不起，没有查询到您要的信息！</div>";
var loadDataMsg = "数据加载中，请稍候…";

var sysOperateMsgOverTime = 2000;
var showMsgOverTime = 300;
var showErrorMsgOverTime = 5000;
var showMsgTimer = null;

// 初始化消息

function initSysOperateMsg() {
    jSysOperateMsg = jQuery("#sysOperateMsg");

    if (jSysOperateMsg.length == 0) {
        var domSysOperateMsg = window.parent.document.getElementById("sysOperateMsg");
        jSysOperateMsg = jQuery(domSysOperateMsg);
    }
}

// 显示消息

function showMsg(msg) {
    jSysOperateMsg.html(msg);
    jSysOperateMsg.fadeIn();
}

// 隐藏消息

function hideMsg() {
    jSysOperateMsg.fadeOut();
}

// 系统操作消息提示 显示 (默认提示：正在处理中，请稍后...)

function showOperateMsg(msg) {
    if (msg && msg.length > 0) {
        if (showMsgTimer != null) {
            clearTimeout(showMsgTimer);
        }

        msg = String.format("<div class=\"normalMsg\">{0}</div>", msg);
        showMsgTimer = setTimeout("showMsg('" + msg + "')", showMsgOverTime);
    }
}

// 显示操作结果

function showOperateResult(msg) {
    if (jSysOperateMsg != null && jSysOperateMsg.length > 0) {
        var msg = String.format("<div class=\"normalMsg\">{0}</div>", msg);
        showOperateMsg(msg);
        setTimeout("hideOperateMsg()", sysOperateMsgOverTime);
    }
}

// 显示错误消息

function showErrorMsg(msg) {
    if (jSysOperateMsg != null && jSysOperateMsg.length > 0) {
        var msg = String.format("<div class=\"errorMsg\">{0}</div>", msg);
        showOperateMsg(msg);
        setTimeout("hideOperateMsg()", showErrorMsgOverTime);
    }
}

// 显示成功消息

function showSuccessMsg(msg) {
    if (jSysOperateMsg != null && jSysOperateMsg.length > 0) {
        var msg = String.format("<div class=\"successMsg\">{0}</div>", msg);
        showOperateMsg(msg);
        setTimeout("hideOperateMsg()", sysOperateMsgOverTime);
    }
}

// 系统操作消息提示 隐藏

function hideOperateMsg() {
    if (jSysOperateMsg != null && jSysOperateMsg.length > 0) {
        setTimeout("hideMsg()", showMsgOverTime);
    }
}
/* ======================== 系统专用方法 End ======================== */

/* ======================= jQuery Dialog 开始 ================================= */

function dialogSucessMessage(message, callback) {
    dialogMessage(message, callback, 1);
}

function dialogAlertMessage(message, callback) {
    dialogMessage(message, callback, 2);
}

// 弹出错误消息

function dialogMessage(message, callback, dialogType) {
    var option = dialogTitle(dialogType);
    var selector = "ui-dialog-message";
    var obj = jQuery("#" + selector);

    if (obj == null || obj.length == 0) {
        obj = jQuery(String.format("<div id='{0}' title='{1}'></div>", selector, option["title"]));
        jQuery(document).append(obj);
    }

    obj.html(String.format('{0}{1}', option["msgIconHtml"], message));
    obj.dialog({
        title: option["title"],
        modal: true,
        buttons: {
            "确定": function() {
                jQuery(this).dialog("close");

                if (callback != null) {
                    callback();
                }
            }
        }
    });
}

function dialogTitle(dialogType) {
    var arrVal = new Array();

    switch (dialogType) {
        case 1:
            arrVal["title"] = "消息提示";
            arrVal["msgIconHtml"] = '<span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>';
            break;
        case 2:
            arrVal["title"] = "错误消息";
            arrVal["msgIconHtml"] = '<span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 50px 0;"></span>';
            break;
        default:
            arrVal["title"] = "消息提示";
            arrVal["msgIconHtml"] = "";
            break;
    }

    return arrVal;
}

// 弹出确认对话框

function dialogConfirm(message, callback, callbackParams) {
    var selector = "ui-dialog-warm-message";
    var obj = jQuery("#" + selector);

    if (obj == null || obj.length == 0) {
        obj = jQuery(String.format("<div id='{0}' title='确认'></div>", selector));
        jQuery(document).append(obj);
    }

    obj.html(String.format('<span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 50px 0;"></span>{0}', message));
    obj.dialog({
        resizable: false,
        height: 140,
        modal: true,
        buttons: {
            "是": function() {
                jQuery(this).dialog("close");
                callback(callbackParams);
            },
            "否": function() {
                jQuery(this).dialog("close");
            }
        }
    });
}
/* ======================= jQuery Dialog 结束 ================================== */

// 打开弹出窗口
// type: 可选值modal,modeless,或为空（默认值）

function openWin(url, title, width, height, type) {
    var toUrl = "/AgencyCustomer/Popup.htm?t=" + new Date().getTime();

    if (type && (type == "modal" || type == "modeless")) {
        var params = [];

        params[0] = url
        params[1] = title;

        if (type == "modeless" && window.showModelessDialog) {
            window.showModelessDialog(toUrl, params, 'top:50;left:50;dialogWidth:' + width + 'px;dialogHeight:' + height + 'px;scrollbars:yes;resizable:yes;');
        } else {
            window.showModalDialog(toUrl, params, 'top:50;left:50;dialogWidth:' + width + 'px;dialogHeight:' + height + 'px;scrollbars:yes;resizable:yes;');
        }
    } else {
        toUrl += "&url=" + encodeURIComponent(url) + "&title=" + encodeURIComponent(title);
        window.open(toUrl, "_target", 'top=50,left=50,width=' + width + ',height=' + height + ',scrollbars=yes,resizable=yes');
    }
}