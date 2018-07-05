using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace 一些测试代码
{
    class Program
    {
        private static string basUrl = "https://www.meet99.com";

        static void Main(string[] args)
        {

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Type", typeof(int));
            //dt.Columns.Add("MainNo", typeof(string));
            //dt.Columns.Add("SubNo", typeof(string));


            //List<TestEntity> entities = new List<TestEntity> { new TestEntity{ Type = 1, MainNo = "1", SubNo = "11" },
            //                                                   new TestEntity { Type = 1, MainNo = "1", SubNo = "12"},
            //                                                   new TestEntity { Type = 1, MainNo = "2", SubNo = "21"},
            //                                                   new TestEntity { Type = 1, MainNo = "2", SubNo = "22"},
            //                                                   new TestEntity { Type = 1, MainNo = "3", SubNo = "31"},
            //                                                   new TestEntity { Type = 1, MainNo = "3", SubNo = "32"},
            //                                                   new TestEntity { Type = 2, MainNo = "1", SubNo = "11"},
            //                                                   new TestEntity { Type = 2, MainNo = "1", SubNo = "12"},
            //                                                   new TestEntity { Type = 2, MainNo = "2", SubNo = "21"},
            //                                                   new TestEntity { Type = 2, MainNo = "2", SubNo = "22"},
            //                                                   new TestEntity { Type = 2, MainNo = "3", SubNo = "31"},
            //                                                   new TestEntity { Type = 2, MainNo = "3", SubNo = "32"}

            //};

            //foreach(var ent in entities)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Type"] = ent.Type;
            //    dr["MainNo"] = ent.MainNo;
            //    dr["SubNo"] = ent.SubNo;
            //    dt.Rows.Add(dr);
            //}

            //DataRow[] drs = dt.Select("Type = 2");
            //List<string> deleteNos = new List<string>() { "1", "2" };
            //foreach (var no in deleteNos)
            //{
            //    var drRemoves = from dr in drs
            //                    where dr["MainNo"].ToString() == no
            //                    select dr;
            //    foreach (DataRow drRemove in drRemoves)
            //        drRemove.d
            //}

            //Console.WriteLine(drs.Length);
            //Console.ReadKey();

            //WebClient wc = new WebClient();
            //wc.Encoding = Encoding.UTF8;

            //var html = wc.DownloadString("https://www.meet99.com/map-beijing.html");

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.meet99.com/map-beijing.html");
            //HttpWebResponse response =  (HttpWebResponse)request.GetResponse();
            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (StreamReader sr = new StreamReader(stream))
            //    {
            //        var html = sr.ReadToEnd();
            //    }
            //}


            //    HtmlConvent<Area> convertor = ConvertHtmlToAreas;


            //ExtractData ed = new ExtractData();
            //ed.Extract<Area>(basUrl  + "/map", convertor);

            //Regex reg = new Regex(@"result=(-?\d+)");
            //if(reg.Matches("result=0&msgid=12343545465675").Count > 0)
            //{
            //    Console.WriteLine(reg.Matches("result=0&msgid=12343545465675")[1].Value);


            //}

            //DataTable dt = new DataTable();
            //dt.Columns.Add("num", typeof(int));
            //for(int i = 0; i < 10; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["num"] = i + 1;
            //    dt.Rows.Add(dr);
            //}

            //foreach(DataRow dr in dt.Rows)
            //{
            //    dt.Rows.Remove(dr);
            //}

            //SerialPort sp = new SerialPort("COM2", 9600);


            ////SerialPort sp2 = new SerialPort("COM3", 9600);
            ////Console.WriteLine(sp2.IsOpen);
            ////try
            ////{
            ////    sp2.Open();
            ////}catch(Exception ex)
            ////{
            ////    Console.WriteLine(ex.Message);
            ////}
            //if (!sp.IsOpen)
            //{
            //    sp.Open();
            //    //sp2.Open();
            //}
            //for (int i = 0; i < 10; i++)
            //{
            //    sp.WriteLine("hello world" + i);
            //    Thread.Sleep(3000);
            //}

            ////if (sp2.BytesToRead > 0)
            ////{
            ////    var line = sp2.ReadLine();
            ////    Console.WriteLine(line + "aa");
            ////}
            //sp.Close();
            ////sp2.Close();
            //Console.WriteLine("结束");

            ITopLogger logger = DefaultTopLogger.GetDefault();
            logger.Error("123");
            Console.ReadKey();

        }

        public static IEnumerable<Area> ConvertHtmlToAreas(string html, int level = 1)
        {
            var reg = new Regex("<ul id=\"treemenu\">.*</ul>");
            Match m = reg.Match(html);
            var tempHtml = m.Groups[0].Value;
            reg = new Regex("<a href=\"(/map-[a-z]+.html)\">([\u4e00-\u9fa5]+)</a>", RegexOptions.CultureInvariant | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(tempHtml);
            List<Area> areas = new List<Area>();
            foreach(Match mi in mc)
            {
                if (areas.Count > 0)
                {
                    var area = (from a in areas
                                where a.AreaName == mi.Groups[2].Value
                                select a).First();
                    if (area != null)
                    {
                        areas.Add(new Area { AreaName = mi.Groups[2].Value, Level = level });
                        var url = basUrl + mi.Groups[1].Value;
                        WebClient wc = new WebClient();
                        wc.Encoding = Encoding.UTF8;
                        ConvertHtmlToAreas(wc.DownloadString(url), level + 1);
                    }
                }
                else
                {
                    if(mi.Groups[2].Value != "其他国家和地区")
                    {
                        areas.Add(new Area { AreaName = mi.Groups[2].Value, Level = level });
                        var url = basUrl + mi.Groups[1].Value;
                        using (WebClient wc = new WebClient())
                        {
                            wc.Encoding = Encoding.UTF8;
                            ConvertHtmlToAreas(wc.DownloadString(url), level + 1);
                        }
                    }
                }
                
            }
            
            return areas;
        }
    }

    

    public delegate IEnumerable<T> HtmlConvent<T>(string html, int level);

    class TestEntity
    {
        public int Type { get; set; }

        public string MainNo { get; set; }

        public string SubNo { get; set; }
    }
}
