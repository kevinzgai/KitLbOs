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
namespace Kit.Web.Ksystemset
{
    public partial class Modify : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int Sid = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(Sid);
                }
            }
        }
        private void ShowInfo(int Sid)
        {
            Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
            Kit.Model.Ksystemset model = bll.GetModel(Sid);
            this.lblSid.Text = model.Sid.ToString();
            this.txtStype.Text = model.Stype;
            this.txtSname.Text = model.Sname;
            this.txtSvalue.Text = model.Svalue;
            this.txtSkey1.Text = model.Skey1;
            this.txtSkey2.Text = model.Skey2;

        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtStype.Text.Trim().Length == 0)
            {
                strErr += "Stype不能为空！\\n";
            }
            if (this.txtSname.Text.Trim().Length == 0)
            {
                strErr += "Sname不能为空！\\n";
            }
            if (this.txtSvalue.Text.Trim().Length == 0)
            {
                strErr += "Svalue不能为空！\\n";
            }
            if (this.txtSkey1.Text.Trim().Length == 0)
            {
                strErr += "Skey1不能为空！\\n";
            }
            if (this.txtSkey2.Text.Trim().Length == 0)
            {
                strErr += "Skey2不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int Sid = int.Parse(this.lblSid.Text);
            string Stype = this.txtStype.Text;
            string Sname = this.txtSname.Text;
            string Svalue = this.txtSvalue.Text;
            string Skey1 = this.txtSkey1.Text;
            string Skey2 = this.txtSkey2.Text;


            Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
            model.Sid = Sid;
            model.Stype = Stype;
            model.Sname = Sname;
            model.Svalue = Svalue;
            model.Skey1 = Skey1;
            model.Skey2 = Skey2;

            Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
            bll.Update(model);
            Kit.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
