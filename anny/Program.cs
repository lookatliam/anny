using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace anny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, liam!\n");

            String siteUrl = "http://compaign.ml/liambot";
            HttpWebRequest siteRequest = (HttpWebRequest)HttpWebRequest.Create(siteUrl);

            String proxyAdress = "127.0.0.1";
            int proxyPort = 8888;
            siteRequest.Proxy = new WebProxy(proxyAdress, proxyPort);

            siteRequest.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_3_2 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0";
            siteRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            siteRequest.Headers.Add("Accept-Language", "ru");

            HttpWebResponse siteResponse = (HttpWebResponse)siteRequest.GetResponse();

            StreamReader siteReader = new StreamReader(siteResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
            //Console.WriteLine(siteReader.ReadToEnd());

            String S = siteReader.ReadToEnd();
            String regPattern = @"<.*>";

            Match regMatches = Regex.Match(S, regPattern);
            while (regMatches.Success)
            {
                //Console.WriteLine(regMatches.Value);

                String viewS = regMatches.Value;
                String viewSRegPattern = @"[0-9]";

                Match viewSRegMatches = Regex.Match(viewS, viewSRegPattern);

                while (viewSRegMatches.Success)
                {
                    Console.WriteLine(viewSRegMatches.Value);
                    //regMatches = viewSRegMatches.NextMatch();
                }

                regMatches = regMatches.NextMatch();
            }
        }
    }
}
