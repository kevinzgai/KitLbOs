using System;
namespace Kit.Model
{
	/// <summary>
	/// Alllog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Alllog
	{
		public Alllog()
		{}
		#region Model
		private int _aid;
		private int _uid;
		private string _atype;
		private string _acontent;
		private DateTime? _atime= DateTime.Now;
		private string _astate;
		private string _spare1;
		private string _spare2;
		private string _spare3;
		/// <summary>
		/// 
		/// </summary>
		public int Aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Atype
		{
			set{ _atype=value;}
			get{return _atype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Acontent
		{
			set{ _acontent=value;}
			get{return _acontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Atime
		{
			set{ _atime=value;}
			get{return _atime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Astate
		{
			set{ _astate=value;}
			get{return _astate;}
		}
		/// <summary>
		/// 
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

