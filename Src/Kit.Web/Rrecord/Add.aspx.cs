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
namespace Kit.Web.Rrecord
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtPid.Text))
			{
				strErr+="Pid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLid.Text))
			{
				strErr+="Lid格式错误！\\n";	
			}
			if(this.txtRstartnumber.Text.Trim().Length==0)
			{
				strErr+="本次记录开始编号不能为空！\\n";	
			}
			if(this.txtRendnumber.Text.Trim().Length==0)
			{
				strErr+="Rendnumber不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRprintnum.Text))
			{
				strErr+="Rprintnum格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRdatetime.Text))
			{
				strErr+="Rdatetime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUid.Text))
			{
				strErr+="生成标签用户id格式错误！\\n";	
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
			int Pid=int.Parse(this.txtPid.Text);
			int Lid=int.Parse(this.txtLid.Text);
			string Rstartnumber=this.txtRstartnumber.Text;
			string Rendnumber=this.txtRendnumber.Text;
			int Rprintnum=int.Parse(this.txtRprintnum.Text);
			DateTime Rdatetime=DateTime.Parse(this.txtRdatetime.Text);
			int Uid=int.Parse(this.txtUid.Text);
			string Spare1=this.txtSpare1.Text;
			string Spare2=this.txtSpare2.Text;
			string Spare3=this.txtSpare3.Text;

			Kit.Model.Rrecord model=new Kit.Model.Rrecord();
			model.Pid=Pid;
			model.Lid=Lid;
			model.Rstartnumber=Rstartnumber;
			model.Rendnumber=Rendnumber;
			model.Rprintnum=Rprintnum;
			model.Rdatetime=Rdatetime;
			model.Uid=Uid;
			model.Spare1=Spare1;
			model.Spare2=Spare2;
			model.Spare3=Spare3;

			Kit.BLL.Rrecord bll=new Kit.BLL.Rrecord();
			bll.Add(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
