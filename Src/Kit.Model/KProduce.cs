using System;
namespace Kit.Model
{
	/// <summary>
	/// KProduce:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class KProduce
	{
		public KProduce()
		{}
		#region Model
		private int _pid;
		private string _pname;
		private string _pnumber;
		private string _pimg;
		private string _spare1;
		private string _spare2;
		private string _spare3;
		/// <summary>
		/// 产品id
		/// </summary>
		public int Pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string Pname
		{
			set{ _pname=value;}
			get{return _pname;}
		}
		/// <summary>
		/// 产品编码
		/// </summary>
		public string Pnumber
		{
			set{ _pnumber=value;}
			get{return _pnumber;}
		}
		/// <summary>
		/// 产品图片
		/// </summary>
		public string Pimg
		{
			set{ _pimg=value;}
			get{return _pimg;}
		}
		/// <summary>
		/// 产品简要说明
		/// </summary>
		public string Spare1
		{
			set{ _spare1=value;}
			get{return _spare1;}
		}
		/// <summary>
		/// 产品备注2
		/// </summary>
		public string Spare2
		{
			set{ _spare2=value;}
			get{return _spare2;}
		}
		/// <summary>
		/// 产品备注3
		/// </summary>
		public string Spare3
		{
			set{ _spare3=value;}
			get{return _spare3;}
		}
		#endregion Model

	}
}

