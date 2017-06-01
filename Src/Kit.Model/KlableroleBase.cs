using System;
namespace Kit.Model
{
    /// <summary>
    /// KlableroleBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KlableroleBase
    {
        public KlableroleBase()
        { }
        #region Model
        private int _lid;
        private string _lname;
        private string _lcontent;
        private string _lcontentsate;
        private string _llabletypeid;
        private string _llabletypename;
        private string _llableimg;
        private int _llableloopid;
        private string _Llableloopname;
        private int _lproductid;
        private DateTime _ltime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int Lid
        {
            set { _lid = value; }
            get { return _lid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lname
        {
            set { _lname = value; }
            get { return _lname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lcontent
        {
            set { _lcontent = value; }
            get { return _lcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lcontentsate
        {
            set { _lcontentsate = value; }
            get { return _lcontentsate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Llabletypeid
        {
            set { _llabletypeid = value; }
            get { return _llabletypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Llabletypename
        {
            set { _llabletypename = value; }
            get { return _llabletypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LlableImg
        {
            set { _llableimg = value; }
            get { return _llableimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Llableloopid
        {
            set { _llableloopid = value; }
            get { return _llableloopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Llableloopname
        {
            set { _Llableloopname = value; }
            get { return _Llableloopname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LProductid
        {
            set { _lproductid = value; }
            get { return _lproductid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Ltime
        {
            set { _ltime = value; }
            get { return _ltime; }
        }
        #endregion Model

    }
}

