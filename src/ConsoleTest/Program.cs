using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile("admin", "MD5");

            Console.WriteLine(pwd);
        }
    }
}
