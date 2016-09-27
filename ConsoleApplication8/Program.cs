using System;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("所需文件下载中，共计 3 个文件，请等待完成。");
            if (File.Exists(@"Chinese.pak"))
            {
                Console.WriteLine("\nStarbound汉化补丁 已存在，检查更新中，请勿退出。");
            }
            else
            {
                File.Create(@"Chinese.pak").Close();
            }
            if (File.Exists(@"Fu.pak"))
            {
                Console.WriteLine("\n富兰克林的宇宙 已存在，检查更新中，请勿退出。");
            }
            else
            {
                File.Create(@"Fu.pak").Close();
            }
            /* 读取data指定行. */
            string Chinese      = File.ReadAllLines(@"data", Encoding.UTF8)[0];
            string Fu           = File.ReadAllLines(@"data", Encoding.UTF8)[1];
            string dataLine     = File.ReadAllLines(@"data", Encoding.UTF8)[7];
            string ChineseLine  = File.ReadAllLines(@"data", Encoding.UTF8)[8];
            string FuLine       = File.ReadAllLines(@"data", Encoding.UTF8)[9];
            /* 读取文件大小（字节） */
            long Chinesesize    = new FileInfo("Chinese.pak").Length;
            long Fusize         = new FileInfo("Fu.pak").Length;
            long datasize       = new FileInfo("data").Length;
            /* 将 staring 转换为 long */
            long Chineseline1   = long.Parse(ChineseLine);
            long FuLine1        = long.Parse(FuLine);
            long dataLine1      = long.Parse(dataLine);
            /* long data = new FileInfo("data").Length; */
            if (Chinesesize == Chineseline1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStarbound汉化补丁 无需更新。");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nStarbound汉化补丁 需要更新，请等待下载完成。");
                InitiateDownload(Chinese, @"Chinese.pak", FileDownloadCompleted, "Starbound汉化补丁");
            }
            if (Fusize == FuLine1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n富兰克林的宇宙 无需更新。");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n富兰克林的宇宙 需要更新，请等待下载完成。");
                InitiateDownload(Fu, @"Fu.pak", FileDownloadCompleted, "富兰克林的宇宙");
            }
            if (datasize == dataLine1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n下载源 无需更新。");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n下载源 需要更新，请等待下载完成。");
                InitiateDownload("https://resource.zomboid.cn/other/data", @"data", FileDownloadCompleted, "下载源");
            }
            while (Console.ReadKey().KeyChar != 'q')
                ;
        }


        static void InitiateDownload(string RemoteAddress, string LocalFile, AsyncCompletedEventHandler CompletedCallback, object userToken)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += CompletedCallback;
            wc.DownloadFileAsync(new Uri(RemoteAddress), LocalFile, userToken);
        }


        static void FileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string dataLine     = File.ReadAllLines(@"data", Encoding.UTF8)[7];
            string ChineseLine  = File.ReadAllLines(@"data", Encoding.UTF8)[8];
            string FuLine       = File.ReadAllLines(@"data", Encoding.UTF8)[9];
            long Chineseline1   = long.Parse(ChineseLine);
            long FuLine1        = long.Parse(FuLine);
            long dataLine1      = long.Parse(dataLine);
            /* 获取文件大小 */
            long Chinese = new FileInfo("Chinese.pak").Length;
            long Fu = new FileInfo("Fu.pak").Length;
            long data = new FileInfo("data").Length;
            /* 判断文件大小是否正确，如正确，提示成功，否则失败。 */
            Console.ForegroundColor = ConsoleColor.Red;
            if (e.Error != null)
                Console.WriteLine("\n文件 {0} 更新失败，请重试！", e.UserState);
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n文件 {0} 更新完成。", e.UserState);
        }
    }
}
