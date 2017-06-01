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
namespace Kit.Web.Ksystemset
{
    public partial class Show : Page
    {
        public string strid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int Sid = (Convert.ToInt32(strid));
                    ShowInfo(Sid);
                }
            }
        }

        private void ShowInfo(int Sid)
        {
            Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
            Kit.Model.Ksystemset model = bll.GetModel(Sid);
            this.lblSid.Text = model.Sid.ToString();
            this.lblStype.Text = model.Stype;
            this.lblSname.Text = model.Sname;
            this.lblSvalue.Text = model.Svalue;
            this.lblSkey1.Text = model.Skey1;
            this.lblSkey2.Text = model.Skey2;

        }


    }
}
