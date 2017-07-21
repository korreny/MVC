using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetDBInfo.DataMap.ORM.Entity;
namespace GetDBInfo.Model
{
    public class Hwdbapi
    {
        public Hwdbapi()
        { }
        #region Model
        private int _id;
        private int? _tableid;
        private string _entablename;
        private string _cntablename;
        private string _field;
        private string _type;
        private string _name;
        private string _remark;
        private string _createtime;
        private string _revisetime;
        private int? _ispass;
        private int? _isdelete;
        private int? _auditorid;
        private string _auditorname;
        private string _auditorip;
        private string _auditormac;
        private string _passtime;
        private int? _submitterid;
        private string _submittername;
        private string _submitterip;
        private string _submittermac;
        private string _submittime;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tableid
        {
            set { _tableid = value; }
            get { return _tableid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnTableName
        {
            set { _entablename = value; }
            get { return _entablename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CnTableName
        {
            set { _cntablename = value; }
            get { return _cntablename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Field
        {
            set { _field = value; }
            get { return _field; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReviseTime
        {
            set { _revisetime = value; }
            get { return _revisetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsPass
        {
            set { _ispass = value; }
            get { return _ispass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AuditorId
        {
            set { _auditorid = value; }
            get { return _auditorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditorName
        {
            set { _auditorname = value; }
            get { return _auditorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditorIp
        {
            set { _auditorip = value; }
            get { return _auditorip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditorMac
        {
            set { _auditormac = value; }
            get { return _auditormac; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PassTime
        {
            set { _passtime = value; }
            get { return _passtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SubmitterId
        {
            set { _submitterid = value; }
            get { return _submitterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitterName
        {
            set { _submittername = value; }
            get { return _submittername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitterIp
        {
            set { _submitterip = value; }
            get { return _submitterip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitterMac
        {
            set { _submittermac = value; }
            get { return _submittermac; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitTime
        {
            set { _submittime = value; }
            get { return _submittime; }
        }

        public static implicit operator Hwdbapi(GetDBInfo.DataMap.ORM.Entity.hwdbapiEntity v)
        {
            Hwdbapi t = new Hwdbapi();
            t.AuditorId = v.AuditorId;
            t.AuditorIp = v.AuditorIp;
            t.AuditorMac = v.AuditorMac;
            t.AuditorName = v.AuditorName;
            t.CnTableName = v.CnTableName;
            t.CreateTime = v.CreateTime;
            t.EnTableName = v.EnTableName;
            t.Field = v.Fieldv;
            t.Id = v.Id;
            t.IsDelete = v.IsDelete;
            t.IsPass = v.IsPass;
            t.Name = v.Name;
            t.PassTime = v.PassTime;
            t.Remark = v.Remark;
            t.ReviseTime = v.ReviseTime;
            t.SubmitterId = v.SubmitterId;
            t.SubmitterIp = v.SubmitterIp;
            t.SubmitterMac = v.SubmitterMac;
            t.SubmitterName = v.SubmitterName;
            t.SubmitTime = v.SubmitTime;
            t.Tableid = v.Tableid;
            t.Type = v.Type;
            return t;
        }
        #endregion Model

    }
}
