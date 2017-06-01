using System;
namespace Kit.Model
{
    /// <summary>
    /// Ksystemset:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Ksystemset
    {
        public Ksystemset()
        { }
        #region Model
        private int _sid;
        private string _stype;
        private string _sname;
        private string _svalue;
        private string _skey1;
        private string _skey2;
        /// <summary>
        /// 
        /// </summary>
        public int Sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Stype
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Svalue
        {
            set { _svalue = value; }
            get { return _svalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Skey1
        {
            set { _skey1 = value; }
            get { return _skey1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Skey2
        {
            set { _skey2 = value; }
            get { return _skey2; }
        }
        #endregion Model

    }
}

