using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.IO;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kit.WebApp.Lang
{
    public static class LocalizationHelpers
    {
        /// <summary>
        /// 在外边的 Html 中直接使用
        /// </summary>
        /// <param name="htmlhelper"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Lang(this HtmlHelper htmlhelper, string key)
        {
            string FilePath = htmlhelper.ViewContext.HttpContext.Server.MapPath("/") + "Resource\\";
            return GetLangString(htmlhelper.ViewContext.HttpContext, key, FilePath);
        }
        public static string LangOutJsVar(this HtmlHelper htmlhelper, string key)
        {
            string FilePath = htmlhelper.ViewContext.HttpContext.Server.MapPath("/") + "Resource\\";
            string langstr = GetLangString(htmlhelper.ViewContext.HttpContext, key, FilePath);
            return string.Format("var {0} = '{1}'", key, langstr);
        }
        /// <summary>
        /// 在 C# 中使用
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string InnerLang(HttpContextBase httpContext, string key)
        {
            string FilePath = httpContext.Server.MapPath("/") + "Resource\\";
            string str = GetLangString(httpContext, key, FilePath);
            return str.Trim().Length < 1 ? "<b style='color:red'>无效字符</b>" : str;
        }

        private static string GetLangString(HttpContextBase httpContext, string key, string FilePath)
        {
            LangType langtype = LangType.cn;
            if (httpContext.Session["Lang"] != null)
            {
                langtype = (LangType)httpContext.Session["Lang"];
            }
            return LangResourceFileProvider.GetLangString(key, langtype, FilePath);
        }
    }

    public static class LangResourceFileProvider
    {
        public static string GetLangString(string Key, LangType langtype, string FilePath)
        {
            string filename;
            switch (langtype)
            {
                case LangType.cn: filename = "zh-cn.resources"; break;
                case LangType.en: filename = "en-us.resources"; break;
                default: filename = "zh-cn.resources"; break;
            }

            System.Resources.ResourceReader reader = new System.Resources.ResourceReader(FilePath + filename);

            string resourcetype;
            byte[] resourcedata;
            string result = string.Empty;

            try
            {
                reader.GetResourceData(Key, out resourcetype, out resourcedata);
                //去掉第一个字节，无用
                byte[] arr = new byte[resourcedata.Length - 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = resourcedata[i + 1];
                }
                result = System.Text.Encoding.UTF8.GetString(arr);

            }
            catch (Exception ex)
            {
                LogUtil.WriteLog(ex.ToString(),LogUtil.LogType.WinRecord);
            }
            finally
            {
                reader.Close();
            }

            return result;
        }
    }

    public enum LangType
    {
        cn,
        en
    }
    public class LogUtil
    {
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Log\\";

        public enum LogType
        {
            System = 0,
            CheckActivity,                              //活动判断
            WinRecord                                   //中奖记录
        }

        public static void WriteLog(string logMsg)
        {
            WriteLog(logMsg, LogType.System);
        }

        public static void WriteLog(string logMsg, LogType logType)
        {
            if (logMsg != "")
            {
                string filename = "system.log";
                switch (logType)
                {
                    case LogType.System:
                        filename = "system.log";
                        break;
                    case LogType.CheckActivity:
                        filename = "CheckActivity_" + DateTime.Now.ToString("yyyy-MM") + ".log";
                        break;
                    case LogType.WinRecord:
                        filename = "WinRecord_" + DateTime.Now.ToString("yyyy-MM") + ".log";
                        break;
                }

                try
                {
                    if (!Directory.Exists(LogPath))
                    {
                        Directory.CreateDirectory(LogPath);
                    }

                    FileInfo fi = new FileInfo(LogPath + filename);
                    if (!fi.Exists)
                    {
                        using (StreamWriter sw = fi.CreateText())
                        {
                            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "        " + logMsg);
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = fi.AppendText())
                        {
                            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "        " + logMsg);
                            sw.Close();
                        }
                    }
                }
                catch { }
            }
        }
    }
}