using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BruceFramework.Common
{
    public class TypeParse
    {
        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                return StrToBool(expression, defValue);
            }
            return defValue;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(expression, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(object expression, int defValue)
        {
            if (expression != null)
            {
                return StrToInt(expression.ToString(), defValue);
            }
            return defValue;
        }
    
        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            //if (str == null)
            //    return defValue;
            //if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*$"))
            //{
            //    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
            //    {
            //        return Convert.ToInt32(str);
            //    }
            //}
            //return defValue;      
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;
            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;
            return Convert.ToInt32(StrToFloat(str, defValue));
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
            {
                return defValue;
            }

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
            {
                return defValue;
            }

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                {
                    float.TryParse(strValue, out intValue);
                }
            }
            return intValue;
        }

        /// <summary>
        /// 转换为日期字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String Object2DateTimeString(object date)
        {
            return Object2DateTimeString(date, null);
        }

        /// <summary>
        /// 转换为指定格式日期字符串
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static String Object2DateTimeString(object date, String dateFormat)
        {
            // 如果date为空，返回空字符串
            if (date == null || String.IsNullOrEmpty(date.ToString()))
            {
                return String.Empty;
            }

            try
            {
                // 如果没有设置日期格式，返回默认格式
                if (!String.IsNullOrEmpty(dateFormat))
                {
                    return Convert.ToDateTime(date).ToString();
                }
                else
                {
                    return Convert.ToDateTime(date).ToString(dateFormat);
                }
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// 转换对日期格式
        /// </summary>
        /// <param name="date"></param>
        /// <param name="replaceDate">转换失败时用于返回的值</param>
        /// <returns></returns>
        public static DateTime Object2DateTime(object date, DateTime replaceDate)
        {
            string dateString = Object2DateTimeString(date);

            if (dateString.Length > 0)
            {
                return Convert.ToDateTime(dateString);
            }

            return replaceDate;
        }

        /// <summary>
        /// 转换为Int32
        /// </summary>
        /// <param name="iVal"></param>
        /// <param name="replaceVal"></param>
        /// <returns></returns>
        public static Int32 Object2Int32(object iVal, int replaceVal)
        {
            if (iVal == null)
            {
                return replaceVal;
            }

            Int32.TryParse(iVal.ToString(), out replaceVal);

            return replaceVal;
        }

        /// <summary>
        /// 转换成单精度浮点型
        /// </summary>
        /// <param name="fVal"></param>
        /// <param name="replaceVal"></param>
        /// <returns></returns>
        public static Single Object2Single(object fVal, Single replaceVal)
        {
            if (fVal == null)
            {
                return replaceVal;
            }

            Single.TryParse(fVal.ToString(), out replaceVal);

            return replaceVal;
        }

        /// <summary>
        /// 转换成单精度浮点型
        /// </summary>
        /// <param name="dVal"></param>
        /// <param name="replaceVal"></param>
        /// <returns></returns>
        public static Double Object2Double(object dVal, Double replaceVal)
        {
            if (dVal == null)
            {
                return replaceVal;
            }

            Double.TryParse(dVal.ToString(), out replaceVal);

            return replaceVal;
        }

        /// <summary>
        /// 转换为Boolean类型。
        /// 1. 如果值为1：true, 0：false
        /// 2. 使用Convert.ToBoolean转换
        /// </summary>
        /// <param name="bVal"></param>
        /// <returns></returns>
        public static Boolean Object2Boolean(object bVal)
        {
            if (bVal == null)
            {
                return false;
            }

            if (string.Equals(bVal.ToString(), "1"))
            {
                return true;
            }

            if (string.Equals(bVal.ToString(), "0"))
            {
                return false;
            }

            try
            {
                return Convert.ToBoolean(bVal);
            }
            catch
            {
                return false;
            }
        }
    }
}
