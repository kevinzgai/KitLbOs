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
namespace Kit.Web.Alllog
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Aid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Aid);
				}
			}
		}
			
	private void ShowInfo(int Aid)
	{
		Kit.BLL.Alllog bll=new Kit.BLL.Alllog();
		Kit.Model.Alllog model=bll.GetModel(Aid);
		this.lblAid.Text=model.Aid.ToString();
		this.txtUid.Text=model.Uid.ToString();
		this.txtAtype.Text=model.Atype;
		this.txtAcontent.Text=model.Acontent;
		this.txtAtime.Text=model.Atime.ToString();
		this.txtAstate.Text=model.Astate;
		this.txtSpare1.Text=model.Spare1;
		this.txtSpare2.Text=model.Spare2;
		this.txtSpare3.Text=model.Spare3;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUid.Text))
			{
				strErr+="Uid格式错误！\\n";	
			}
			if(this.txtAtype.Text.Trim().Length==0)
			{
				strErr+="Atype不能为空！\\n";	
			}
			if(this.txtAcontent.Text.Trim().Length==0)
			{
				strErr+="Acontent不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAtime.Text))
			{
				strErr+="Atime格式错误！\\n";	
			}
			if(this.txtAstate.Text.Trim().Length==0)
			{
				strErr+="Astate不能为空！\\n";	
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
			int Aid=int.Parse(this.lblAid.Text);
			int Uid=int.Parse(this.txtUid.Text);
			string Atype=this.txtAtype.Text;
			string Acontent=this.txtAcontent.Text;
			DateTime Atime=DateTime.Parse(this.txtAtime.Text);
			string Astate=this.txtAstate.Text;
			string Spare1=this.txtSpare1.Text;
			string Spare2=this.txtSpare2.Text;
			string Spare3=this.txtSpare3.Text;


			Kit.Model.Alllog model=new Kit.Model.Alllog();
			model.Aid=Aid;
			model.Uid=Uid;
			model.Atype=Atype;
			model.Acontent=Acontent;
			model.Atime=Atime;
			model.Astate=Astate;
			model.Spare1=Spare1;
			model.Spare2=Spare2;
			model.Spare3=Spare3;

			Kit.BLL.Alllog bll=new Kit.BLL.Alllog();
			bll.Update(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
