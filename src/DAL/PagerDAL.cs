using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;


namespace ADSB.DAL
{
    public class PagerDAL
    {
        private const string PAGER_PROCDURE = "P_PAGER";
        private int mRowCount;

        public string Table { get; set; }
        public string Fields { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string StrWhere { get; set; }
        public string OrderField { get; set; }
        public int OrderType { get; set; }
        
        /// <summary>
        /// 返回记录总数
        /// </summary>
        public int RowCount
        {
            get
            {
                return mRowCount;
            }
        }

        public DataSet GetData()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand(PAGER_PROCDURE);

            db.AddInParameter(cmd, "tablename", DbType.String, Table);
            db.AddInParameter(cmd, "strGetFields", DbType.String, Fields);
            db.AddInParameter(cmd, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(cmd, "pageSize", DbType.Int32, PageSize);
            db.AddInParameter(cmd, "strWhere", DbType.String, StrWhere);
            db.AddInParameter(cmd, "strOrder", DbType.String, OrderField);
            db.AddInParameter(cmd, "intOrder", DbType.String, OrderType);
            db.AddOutParameter(cmd, "CountAll", DbType.Int32, 4);

            DataSet dsResult = db.ExecuteDataSet(cmd);
            mRowCount = Convert.ToInt32(cmd.Parameters["@CountAll"].Value);

            return dsResult;
        }
    }
}