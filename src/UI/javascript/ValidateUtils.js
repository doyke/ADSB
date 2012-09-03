//手机验证
function isMobile(mobile)
{
    return (/^(?:13\d|15\d)-?\d{5}(\d{3}|\*{3})$/.test(mobile));
}

//电话验证
function isTel(tel)
{
    return (/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/.test(tel));
}

//电话或者手机验证
function isTelOrMobile(s)
{
    return (isMobile(s) || isTel(s));
}

//邮件验证
function isEmail(s)
{
    return (/^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)$/.test(s));
}

/*
* 检查输入的身份证号是否正确
* 输入:str  字符串
*  返回:true 或 flase; true表示格式正确
*/
function checkCard(str)
{
    //15位数身份证正则表达式
    var arg1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;
    //18位数身份证正则表达式
    var arg2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/;
    if (str.match(arg1) == null && str.match(arg2) == null)
    {
        return false;
    }
    else
    {
        return true;
    }
}

//身份证验证
function IsIdnum(str)
{

    var City = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ",

        31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北 ",

        43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ",

        61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "***", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 "
    }

    var iSum = 0

    var info = ""

    if (!/^\d{17}(\d|x)$/i.test(str))

        return false;

    str = str.replace(/x$/i, "a");

    if (City[parseInt(str.substr(0, 2))] == null)
    {

        alert("Error:非法地区");

        return false;

    }

    sBirthday = str.substr(6, 4) + "-" + Number(str.substr(10, 2)) + "-" + Number(str.substr(12, 2));

    var d = new Date(sBirthday.replace(/-/g, "/"))

    if (sBirthday != (d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate()))
    {

        alert("Error:非法生日");

        return false;

    }

    for (var i = 17; i >= 0; i--)

        iSum += (Math.pow(2, i) % 11) * parseInt(str.charAt(17 - i), 11)

    if (iSum % 11 != 1)
    {

        alert("Error:非法证号");

        return false;

    }

    return City[parseInt(str.substr(0, 2))] + "," + sBirthday + "," + (str.substr(16, 1) % 2 ? " 男" : "女")

}

/*
*  检查输入的URL地址是否正确
*  输入:str  字符串
*  返回:true 或 flase; true表示格式正确
*/
function checkURL(str)
{
    if (str.match(/(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i) == null)
    {
        return false
    }
    else
    {
        return true;
    }
}

//验证邮编
function IsPostalCode(str)
{
    var reg = /^\d{6}$/;

    return reg.test(str);
}

/* 用途：校验ip地址的格式输入：strIP：ip地址返回：如果通过验证返回true,否则返回false； */
function isIP(strIP)
{
    if (isNull(strIP))
    {
        return false;
    }
    var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/g;
    // 匹配IP地址的正则表达式 
    if (re.test(strIP))
    {
        if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
        {
            return true;
        }
    }
    return false;
}

//验证浮点数
function isFloat(val)
{
    var re = /^[0-9]+.?[0-9]*$/;
    if (!re.test(val))
    {
        return true;
    }
    else
    {
        return false;
    }
}

// 判断一个输入是不是正整数 
function plusIntegerCheck(s)
{
    if (s.match(/^[1-9]\d*$/))
    {
        return true;
    }
    return false;
}
// 校验是否全由数字组成 
function isDigit(s)
{
    var patrn = /^[0-9]+.?[0-9]*$/;
    if (!patrn.exec(s))
    {
        return false;
    }
    return true;
}
// 只能输入数字 
function test_shuzi(str)
{
    var myReg = /^[0-9]*$/;
    if (myReg.test(str))
    {
        return true;
    }
    return false;
}

// 整形数校验 
function checkInt(sl)
{
    var re = new RegExp("^-?\\d+$");

    if (!re.test(sl))
    {
        return false;
    }
    else
    {
        return true;
    }
}

//判断日期格式是否合法
function isDate()
{
    var r = this.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) return false; var d = new Date(r[1], r[3] - 1, r[4]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
}

//判断是否短时间，形如 (13:04:06)
function isTime(str)
{

    var a = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);

    if (a == null)
    {

        alert('输入的参数不是时间格式'); return false;

    }

    if (a[1] > 24 || a[3] > 60 || a[4] > 60)
    {

        alert("时间格式不对");

        return false

    }

    return true;

}

//检查是否含有汉字
function checkChars(s)
{
    if (/[^\x00-\xff]/g.test(s))
    {
        return true; //含有汉字
    }
    else
    {
        return false; //全是字符
    }
}

//验证用户名是否正确,即只能为数字或字母或下滑线组成
function notChinese(str)
{
    var reg = /[^A-Za-z0-9_]/g;
    if (reg.test(str))
        return (false);
    else
        return (true);
}