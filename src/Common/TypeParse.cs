using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BruceFramework.Common
{
    public class TypeParse
    {
        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                return StrToBool(expression, defValue);
            }
            return defValue;
        }

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
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
        /// ������ת��ΪInt32����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(object expression, int defValue)
        {
            if (expression != null)
            {
                return StrToInt(expression.ToString(), defValue);
            }
            return defValue;
        }
    
        /// <summary>
        /// ������ת��ΪInt32����
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
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
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
            {
                return defValue;
            }

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
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
        /// ת��Ϊ�����ַ���
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String Object2DateTimeString(object date)
        {
            return Object2DateTimeString(date, null);
        }

        /// <summary>
        /// ת��Ϊָ����ʽ�����ַ���
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static String Object2DateTimeString(object date, String dateFormat)
        {
            // ���dateΪ�գ����ؿ��ַ���
            if (date == null || String.IsNullOrEmpty(date.ToString()))
            {
                return String.Empty;
            }

            try
            {
                // ���û���������ڸ�ʽ������Ĭ�ϸ�ʽ
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
        /// ת�������ڸ�ʽ
        /// </summary>
        /// <param name="date"></param>
        /// <param name="replaceDate">ת��ʧ��ʱ���ڷ��ص�ֵ</param>
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
        /// ת��ΪInt32
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
        /// ת���ɵ����ȸ�����
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
        /// ת���ɵ����ȸ�����
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
        /// ת��ΪBoolean���͡�
        /// 1. ���ֵΪ1��true, 0��false
        /// 2. ʹ��Convert.ToBooleanת��
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
