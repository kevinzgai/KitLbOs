using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Kit.Common;
using LTP.Accounts.Bus;
namespace Kit.Web.Klableroleloop
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Tid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Tid);
				}
			}
		}
			
	private void ShowInfo(int Tid)
	{
		Kit.BLL.Klableroleloop bll=new Kit.BLL.Klableroleloop();
		Kit.Model.Klableroleloop model=bll.GetModel(Tid);
		this.lblTid.Text=model.Tid.ToString();
		this.txtLid.Text=model.Lid.ToString();
		this.txtTlooprole.Text=model.Tlooprole;
		this.txtTtime.Text=model.Ttime.ToString();
		this.txtSpare1.Text=model.Spare1;
		this.txtSpare2.Text=model.Spare2;
		this.txtSpare3.Text=model.Spare3;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtLid.Text))
			{
				strErr+="Lid格式错误！\\n";	
			}
			if(this.txtTlooprole.Text.Trim().Length==0)
			{
				strErr+="循环模板 例如：如果是00001不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtTtime.Text))
			{
				strErr+="Ttime格式错误！\\n";	
			}
			if(this.txtSpare1.Text.Trim().Length==0)
			{
				strErr+="Spare1不能为空！\\n";	
			}
			if(this.txtSpare2.Text.Trim().Length==0)
			{
				strErr+="Spare2不能为空！\\n";	
			}
			if(this.txtSpare3.Text.Trim().Length==0)
			{
				strErr+="Spare3不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Tid=int.Parse(this.lblTid.Text);
			int Lid=int.Parse(this.txtLid.Text);
			string Tlooprole=this.txtTlooprole.Text;
			DateTime Ttime=DateTime.Parse(this.txtTtime.Text);
			string Spare1=this.txtSpare1.Text;
			string Spare2=this.txtSpare2.Text;
			string Spare3=this.txtSpare3.Text;


			Kit.Model.Klableroleloop model=new Kit.Model.Klableroleloop();
			model.Tid=Tid;
			model.Lid=Lid;
			model.Tlooprole=Tlooprole;
			model.Ttime=Ttime;
			model.Spare1=Spare1;
			model.Spare2=Spare2;
			model.Spare3=Spare3;

			Kit.BLL.Klableroleloop bll=new Kit.BLL.Klableroleloop();
			bll.Update(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
