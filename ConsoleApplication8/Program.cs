using System;
using System.Net;
using System.ComponentModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("所需文件下载中，共计(88.0 MB) 请等待完成！");
            InitiateDownload("http://www.ikoumi.com/yunpan/OckRujLPffGVfe/bfbd.pak", @"Fu.pak", FileDownloadCompleted, "Fu.pak");
            Console.ReadKey();
        }

        static void InitiateDownload(string RemoteAddress, string LocalFile, AsyncCompletedEventHandler CompletedCallback, object userToken)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += CompletedCallback;
            wc.DownloadFileAsync(new Uri(RemoteAddress), LocalFile, userToken);
        }

        static void FileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
                Console.WriteLine("发生错误 {0}: {1}", e.UserState, e.Error);
            else if (e.Cancelled)
                Console.WriteLine("文件 {0} 下载取消.", e.UserState);
            else
                Console.WriteLine("文件{0}下载完成，按任意键退出！", e.UserState);
        }
    }
}