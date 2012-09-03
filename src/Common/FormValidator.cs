using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ADSL.Common
{
    public class FormValidator
    {
        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            //return Regex.IsMatch(strEmail, @"^[A-Za-z0-9-_]+@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
            return Regex.IsMatch(strEmail, @"^[\w\.]+@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 验证email地址
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(object email)
        {
            if (email == null)
            {
                return false;
            }

            Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            return regex.IsMatch(email.ToString());
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsValidURL(object url)
        {
            if (url == null)
            {
                return false;
            }

            Regex regex = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");

            return regex.IsMatch(url.ToString());
        }

        /// <summary>
        /// 验证全部为字母
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static bool OnlyCharacters(object character)
        {
            if (character == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^.[A-Za-z]+$");

            return regex.IsMatch(character.ToString());
        }

        /// <summary>
        /// 验证全部为数字
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool OnlyNumber(object number)
        {
            if (number == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^.[0-9]*$");

            return regex.IsMatch(number.ToString());
        }

        /// <summary>
        /// 验证是否为美国电话号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidUSPhone(object phone)
        {
            if (phone == null)
            {
                return false;
            }

            Regex regex = new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}");

            return regex.IsMatch(phone.ToString());

        }

        /// <summary>
        /// 验证美国邮政编码
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public static bool IsValidUSZipCode(object zipcode)
        {
            if (zipcode == null)
            {
                return false;
            }

            Regex regex = new Regex(@"\d{5}(-\d{4})?");

            return regex.IsMatch(zipcode.ToString());
        }

        /// <summary>
        /// 验证是否为韩文
        /// </summary>
        /// <param name="korean"></param>
        /// <returns></returns>
        public static bool IsValidKorean(object korean)
        {
            if (korean == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^.[\uac00-\ud7af\u1100-\u11FF\u3130-\u318f]+$");

            return regex.IsMatch(korean.ToString());
        }

        /// <summary>
        /// 验证是否为中国手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsValidCNMobile(object mobile)
        {
            if (mobile == null)
            {
                return false;
            }

            Regex regex = new Regex(@"^((\(\d{3}\))|(\d{3}\-))?13[0-9]\d{8}|15[0-9]\d{8}|18[0-9]\d{8}");

            return regex.IsMatch(mobile.ToString());
        }

        /// <summary>
        /// 验证是否为中国电话号码
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsValidCNPhone(object phone)
        {
            if (phone == null)
            {
                return false;
            }

            Regex regex = new Regex(@"(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}");

            return regex.IsMatch(phone.ToString());
        }

        /// <summary>
        /// 验证中国邮政编码
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public static bool IsValidCNZipCode(object zipcode)
        {
            if (zipcode == null)
            {
                return false;
            }

            Regex regex = new Regex(@"\d{6}");

            return regex.IsMatch(zipcode.ToString());
        }

        /// <summary>
        /// 验证身份证是否为15位或18位
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool IsValidCNID(object ID)
        {
            if (ID == null)
            {
                return false;
            }

            Regex regex = new Regex(@"d{18}|d{15}");

            return regex.IsMatch(ID.ToString());

        }        
    }
}
