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
namespace Kit.Web.Alllog
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
					int Aid=(Convert.ToInt32(strid));
					ShowInfo(Aid);
				}
			}
		}
		
	private void ShowInfo(int Aid)
	{
		Kit.BLL.Alllog bll=new Kit.BLL.Alllog();
		Kit.Model.Alllog model=bll.GetModel(Aid);
		this.lblAid.Text=model.Aid.ToString();
		this.lblUid.Text=model.Uid.ToString();
		this.lblAtype.Text=model.Atype;
		this.lblAcontent.Text=model.Acontent;
		this.lblAtime.Text=model.Atime.ToString();
		this.lblAstate.Text=model.Astate;
		this.lblSpare1.Text=model.Spare1;
		this.lblSpare2.Text=model.Spare2;
		this.lblSpare3.Text=model.Spare3;

	}


    }
}
