using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDBInfo.DataMap.ORM.Entity
{
    [Serializable]
    public class hwdbapiEntity: DataEntityBase
    {
        [DataField("id")]
        public int Id { set; get; }

        [DataField("Tableid")]
        public int? Tableid { set; get; }

        [DataField("EnTableName")]
        public string EnTableName { set; get; }

        [DataField("CnTableName")]
        public string CnTableName { set; get; }

        [DataField("Fieldv")]
        public string Fieldv { set; get; }

        [DataField("Type")]
        public string Type { set; get; }

        [DataField("Name")]
        public string Name { set; get; }

        [DataField("Remark")]
        public string Remark { set; get; }

        [DataField("CreateTime")]
        public DateTime? CreateTime { set; get; }

        [DataField("ReviseTime")]
        public DateTime? ReviseTime { set; get; }

        [DataField("IsPass")]
        public int? IsPass { set; get; }

        [DataField("IsDelete")]
        public int? IsDelete { set; get; }

        [DataField("AuditorId")]
        public int? AuditorId { set; get; }

        [DataField("AuditorName")]
        public string AuditorName { set; get; }

        [DataField("AuditorIp")]
        public string AuditorIp { set; get; }

        [DataField("AuditorMac")]
        public string AuditorMac { set; get; }

        [DataField("PassTime")]
        public DateTime? PassTime { set; get; }

        [DataField("SubmitterId")]
        public int? SubmitterId { set; get; }

        [DataField("SubmitterName")]
        public string SubmitterName { set; get; }

        [DataField("SubmitterIp")]
        public string SubmitterIp { set; get; }

        [DataField("SubmitterMac")]
        public string SubmitterMac { set; get; }

        [DataField("SubmitTime")]
        public DateTime? SubmitTime { set; get; }

    }
}
