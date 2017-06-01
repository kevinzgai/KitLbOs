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
namespace Kit.Web.KProduce
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPname.Text.Trim().Length==0)
			{
				strErr+="Pname不能为空！\\n";	
			}
			if(this.txtPnumber.Text.Trim().Length==0)
			{
				strErr+="Pnumber不能为空！\\n";	
			}
			if(this.txtPimg.Text.Trim().Length==0)
			{
				strErr+="Pimg不能为空！\\n";	
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
			string Pname=this.txtPname.Text;
			string Pnumber=this.txtPnumber.Text;
			string Pimg=this.txtPimg.Text;
			string Spare1=this.txtSpare1.Text;
			string Spare2=this.txtSpare2.Text;
			string Spare3=this.txtSpare3.Text;

			Kit.Model.KProduce model=new Kit.Model.KProduce();
			model.Pname=Pname;
			model.Pnumber=Pnumber;
			model.Pimg=Pimg;
			model.Spare1=Spare1;
			model.Spare2=Spare2;
			model.Spare3=Spare3;

			Kit.BLL.KProduce bll=new Kit.BLL.KProduce();
			bll.Add(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
