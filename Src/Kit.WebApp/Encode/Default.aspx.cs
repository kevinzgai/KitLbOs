using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    public string strRqHost = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        Response.Write("<br>-----------MD5加密---------------<br>");
        Response.Write(SDKSecurity.MD5Encrypt("仰天一笑"));

        Response.Write("<br>-----------DES加密---------------<br>");
        Response.Write(SDKSecurity.DESEncrypt("仰天一笑", "anson-xu"));
        Response.Write("<br>-----------DES解密---------------<br>");
        Response.Write(SDKSecurity.DESDecrypt("l06JvJ45r/lb9iKzSXl47Q==", "anson-xu"));

        Response.Write("<br>-----------AES加密---------------<br>");
        Response.Write(SDKSecurity.AESEncrypt("仰天一笑", "ansonxuyu"));
        Response.Write("<br>-----------AES解密---------------<br>");
        Response.Write(SDKSecurity.AESDecrypt("avwKL+MO8+zoLHvzk0+TBA==", "ansonxuyu"));

        Response.Write("<br/><i>---------------------------------------</i><br/>");*/
        strRqHost=Request.ServerVariables["HTTP_HOST"].ToString();
        //Response.Write(strRqHost);
        string key="中文密码";
        string str =Request.QueryString[0];
        string login = Request.QueryString[2];
        if (Request.QueryString[1] != "0") 
        {
            Response.Write("解密");
           // Response.Write(SDKSecurity.AESDecrypt(str.Split(',')[1].ToString(), key));
            string[] strs = SDKSecurity.AESDecrypt(str,key).Split(',');
            Response.Write(strs[0] + "/" + strs[1]);
        }
        else{
            Response.Write("加密");
            strRqHost = SDKSecurity.AESEncrypt(str + "," + login, "中文密码");
            Response.Write(strRqHost);
        }
     
    }
}
