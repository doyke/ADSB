using System; 
using System.Runtime.InteropServices;

namespace ADSL.Common
{

    #region how use this?
    /* 
string sVol = getvol.GetVolOf("C"); 
*/
    #endregion

    public class SystemVolumn
    {

        [DllImport("kernel32.dll")]
        private static extern int GetVolumeInformation(
            string lpRootPathName,
            string lpVolumeNameBuffer,
            int nVolumeNameSize,
            ref int lpVolumeSerialNumber,
            int lpMaximumComponentLength,
            int lpFileSystemFlags,
            string lpFileSystemNameBuffer,
            int nFileSystemNameSize
        );

        public static string GetVolOf(string drvID)
        {
            const int MAX_FILENAME_LEN = 256;
            int retVal = 0;
            int a = 0;
            int b = 0;
            string str1 = null;
            string str2 = null;
            
            int i = GetVolumeInformation(
            drvID + @":\",
            str1,
            MAX_FILENAME_LEN,
            ref retVal,
            a,
            b,
            str2,
            MAX_FILENAME_LEN
            );

            return retVal.ToString("x");
        }
    }
}
