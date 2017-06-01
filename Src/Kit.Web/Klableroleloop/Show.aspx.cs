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
namespace Kit.Web.Klableroleloop
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
					int Tid=(Convert.ToInt32(strid));
					ShowInfo(Tid);
				}
			}
		}
		
	private void ShowInfo(int Tid)
	{
		Kit.BLL.Klableroleloop bll=new Kit.BLL.Klableroleloop();
		Kit.Model.Klableroleloop model=bll.GetModel(Tid);
		this.lblTid.Text=model.Tid.ToString();
		this.lblLid.Text=model.Lid.ToString();
		this.lblTlooprole.Text=model.Tlooprole;
		this.lblTtime.Text=model.Ttime.ToString();
		this.lblSpare1.Text=model.Spare1;
		this.lblSpare2.Text=model.Spare2;
		this.lblSpare3.Text=model.Spare3;

	}


    }
}
