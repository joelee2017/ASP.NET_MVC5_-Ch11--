using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASP.NET_MVC5__Ch11_網站安全之道.Models
{
    public static class SafeHtmleClass
    {
        public static  HtmlString SafeHtml(this HtmlHelper helper,string str)
        {
            var filterString = str == null ? "" : str.Trim();
            if (string.IsNullOrWhiteSpace(filterString)) return null;

            var regex =new Regex(@"<(?!br|\/?p|style|\/?span)[^>]*>");
            filterString = regex.Replace(filterString, "");
            return new HtmlString(filterString);
        }
    }

    public class AntiForgeryExtension : IAntiForgeryAdditionalDataProvider
    {
        public string GetAdditionalData(HttpContextBase context)
        {
            return DateTime.UtcNow.Ticks.ToString();
        }

        public bool ValidateAdditionalData(HttpContextBase context, string additionalData)
        {
            if (string.IsNullOrWhiteSpace(additionalData)) return false;

            //取得表示這個執行個體日期和時間的刻度數目
            var requestTime = Convert.ToInt64(additionalData);
            var now = DateTime.UtcNow.Ticks;
            //TimeSpan 表示時間間隔
            var difference = new TimeSpan(now - requestTime);
            return (difference.TotalMinutes > -1 && difference.TotalMinutes < 10);
            //需在Global 中註冊
        }
    }
}