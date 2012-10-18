/*
版权所有：版权所有(C) 2012
文件名称：IPositionBLL.cs
系统编号：ADSB_SYS001
系统名称：ADSB框架
组件编号：ADSB_CN002
组件名称：基本表
设计作者：自动生成
完成日期：2012-10-16
内容摘要：IPositionBLL接口
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using ADSB.Model;

namespace ADSB.BLL
{
    /// <summary>
    /// 接口名称：IPositionBLL
    /// 完成日期：2012-10-16
    /// 编码作者：自动生成
    /// 内容摘要：包含操作的接口
    /// </summary>    
    public interface IPositionBLL
    {
        #region 自动生成
        object Add(Position model);
        Position GetModel(System.Int32 key);
        void Update(Position model);
        void Delete(Position model);
        bool IsExists(Expression<Func<Position, bool>> condition);
        IList<Position> GetList(Expression<Func<Position, bool>> condition);
        IList<Position> GetList(Expression<Func<Position, bool>> condition, int pageIndex, int pageSize, out int rowCount, out int pageCount);
        #endregion
    }
}