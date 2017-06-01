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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            string Stype = this.txtStype.Text;
            string Sname = this.txtSname.Text;
            string Svalue = this.txtSvalue.Text;
            string Skey1 = this.txtSkey1.Text;
            string Skey2 = this.txtSkey2.Text;

            Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
            model.Stype = Stype;
            model.Sname = Sname;
            model.Svalue = Svalue;
            model.Skey1 = Skey1;
            model.Skey2 = Skey2;

            Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
            bll.Add(model);
            Kit.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
