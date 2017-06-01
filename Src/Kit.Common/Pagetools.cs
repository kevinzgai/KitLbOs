using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Kit.Model;

namespace Kit.Common
{
    /// <summary>
    /// 页面常用工具
    /// </summary>
    public class Pagetools
    {

        /*
        就可以通过_session操作Session了。

    本文主要介绍第二种方式，而且是使用类库操作Session的方法。
    1.新建一个类库
    2.添加引用，解决方案资源管理器中，右键“引用”-》“添加引用”-》.net-》选择“System.Web”-》点击“确定”
    3.添加一个类，在类中引用
    using System.Web;
    using System.Web.SessionState;
    4.操作Session，主要涉及添加，获取，清除。其它的如修改、删除也可添加。主要代码如下：
    */
    
        //判断您是否已经登录
        public static bool Islogin()
        {
            try
            {
                if (GetSession("User") != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
                Console.WriteLine(e);
                throw;
            }

        }
        public static void SetSession(string key, object value,System.Web.Mvc.ControllerBase controllerBase)
        {
             _session[key] = value;
        }
        public static int GetSessionNumber(string key)
        {
            int result = 0;
            if (_session[key] != null)
            {
                int.TryParse(_session[key].ToString(), out result);
            }
            return result;
        }
        public static string GetSessionString(string key)
        {
            string result = "";
            if (_session[key] != null)
            {
                result = _session[key].ToString();
            }
            return result;
        }
        public static object GetSession(string key)
        {
            object result=null;
            if (_session[key] != null)
            {
                result = _session[key] as  object;
            }
            return result;
        }
        public static void Clear()
        {
            _session.Clear();
        }
       
    }
}
