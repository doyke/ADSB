using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADSB.Model
{
    public class Dict
    {
        public virtual int DictID { get; set; }
        public virtual string Code { get; set; }
        public virtual string DictName { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool? IsEnable { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string CreateorName { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string LastUpdateByName { get; set; }
    }
}
