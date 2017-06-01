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
namespace Kit.Web.Kuser
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int Uid=(Convert.ToInt32(strid));
					ShowInfo(Uid);
				}
			}
		}
		
	private void ShowInfo(int Uid)
	{
		Kit.BLL.Kuser bll=new Kit.BLL.Kuser();
		Kit.Model.Kuser model=bll.GetModel(Uid);
		this.lblUid.Text=model.Uid.ToString();
		this.lblUEmail.Text=model.UEmail;
		this.lblUpwd.Text=model.Upwd;
		this.lblUlang.Text=model.Ulang;
		this.lblUrole.Text=model.Urole;
		this.lblSpare1.Text=model.Spare1;
		this.lblSpare2.Text=model.Spare2;
		this.lblSpare3.Text=model.Spare3;

	}


    }
}
