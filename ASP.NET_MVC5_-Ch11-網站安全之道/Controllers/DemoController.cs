using ASP.NET_MVC5__Ch11_網站安全之道.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5__Ch11_網站安全之道.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoLength()
        {
            return View();
        }

        //合適用 AJAX
        public string LengthCheck(string pw)
        {
            if(Request.IsAjaxRequest())
            {
                bool status = PasswordUtility.PasswordLength(pw);
                string result = status ? "通過" : "不通過";
                return result;
            }
            else
            {
                return "非 AJAX 請求 !";
            }
            //前端需搭配 
            //   <script src="~/Scripts/jquery.unobtrusive-ajax.min.js"></script>
        }

        //AES
        public  ActionResult DemoAES()
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            ViewBag.result1 = PasswordUtility.AESEncryptor("ASP.NET MVC 5", aes.Key, aes.IV);

            ViewBag.result2 = PasswordUtility.AESEncryptor(ViewBag.result1.ToString(), aes.Key, aes.IV);

            return View();
        }
    }
}