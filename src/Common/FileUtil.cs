using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;

namespace ADSL.Common
{
    /// <summary>
    /// 在指定路径下查找图片
    /// 在指定路径下查找指定类型的文件
    /// 读取指定文件
    /// </summary>
    public class FileUtil
    {
        #region 在指定路径下查找图片
        /**/
        /// <summary>
        /// <c>『钙娃儿 封装』</c>
        /// <c>在指定路径下查找图片(只支持查找 gif,jpg,jpeg,png 格式的图片)</c>
        /// <returns><para>返回查找到的图片信息(ArrayList)</para></returns>
        /// </summary>
        /// <summary>
        /// <param name="path">指定需查找图片的路径</param>
        /// </summary>
        public static ArrayList SerchImage(string path)
        {
            ArrayList imgInfo = null;
            try
            {
                imgInfo = new ArrayList();
                DirectoryInfo dirinfo = new DirectoryInfo(path);//打开指定的路径
                if (dirinfo.Exists)//如果路径存在进行相关处理
                {
                    int fileLen = dirinfo.GetFiles().Length;//获取当前目录下所有文件的长度
                    FileInfo[] temp = new FileInfo[fileLen];//存储文件信息的数组
                    temp = dirinfo.GetFiles();
                    string[] filter = { "gif", "jpg", "jpeg", "png" };//文件扩展名数组
                    foreach (FileInfo tempFile in temp)
                    {
                        string filename = tempFile.Name;//取文件名
                        int nLength = filename.Length - (filename.LastIndexOf(".") + 1);//获取扩展名的长度
                        string tempFilter = filename.Substring(filename.LastIndexOf(".") + 1, nLength);//取文件的扩展名
                        foreach (string aa in filter)
                        {
                            if (aa.Equals(tempFilter.ToLower()))//判断文件是否为扩展名数组中的类型
                            {
                                imgInfo.Add(filename);//如果是相同类型则加入列表
                            }
                        }
                    }
                }
            }
            catch
            { }
            return imgInfo;
        }
        #endregion

        #region 在指定路径下查找指定类型的文件
        /**/
        /// <summary>
        /// <c>『钙娃儿 封装』</c>
        /// <c>在指定路径下查找指定类型的文件</c>
        /// <returns><para>返回查找到的文件信息(ArrayList)</para></returns>
        /// </summary>
        /// <summary>
        /// <param name="path">指定需查找文件的路径</param>
        /// <param name="type">指定需查找的文件类型(如："exe")</param>
        /// </summary>
        public static ArrayList SerchFile(string path, string type)
        {
            ArrayList filetype = null;
            try
            {
                filetype = new ArrayList();
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                if (dirinfo.Exists)
                {
                    int fileLen = dirinfo.GetFiles().Length;
                    FileInfo[] temp = new FileInfo[fileLen];
                    temp = dirinfo.GetFiles();
                    string[] filter = { type };
                    foreach (FileInfo tempFile in temp)
                    {
                        string filename = tempFile.Name;
                        int nLength = filename.Length - (filename.LastIndexOf(".") + 1);
                        string tempFilter = filename.Substring(filename.LastIndexOf(".") + 1, nLength);
                        foreach (string aa in filter)
                        {
                            if (aa.Equals(tempFilter.ToLower()))
                            {
                                filetype.Add(filename);
                            }
                        }
                    }
                }
            }
            catch
            { }
            return filetype;
        }
        #endregion

        #region 读取指定文件
        /// <summary>
        /// <param name="filename">指定要读的文件的</param>
        /// </summary>
        public static string ReadFile(string filename)
        {
            string returnValue = "";
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                return sr.ReadToEnd();
            }
            catch (IOException ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 删除指定目录下的所有文件和目录 ,除后缀名为filter的文件
        /// </summary>
        /// <param name="directories">指定目录</param>
        /// <param name="filter">不删除的文件的后缀名</param>
        public static void DeleteDirectoryFile(string directory, string filter)
        {
            FileInfo fileInfo;
            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string dir in subDirectories)
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    try
                    {
                        fileInfo = new FileInfo(file);
                        if (fileInfo.Extension != filter)
                        {
                            fileInfo.Attributes = FileAttributes.Normal;
                            fileInfo.Delete();
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                DeleteDirectoryFile(dir, filter);
            }
            string[] currentDirFiles = Directory.GetFiles(directory);
            foreach (string file in currentDirFiles)
            {
                try
                {
                    fileInfo = new FileInfo(file);
                    if (fileInfo.Extension != filter)
                    {
                        fileInfo.Attributes = FileAttributes.Normal;
                        fileInfo.Delete();
                    }
                }
                catch
                {
                    continue;
                }
            }
            foreach (string dir in subDirectories)
            {
                Directory.Delete(dir);
            }
        }

        public static bool Exists(string file)
        {
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 文件下载
        /// <summary>
        /// 将文件输出到浏览器
        /// </summary>
        /// <param name="_Request">Page.Request</param>
        /// <param name="_HttpResponse">Page.HttpResponse</param>
        /// <param name="_fileName">目的文件名</param>
        /// <param name="_fullPath">源文件路径</param>
        /// <param name="_speed">速度</param>
        /// <returns>TRUE OR FALSE</returns>
        public static bool DownloadFile(HttpRequest _Request, HttpResponse _HttpResponse, string _fileName, string _fullPath, long _speed)
        {
            try
            {
                FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                BinaryReader br = new BinaryReader(myFile);

                //BinaryReader br = new BinaryReader(myFile);

                try
                {
                    _HttpResponse.AddHeader("Accept-Ranges", "bytes");
                    _HttpResponse.Buffer = false;
                    long fileLength = myFile.Length;
                    long startBytes = 0;

                    double pack = 10240; //10K bytes
                    //int sleep = 200;   //每秒5次   即5*10K bytes每秒
                    int sleep = (int)Math.Floor(1000 * pack / _speed) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _HttpResponse.StatusCode = 206;
                        string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                    }
                    _HttpResponse.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                    _HttpResponse.AddHeader("Connection", "Keep-Alive");
                    _HttpResponse.ContentType = "application/octet-stream";
                    _HttpResponse.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = (int)Math.Floor((fileLength - startBytes) / pack) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (_HttpResponse.IsClientConnected)
                        {
                            _HttpResponse.BinaryWrite(br.ReadBytes(int.Parse(pack.ToString())));
                            System.Threading.Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    br.Close();

                    myFile.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="_response">当前页面的Response对象</param>
        /// <param name="filename">文件完整路径</param>
        public static void DownloadFile(HttpResponse _response, string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            _response.Clear();
            _response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileInfo.Name));
            _response.AddHeader("Content-Length", fileInfo.Length.ToString());
            _response.ContentType = "application/octet-stream";
            _response.WriteFile(fileInfo.FullName);
            _response.End();

        }

        /// 
        /// 下载类型
        /// fileexp">文件扩展名
        /// 
        private string checktype(string fileExt)
        {
            string ContentType;
            switch (fileExt)
            {
                case ".asf":
                    ContentType = "video/x-ms-asf"; break;
                case ".avi":
                    ContentType = "video/avi"; break;
                case ".doc":
                    ContentType = "application/msword"; break;
                case ".zip":
                    ContentType = "application/zip"; break;
                case ".xls":
                    ContentType = "application/vnd.ms-excel"; break;
                case ".gif":
                    ContentType = "image/gif"; break;
                case ".jpg":
                    ContentType = "image/jpeg"; break;
                case "jpeg":
                    ContentType = "image/jpeg"; break;
                case ".wav":
                    ContentType = "audio/wav"; break;
                case ".mp3":
                    ContentType = "audio/mpeg3"; break;
                case ".mpg":
                    ContentType = "video/mpeg"; break;
                case ".mepg":
                    ContentType = "video/mpeg"; break;
                case ".rtf":
                    ContentType = "application/rtf"; break;
                case ".html":
                    ContentType = "text/html"; break;
                case ".htm":
                    ContentType = "text/html"; break;
                case ".txt":
                    ContentType = "text/plain"; break;
                default:
                    ContentType = "application/octet-stream";
                    break;
            }
            return ContentType;
        }

        #endregion
    }
}
