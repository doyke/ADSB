/*
 *���������ڽ�Сд����ת��Ϊ
 * 1. һ�����Ĵ�д����
 * 2. ����Ҵ�д����
 */

using System;
using System.Text;

namespace BruceFramework.Common
{
    /// �� �� ��:DigitToChnText
    /// ������Ա:¬С��
    /// �������:2010-06-19
    /// ��    �ݣ�������ֵ����Ĵ�д��ת����Ҳ��ת��Ϊ��д�������ʽ
    public class DigitToChnText
    {
        private char[] chnGenText = new char[] { '��', 'һ', '��', '��', '��', '��', '��', '��', '��', '��' };
        private char[] chnGenDigit = new char[] { 'ʮ', '��', 'ǧ', '��', '��' };
        private char[] chnRMBText = new char[] { '��', 'Ҽ', '��', '��', '��', '��', '½', 'Ⱦ', '��', '��' };
        private char[] chnRMBDigit = new char[] { 'ʰ', '��', 'Ǫ', '�f', '�|' };
        private char[] chnRMBUnit = new char[] { 'ʰ', '��', 'Ǫ', '�f', '�|' };
     
        public DigitToChnText()
        {
        }

        /// <summary>
        /// ��ת������
        /// </summary>
        /// <param name="strDigit">��ת�������ַ���</param>
        /// <param name="bToRMB">�Ƿ�ת���������</param>
        /// <returns>ת���ɵĴ�д�ַ���</returns>
        public string Convert(string strDigit, bool bToRMB)
        {
            // �������������Ч��
            if (CheckDigit(ref strDigit, bToRMB))
            {
                // �������ַ���
                StringBuilder strResult = new StringBuilder();

                // ��ȡ���Ų���
                ExtractSign(ref strResult, ref strDigit, bToRMB);

                // ��ȡ��ת��������С������
                ConvertNumber(ref strResult, ref strDigit, bToRMB);

                return strResult.ToString();
            }
            else
            {
                return "������Ч��";
            }
        }

        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="strResult"></param>
        /// <param name="strDigit"></param>
        /// <param name="bToRMB"></param>
        protected void ConvertNumber(ref StringBuilder strResult, ref string strDigit, bool bToRMB)
        {
            int indexOfPoint;
            if (-1 == (indexOfPoint = strDigit.IndexOf('.'))) // ���û��С������
            {
                strResult.Append(ConvertIntegral(strDigit, bToRMB));

                if (bToRMB) // ���ת���������
                {
                    strResult.Append("Բ��");
                }
            }
            else // ��С������
            {
                // ��ת����������
                if (0 == indexOfPoint) // �����.���ǵ�һ���ַ�
                {
                    if (!bToRMB) // ���ת����һ�����Ĵ�д
                    {
                        strResult.Append('��');
                    }
                }
                else // �����.�����ǵ�һ���ַ�
                {
                    strResult.Append(ConvertIntegral(strDigit.Substring(0, indexOfPoint), bToRMB));
                }

                // ��ת��С������
                if (strDigit.Length - 1 != indexOfPoint) // �����.���������һ���ַ�
                {
                    if (bToRMB) // ���ת���������
                    {
                        if (0 != indexOfPoint) // �����.�����ǵ�һ���ַ�
                        {
                            if (1 == strResult.Length && "��" == strResult.ToString()) // �����������ֻ��'0'
                            {
                                strResult.Remove(0, 1); // ȥ�����㡱
                            }
                            else
                            {
                                strResult.Append('Բ');
                            }
                        }
                    }
                    else
                    {
                        strResult.Append('��');
                    }

                    string strTmp = ConvertFractional(strDigit.Substring(indexOfPoint + 1), bToRMB);

                    if (0 != strTmp.Length) // С�������з���ֵ
                    {
                        if (bToRMB && // ���ת��Ϊ�����
                        0 == strResult.Length && // ��û����������
                        "��" == strTmp.Substring(0, 1)) // �ҷ����ִ��ĵ�һ���ַ��ǡ��㡱
                        {
                            strResult.Append(strTmp.Substring(1));
                        }
                        else
                        {
                            strResult.Append(strTmp);
                        }
                    }

                    if (bToRMB)
                    {
                        if (0 == strResult.Length) // �������ַ���ʲôҲû��
                        {
                            strResult.Append("��Բ��");
                        }
                        // �������ַ��������"Բ"��β
                        else if ("Բ" == strResult.ToString().Substring(strResult.Length - 1, 1))
                        {
                            strResult.Append('��');
                        }
                    }
                }
                else if (bToRMB) // ���"."�����һ���ַ�����ת���������
                {
                    strResult.Append("Բ��");
                }
            }
        }
        
        /// <summary>
        /// �������������Ч��
        /// </summary>
        /// <param name="strDigit">�����ַ���</param>
        /// <param name="bToRMB">�Ƿ�ת���������</param>
        /// <returns>true/false</returns>
        private bool CheckDigit(ref string strDigit, bool bToRMB)
        {
            bool isValidate = false;
            decimal maxVal = 10000000000000000m;
            decimal minVal = -10000000000000000m;

            decimal dec = 0;
            try
            {
                dec = decimal.Parse(strDigit);
                isValidate = true;
            }
            catch (FormatException)
            {
                throw new Exception("�������ֵĸ�ʽ����ȷ��");                
            }

            if (bToRMB) // ���ת���������
            {
                if (dec >= maxVal)
                {
                    throw new Exception("��������̫�󣬳�����Χ��");                    
                }
                else if (dec < 0)
                {
                    throw new Exception("�����������Ϊ��ֵ��");
                }
            }
            else   // ���ת�������Ĵ�д
            {
                if (dec <= maxVal || dec >= maxVal)
                {
                    throw new Exception("��������̫���̫С��������Χ��");                    
                }
                else
                {
                    isValidate = true;
                }
            }

            return isValidate;
        }

        //
        // ��ȡ�����ַ����ķ���
        //
        protected void ExtractSign(ref StringBuilder strResult, ref string strDigit, bool bToRMB)
        {
            // '+'����ǰ
            if ("+" == strDigit.Substring(0, 1))
            {
                strDigit = strDigit.Substring(1);
            }
            // '-'����ǰ
            else if ("-" == strDigit.Substring(0, 1))
            {
                if (!bToRMB)
                {
                    strResult.Append('��');
                }
                strDigit = strDigit.Substring(1);
            }
            // '+'�����
            else if ("+" == strDigit.Substring(strDigit.Length - 1, 1))
            {
                strDigit = strDigit.Substring(0, strDigit.Length - 1);
            }
            // '-'�����
            else if ("-" == strDigit.Substring(strDigit.Length - 1, 1))
            {
                if (!bToRMB)
                {
                    strResult.Append('��');
                }
                strDigit = strDigit.Substring(0, strDigit.Length - 1);
            }
        }

        //
        // ת����������
        //
        protected string ConvertIntegral(string strIntegral, bool bToRMB)
        {
            // ȥ������ǰ�����е�'0'
            // �������ַָ�ַ�������
            char[] integral = ((long.Parse(strIntegral)).ToString()).ToCharArray();

            // �������ַ���
            StringBuilder strInt = new StringBuilder();

            int digit;
            digit = integral.Length - 1;

            // ʹ����ȷ������
            char[] chnText = bToRMB ? chnRMBText : chnGenText;
            char[] chnDigit = bToRMB ? chnRMBDigit : chnGenDigit;

            // ����������ֲ����������λ
            // �������λ��ʮλ����������
            int i;
            for (i = 0; i < integral.Length - 1; i++)
            {
                // �������
                strInt.Append(chnText[integral[i] - '0']);

                // �����λ
                if (0 == digit % 4)     // '��' �� '��'
                {
                    if (4 == digit || 12 == digit)
                    {
                        strInt.Append(chnDigit[3]); // '��'
                    }
                    else if (8 == digit)
                    {
                        strInt.Append(chnDigit[4]); // '��'
                    }
                }
                else         // 'ʮ'��'��'��'ǧ'
                {
                    strInt.Append(chnDigit[digit % 4 - 1]);
                }

                digit--;
            }

            // �����λ������'0'
            // ����ֻ��һλ��
            // �������Ӧ����������
            if ('0' != integral[integral.Length - 1] || 1 == integral.Length)
            {
                strInt.Append(chnText[integral[i] - '0']);
            }


            // ���������ַ���
            i = 0;
            string strTemp; // ��ʱ�洢�ַ���
            int j;    // ���ҡ���x���ṹʱ��
            bool bDoSomething; // �ҵ������򡱻����ڡ�ʱΪ��

            while (i < strInt.Length)
            {
                j = i;

                bDoSomething = false;

                // �������������ġ���x���ṹ
                while (j < strInt.Length - 1 && "��" == strInt.ToString().Substring(j, 1))
                {
                    strTemp = strInt.ToString().Substring(j + 1, 1);

                    // ����ǡ����򡱻��ߡ����ڡ���ֹͣ����
                    if (chnDigit[3].ToString() /* ����f */ == strTemp ||
                     chnDigit[4].ToString() /* �ڻ�| */ == strTemp)
                    {
                        bDoSomething = true;
                        break;
                    }

                    j += 2;
                }

                if (j != i) // ����ҵ��ǡ����򡱻��ߡ����ڡ��ġ���x���ṹ����ȫ��ɾ��
                {
                    strInt = strInt.Remove(i, j - i);

                    // ��������β��������治��"����"��"����"�������, 
                    // ������������һ�����㡱
                    if (i <= strInt.Length - 1 && !bDoSomething)
                    {
                        strInt = strInt.Insert(i, '��');
                        i++;
                    }
                }

                if (bDoSomething) // ����ҵ�"����"��"����"�ṹ
                {
                    strInt = strInt.Remove(i, 1); // ȥ��'��'
                    i++;
                    continue;
                }

                // ָ��ÿ�ο��ƶ�2λ
                i += 2;
            }

            // ���������򡱱�ɡ����㡱��"��"
            strTemp = chnDigit[4].ToString() + chnDigit[3].ToString(); // �����ַ��������򡱻򡰃|�f��
            int index = strInt.ToString().IndexOf(strTemp);
            if (-1 != index)
            {
                if (strInt.Length - 2 != index && // ���"����"����ĩβ
                 (index + 2 < strInt.Length
                  && "��" != strInt.ToString().Substring(index + 2, 1))) // �������û��"��"
                {
                    strInt = strInt.Replace(strTemp, chnDigit[4].ToString(), index, 2); // �䡰����Ϊ�����㡱
                    strInt = strInt.Insert(index + 1, "��");
                }
                else // �����������ĩβ��������Ѿ��С��㡱
                {
                    strInt = strInt.Replace(strTemp, chnDigit[4].ToString(), index, 2); // �䡰����Ϊ���ڡ�
                }
            }

            if (!bToRMB) // ���ת��Ϊһ�����Ĵ�д
            {
                // ��ͷΪ��һʮ����Ϊ��ʮ��
                if (strInt.Length > 1 && "һʮ" == strInt.ToString().Substring(0, 2))
                {
                    strInt = strInt.Remove(0, 1);
                }
            }

            return strInt.ToString();
        }

        //
        // ת��С������
        //
        protected string ConvertFractional(string strFractional, bool bToRMB)
        {
            char[] fractional = strFractional.ToCharArray();

            StringBuilder strFrac = new StringBuilder();

            // �����������
            int i;
            if (bToRMB) // ���ת��Ϊ�����
            {
                for (i = 0; i < Math.Min(2, fractional.Length); i++)
                {
                    strFrac.Append(chnRMBText[fractional[i] - '0']);
                    strFrac.Append(chnRMBUnit[i]);
                }

                // ��������λ�ǡ���֡���ɾ��
                if ("���" == strFrac.ToString().Substring(strFrac.Length - 2, 2))
                {
                    strFrac.Remove(strFrac.Length - 2, 2);
                }

                // ����ԡ���ǡ���ͷ
                if ("���" == strFrac.ToString().Substring(0, 2))
                {
                    // ���ֻʣ�¡���ǡ�
                    if (2 == strFrac.Length)
                    {
                        strFrac.Remove(0, 2);
                    }
                    else // ������С�x�֡�����ɾ�����ǡ�
                    {
                        strFrac.Remove(1, 1);
                    }
                }
            }
            else // ���ת��Ϊһ�����Ĵ�д
            {
                for (i = 0; i < fractional.Length; i++)
                {
                    strFrac.Append(chnGenText[fractional[i] - '0']);
                }
            }

            return strFrac.ToString();
        }
    }
}
