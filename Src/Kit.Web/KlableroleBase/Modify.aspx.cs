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
namespace Kit.Web.KlableroleBase
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Lid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Lid);
				}
			}
		}
			
	private void ShowInfo(int Lid)
	{
		Kit.BLL.KlableroleBase bll=new Kit.BLL.KlableroleBase();
		Kit.Model.KlableroleBase model=bll.GetModel(Lid);
		this.lblLid.Text=model.Lid.ToString();
		this.txtLname.Text=model.Lname;
		this.txtLcontent.Text=model.Lcontent;
		this.txtLcontentsate.Text=model.Lcontentsate;
		this.txtLlabletypeid.Text=model.Llabletypeid;
		this.txtLlabletypename.Text=model.Llabletypename;
		this.txtLlableImg.Text=model.LlableImg;
		this.txtLlableloopid.Text=model.Llableloopid.ToString();
		this.txtLProductid.Text=model.LProductid.ToString();
		this.txtLtime.Text=model.Ltime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtLname.Text.Trim().Length==0)
			{
				strErr+="Lname不能为空！\\n";	
			}
			if(this.txtLcontent.Text.Trim().Length==0)
			{
				strErr+="Lcontent不能为空！\\n";	
			}
			if(this.txtLcontentsate.Text.Trim().Length==0)
			{
				strErr+="Lcontentsate不能为空！\\n";	
			}
			if(this.txtLlabletypeid.Text.Trim().Length==0)
			{
				strErr+="Llabletypeid不能为空！\\n";	
			}
			if(this.txtLlabletypename.Text.Trim().Length==0)
			{
				strErr+="Llabletypename不能为空！\\n";	
			}
			if(this.txtLlableImg.Text.Trim().Length==0)
			{
				strErr+="LlableImg不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtLlableloopid.Text))
			{
				strErr+="循环规则表id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLProductid.Text))
			{
				strErr+="LProductid格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLtime.Text))
			{
				strErr+="Ltime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Lid=int.Parse(this.lblLid.Text);
			string Lname=this.txtLname.Text;
			string Lcontent=this.txtLcontent.Text;
			string Lcontentsate=this.txtLcontentsate.Text;
			string Llabletypeid=this.txtLlabletypeid.Text;
			string Llabletypename=this.txtLlabletypename.Text;
			string LlableImg=this.txtLlableImg.Text;
			int Llableloopid=int.Parse(this.txtLlableloopid.Text);
			int LProductid=int.Parse(this.txtLProductid.Text);
			DateTime Ltime=DateTime.Parse(this.txtLtime.Text);


			Kit.Model.KlableroleBase model=new Kit.Model.KlableroleBase();
			model.Lid=Lid;
			model.Lname=Lname;
			model.Lcontent=Lcontent;
			model.Lcontentsate=Lcontentsate;
			model.Llabletypeid=Llabletypeid;
			model.Llabletypename=Llabletypename;
			model.LlableImg=LlableImg;
			model.Llableloopid=Llableloopid;
			model.LProductid=LProductid;
			model.Ltime=Ltime;

			Kit.BLL.KlableroleBase bll=new Kit.BLL.KlableroleBase();
			bll.Update(model);
			Kit.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
