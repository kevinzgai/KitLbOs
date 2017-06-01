using System;
namespace Kit.Model
{
	/// <summary>
	/// Kuser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Kuser
	{
		public Kuser()
		{}
		#region Model
		private int _uid;
		private string _uemail;
		private string _upwd;
		private string _ulang;
		private string _urole;
		private string _spare1;
		private string _spare2;
		private string _spare3;
		/// <summary>
		/// 用户唯一标识
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 用户Email
		/// </summary>
		public string UEmail
		{
			set{ _uemail=value;}
			get{return _uemail;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string Upwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ulang
		{
			set{ _ulang=value;}
			get{return _ulang;}
		}
		/// <summary>
		/// A : 只能查看标签记录 B、C： 查看标签记录+添加标签记录
		/// </summary>
		public string Urole
		{
			set{ _urole=value;}
			get{return _urole;}
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

