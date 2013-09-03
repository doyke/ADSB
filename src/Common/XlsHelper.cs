using System;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace LComponent.Excel
{
    public class XlsHelper
    {
        /// <summary>
        /// Excel数据源文件
        /// </summary>
        public string ExcelFile { get; set; }

        /// <summary>
        /// Excel第一张表的表名
        /// </summary>
        public string  FirstSheetName 
        { 
            get
            {
                string[] sheets = this.GetExcelSheetNames();

                if (sheets != null && sheets.Length > 0)
                {
                    return sheets[0];
                }

                return null;
            }
        }

        /// <summary>
        /// This mehtod retrieves the excel sheet names from 
        /// an excel workbook.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns>String[]</returns>
        public String[] GetExcelSheetNames()
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + ExcelFile + ";Extended Properties=Excel 8.0;";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);

                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }

                return excelSheets;
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }

        }

        /// <summary>
        /// get the sheet data
        /// </summary>
        /// <param name="tableName">excel sheet name</param>
        /// <returns>data</returns>
        public DataTable GetSheet(string sheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.ExcelFile + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection con = new OleDbConnection(strConn))
            {
                string oledbText;                
                OleDbDataAdapter oledbDta;
                DataTable dtSheet = new DataTable();

                oledbText = "select * from [" + sheetName + "]";

                try
                {
                    oledbDta = new OleDbDataAdapter(oledbText, con);
                    oledbDta.Fill(dtSheet);
                }
                catch
                {
                    return null;
                }

                return dtSheet;
            }
        }

        /// <summary>
        /// get the sheet data
        /// </summary>
        /// <param name="sheetName">表名</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页数据大小</param>
        /// <returns>data</returns>
        public DataTable GetPagingData(string sheetName, int page,int pageSize)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.ExcelFile + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection con = new OleDbConnection(strConn))
            {
                string oledbText;
                OleDbDataAdapter oledbDta;
                DataTable dtSheet = new DataTable();
                int startRowNum = (page - 1) * pageSize;
                int endRowNum = startRowNum + pageSize;

                startRowNum = startRowNum + 1;
                oledbText = "select * from [" + sheetName + "]";
                oledbText += string.Format("where RowNum>={0} AND RowNum<={1}", startRowNum, endRowNum);

                try
                {
                    oledbDta = new OleDbDataAdapter(oledbText, con);
                    oledbDta.Fill(dtSheet);
                }
                catch
                {
                    return null;
                }

                return dtSheet;
            }
        }

        /// <summary>
        /// 获取表格数据总行数
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public int GetTableRowCount(string sheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.ExcelFile + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection con = new OleDbConnection(strConn))
            {
                string oledbText;                
                DataTable dtSheet = new DataTable();

                oledbText = "select count(*) from [" + sheetName + "]";

                try
                {
                    OleDbCommand cmd = new OleDbCommand(oledbText, con);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    object objCount = cmd.ExecuteScalar();
                    int rowCount = 0;

                    int.TryParse(objCount.ToString(), out rowCount);

                    return rowCount;
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 获取表格数据总行数
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public int GetTableRowCount(string sheetName, string strWhere)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.ExcelFile + ";Extended Properties=Excel 8.0;";
            using (OleDbConnection con = new OleDbConnection(strConn))
            {
                string oledbText;
                DataTable dtSheet = new DataTable();

                oledbText = "select count(*) from [" + sheetName + "] ";

                if (!string.IsNullOrEmpty(strWhere))
                {
                    oledbText += string.Format(" where {0} ", strWhere);
                }

                try
                {
                    OleDbCommand cmd = new OleDbCommand(oledbText, con);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    object objCount = cmd.ExecuteScalar();
                    int rowCount = 0;

                    int.TryParse(objCount.ToString(), out rowCount);

                    return rowCount;
                }
                catch
                {
                    return 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 将数据写入Excel
        /// </summary>
        /// <param name="dt">要写入的数据</param>
        /// <param name="newXls">已建空白Excel的位置</param>
        /// <returns></returns>
        public bool Write(DataTable dt,string newXls)
        {            
            int rows = dt.Rows.Count;
            int columns = dt.Columns.Count;
            string connString;
            StringBuilder sb = new StringBuilder();

            if (File.Exists(newXls))
            {
                try
                {
                    File.Delete(newXls);
                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + newXls + ";Extended Properties=Excel 8.0;";
            sb.Append("CREATE TABLE [");
            sb.Append(dt.TableName + "1] ( ");

            for (int i = 0; i < columns; i++)
            {
                if (i < columns - 1)
                    sb.Append(string.Format("{0} varchar,", dt.Columns[i].ColumnName));
                else
                    sb.Append(string.Format("{0} varchar)", dt.Columns[i].ColumnName));
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                #region
                try
                {
                    conn.Open();                    
                    cmd.CommandText = sb.ToString();
                    cmd.ExecuteNonQuery();


                    //生成插入数据脚本生成插入数据脚本
                    sb.Remove(0, sb.Length);
                    sb.Append("INSERT INTO [");
                    sb.Append(dt.TableName + "1] ( ");

                    for (int i = 0; i < columns; i++)
                    {
                        if (i < columns - 1)
                            sb.Append(dt.Columns[i].ColumnName + ",");
                        else
                            sb.Append(dt.Columns[i].ColumnName + ") values (");
                    }

                    for (int i = 0; i < columns; i++)
                    {
                        if (i < columns - 1)
                            sb.Append("@" + dt.Columns[i].ColumnName + ",");
                        else
                            sb.Append("@" + dt.Columns[i].ColumnName + ")");
                    }

                    OleDbParameterCollection paras = cmd.Parameters;

                    //插入参数信息
                    for (int i = 0; i < columns; i++)
                    {
                        paras.Add(new OleDbParameter("@" + dt.Columns[i].ColumnName, OleDbType.VarChar));
                    }

                    //遍历DataTable将数据插入新建的Excel文件中
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < paras.Count; i++)
                        {
                            paras[i].Value = dr[i];
                        }
                        cmd.CommandText = sb.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (System.Data.Common.DbException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }                
                #endregion
            }            
        }
    }
}