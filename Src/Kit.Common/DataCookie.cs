﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Kit.Common
{
    using System.Web;

    public class DataCookie
    {
      

        /// <summary>  
        /// 设置Cookie的值，关闭Session后释放  
        /// </summary>  
        /// <param name="name">名称</param>  
        /// <param name="value">Cookie值</param>  
        /// <param name="response">HttpResponse</param>  
        public static void Set(string name, string value,HttpResponse response)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Values.Add(name, value);
            response.AppendCookie(cookie);
        }



        /// <summary>  
        /// 设置Cookie的值，包含过期时间  
        /// </summary>  
        /// <param name="name">名称</param>  
        /// <param name="value">Cookie值</param>  
        /// <param name="expiredays">过期时间</param>  
        /// <param name="response">HttpResponse</param>  
        public static void Set(string name, string value, DateTime expiredays, HttpResponse response)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = expiredays;
            cookie.Values.Add(name, value);
            response.AppendCookie(cookie);
        }



        /// <summary>  
        /// 获取Cookie值  
        /// </summary>  
        /// <param name="name">名称</param>  
        /// <param name="request">HttpRequest</param>  
        /// <returns>Cookie的值</returns>  
        public static string Get(string name, HttpRequest request)
        {
            if (request.Cookies[name] != null)
            {
                return request.Cookies[name].Values[name];
            }
            else
            {
                return null;
            }
        }



        /// <summary>  
        /// 删除Cookie  
        /// </summary>  
        /// <param name="name">名称</param>  
        /// <param name="response">HttpResponse</param>  
        /// <param name="request">HttpRequest</param>  
        public static void Delete(string name, HttpResponse response, HttpRequest request)
        {
            HttpCookie cookie = request.Cookies[name];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-10);
                response.AppendCookie(cookie);
            }
        }



        /// <summary>  
        /// 修改Cookie的值  
        /// </summary>  
        /// <param name="name">名称</param>  
        /// <param name="value">Cookie值</param>  
        /// <param name="response">HttpResponse</param>  
        /// <param name="request">HttpRequest</param>  
        public static void Modify(string name, string value, HttpResponse response, HttpRequest request)
        {
            HttpCookie cookie = request.Cookies[name];
            if (cookie != null)
            {
                cookie.Values[name] = value;
            }
            response.AppendCookie(cookie);
        }
    }
}
