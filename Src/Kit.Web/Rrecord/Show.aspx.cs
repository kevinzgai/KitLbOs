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
namespace Kit.Web.Rrecord
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
					int Rid=(Convert.ToInt32(strid));
					ShowInfo(Rid);
				}
			}
		}
		
	private void ShowInfo(int Rid)
	{
		Kit.BLL.Rrecord bll=new Kit.BLL.Rrecord();
		Kit.Model.Rrecord model=bll.GetModel(Rid);
		this.lblRid.Text=model.Rid.ToString();
		this.lblPid.Text=model.Pid.ToString();
		this.lblLid.Text=model.Lid.ToString();
		this.lblRstartnumber.Text=model.Rstartnumber;
		this.lblRendnumber.Text=model.Rendnumber;
		this.lblRprintnum.Text=model.Rprintnum.ToString();
		this.lblRdatetime.Text=model.Rdatetime.ToString();
		this.lblUid.Text=model.Uid.ToString();
		this.lblSpare1.Text=model.Spare1;
		this.lblSpare2.Text=model.Spare2;
		this.lblSpare3.Text=model.Spare3;

	}


    }
}
