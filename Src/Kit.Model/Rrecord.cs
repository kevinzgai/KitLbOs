using System;
namespace Kit.Model
{
	/// <summary>
	/// Rrecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Rrecord
	{
		public Rrecord()
		{}
		#region Model
		private int _rid;
		private int _pid;
		private int _lid;
		private string _rstartnumber;
		private string _rendnumber;
		private int _rprintnum;
		private DateTime _rdatetime= DateTime.Now;
		private int _uid;
		private string _spare1;
		private string _spare2;
		private string _spare3;
        /// <summary>
        /// 
        /// </summary>
        public int Rid
		{
			set{ _rid=value;}
			get{return _rid;}
		}
        /// <summary>
        /// 所属产品id
        /// </summary>
        public int Pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
        /// <summary>
        /// 标签id
        /// </summary>
        public int Lid
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 本次记录开始编号
		/// </summary>
		public string Rstartnumber
		{
			set{ _rstartnumber=value;}
			get{return _rstartnumber;}
		}
        /// <summary>
        /// 本次结束编号
        /// </summary>
        public string Rendnumber
		{
			set{ _rendnumber=value;}
			get{return _rendnumber;}
		}
        /// <summary>
        /// 当前打印标签数量
        /// </summary>
        public int Rprintnum
		{
			set{ _rprintnum=value;}
			get{return _rprintnum;}
		}
        /// <summary>
        /// 生成日期
        /// </summary>
        public DateTime Rdatetime
		{
			set{ _rdatetime=value;}
			get{return _rdatetime;}
		}
		/// <summary>
		/// 生成标签用户id
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
        /// <summary>
        /// 生成标签用户id
        /// </summary>
        public string Spare1
		{
			set{ _spare1=value;}
			get{return _spare1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spare3
		{
			set{ _spare3=value;}
			get{return _spare3;}
		}
		#endregion Model

	}
}

