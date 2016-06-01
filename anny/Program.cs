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
            LinkedList<string> htmlTags = new LinkedList<string>();
            while (regMatches.Success)
            {
                //htmlTags.AddFirst(regMatches.Value);
                htmlTags.AddFirst("1");
            }
            Console.WriteLine("while end");
            LinkedListNode<string> htmlTagsNode;
            for (htmlTagsNode = htmlTags.First; htmlTagsNode != null; htmlTagsNode = htmlTagsNode.Next)
            {
                Console.WriteLine(htmlTagsNode.Value + "\t");
            }

        }
    }
}
