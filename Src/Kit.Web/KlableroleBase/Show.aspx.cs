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
namespace Kit.Web.KlableroleBase
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
					int Lid=(Convert.ToInt32(strid));
					ShowInfo(Lid);
				}
			}
		}
		
	private void ShowInfo(int Lid)
	{
		Kit.BLL.KlableroleBase bll=new Kit.BLL.KlableroleBase();
		Kit.Model.KlableroleBase model=bll.GetModel(Lid);
		this.lblLid.Text=model.Lid.ToString();
		this.lblLname.Text=model.Lname;
		this.lblLcontent.Text=model.Lcontent;
		this.lblLcontentsate.Text=model.Lcontentsate;
		this.lblLlabletypeid.Text=model.Llabletypeid;
		this.lblLlabletypename.Text=model.Llabletypename;
		this.lblLlableImg.Text=model.LlableImg;
		this.lblLlableloopid.Text=model.Llableloopid.ToString();
		this.lblLProductid.Text=model.LProductid.ToString();
		this.lblLtime.Text=model.Ltime.ToString();

	}


    }
}
