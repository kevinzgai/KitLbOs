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
namespace Kit.Web.Kuser
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUEmail.Text.Trim().Length==0)
			{
				strErr+="用户Email不能为空！\\n";	
			}
			if(this.txtUpwd.Text.Trim().Length==0)
			{
				strErr+="用户密码不能为空！\\n";	
			}
			if(this.txtUlang.Text.Trim().Length==0)
			{
				strErr+="Ulang不能为空！\\n";	
			}
			if(this.txtUrole.Text.Trim().Length==0)
			{
				strErr+="Urole不能为空！\\n";	
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
			string UEmail=this.txtUEmail.Text;
			string Upwd=this.txtUpwd.Text;
			string Ulang=this.txtUlang.Text;
			string Urole=this.txtUrole.Text;
			string Spare1=this.txtSpare1.Text;
			string Spare2=this.txtSpare2.Text;
			string Spare3=this.txtSpare3.Text;

			Kit.Model.Kuser model=new Kit.Model.Kuser();
			model.UEmail=UEmail;
			model.Upwd=Kit.Common.DEncrypt.DESEncrypt.Encrypt(Upwd);
			model.Ulang=Ulang;
			model.Urole=Urole;
			model.Spare1=Spare1;
			model.Spare2=Spare2;
			model.Spare3=Spare3;

			Kit.BLL.Kuser bll=new Kit.BLL.Kuser();
			bll.Add(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
