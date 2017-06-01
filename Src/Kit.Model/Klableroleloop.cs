using System;
namespace Kit.Model
{
	/// <summary>
	/// Klableroleloop:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Klableroleloop
	{
		public Klableroleloop()
		{}
		#region Model
		private int _tid;
		private int _lid;
		private string _tlooprole;
		private DateTime _ttime= DateTime.Now;
		private string _spare1;
		private string _spare2;
		private string _spare3;
		/// <summary>
		/// 
		/// </summary>
		public int Tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Lid
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 循环模板 例如：如果是00001，则生成编号从00001-99999之间10000个
		/// </summary>
		public string Tlooprole
		{
			set{ _tlooprole=value;}
			get{return _tlooprole;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Ttime
		{
			set{ _ttime=value;}
			get{return _ttime;}
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

