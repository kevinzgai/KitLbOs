﻿using System;

namespace Kit.Web.SysManage
{
	/// <summary>
	/// delete 的摘要说明。
	/// </summary>
	public partial class delete : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Kit.BLL.SysManage sm=new Kit.BLL.SysManage();
				string id=Request.Params["id"];
				sm.DelTreeNode(int.Parse(id));				
				Response.Redirect("treelist.aspx");
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}