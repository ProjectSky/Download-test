using System;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GpioJsonClientTest1
{
	class Program
	{
		/* HttpWebRequest webRequest; */

		static void Main( string[] args )
		{
			Program prog = new Program();
			prog.DoIt( url );
			while ( Console.ReadKey().KeyChar != 'q' )
				;
		}


		static void InitiateDownload( string RemoteAddress, string LocalFile, AsyncCompletedEventHandler CompletedCallback, object userToken )
		{
			WebClient wc = new WebClient();
			wc.DownloadFileCompleted += CompletedCallback;
			wc.DownloadFileAsync( new Uri( RemoteAddress ), LocalFile, userToken );
		}


		static void FileDownloadCompleted( object sender, AsyncCompletedEventArgs e )
		{
			Console.ForegroundColor = ConsoleColor.Red;
			if ( e.Error != null )
				Console.WriteLine( "\n文件 {0} 更新失败，请重试！", e.UserState );
			else
				Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine( "\n文件 {0} 更新完成。", e.UserState );
		}


		void DoIt( string url )
		{
			HttpWebRequest httpWebRequest = WebRequest.Create( url ) as HttpWebRequest;

			using ( HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse )
			{
				if ( httpWebResponse.StatusCode != HttpStatusCode.OK )
				{
					throw new Exception( string.Format( "Server error (HTTP {0}: {1}).",
									    httpWebResponse.StatusCode, httpWebResponse.StatusDescription ) );
				}

				Stream stream = httpWebResponse.GetResponseStream();

				DataContractJsonSerializer	dataContractJsonSerializer	= new DataContractJsonSerializer( typeof(InputGpioPort) );
				InputGpioPort			objResponse			= (InputGpioPort) dataContractJsonSerializer.ReadObject( stream );
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine( "所需文件下载中，共计 {0} 个文件，请等待完成。" );
				/* 检查文件是否存在，如不存在则创建新文件，用来处理大小检测异常*/
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close(); /* 创建完毕立即释放文件流，防止文件无法被写入*/
				}
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close();
				}
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close();
				}
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close();
				}
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close();
				}
				if ( File.Exists( @"FileName" ) )
				{
					Console.WriteLine( "\nFileName 已存在，检查更新中，请勿退出。" );
				}else  {
					File.Create( @"FileName" ).Close();
				}

				/* 处理json数据 */
				string	Chinese		= (objResponse).ChineseUrl;
				string	ChineseName	= (objResponse).ChineseName;
				long	ChineseSize	= new FileInfo( "Chinese.pak" ).Length;
				string	ChineseLine	= (objResponse).ChineseSize;
				long	Chineseline1	= long.Parse( ChineseLine );

				string	Fu	= (objResponse).FuUrl;
				string	FuName	= (objResponse).FuName;
				long	Fusize	= new FileInfo( "Frackin' Universe.pak" ).Length;
				string	FuLine	= (objResponse).FuSize;
				long	FuLine1 = long.Parse( FuLine );

				string	Ic	= (objResponse).IcUrl;
				string	IcName	= (objResponse).IcName;
				long	Icsize	= new FileInfo( "Improved Containers.pak" ).Length;
				string	IcLine	= (objResponse).IcSize;
				long	IcLine1 = long.Parse( IcLine );

				string	Cc	= (objResponse).CcUrl;
				string	CcName	= (objResponse).CcName;
				long	CcSize	= new FileInfo( "Custom Collections UI.pak" ).Length;
				string	CcLine	= (objResponse).CcSize;
				long	CcLine1 = long.Parse( CcLine );

				string	Sd	= (objResponse).SdUrl;
				string	SdName	= (objResponse).SdName;
				long	SdSize	= new FileInfo( "Skizot's Dozers.pak" ).Length;
				string	SdLine	= (objResponse).SdSize;
				long	SdLine1 = long.Parse( SdLine );

				string	Tc	= (objResponse).TcUrl;
				string	TcName	= (objResponse).TcName;
				long	TcSize	= new FileInfo( "Trading Cards.pak" ).Length;
				string	TcLine	= (objResponse).TcSize;
				long	TcLine1 = long.Parse( TcLine );

				if ( ChineseSize == Chineseline1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Chinese, (objResponse).ChineseName, FileDownloadCompleted, "Chinese" );
				}
				if ( Fusize == FuLine1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Fu, (objResponse).FuName, FileDownloadCompleted, "FileName" );
				}
				if ( Icsize == IcLine1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Ic, (objResponse).IcName, FileDownloadCompleted, "FileName" );
				}
				if ( CcSize == CcLine1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Cc, (objResponse).CcName, FileDownloadCompleted, "FileName" );
				}
				if ( SdSize == SdLine1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Sd, (objResponse).SdName, FileDownloadCompleted, "FileName" );
				}
				if ( TcSize == TcLine1 )
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine( "\nFileName 无需更新。" );
				}else  {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine( "\nFileName 需要更新，请等待下载完成。" );
					InitiateDownload( Tc, (objResponse).TcName, FileDownloadCompleted, "FileName" );
				}
			}
		}
	}
}

/* 解析json数据 */

[DataContract]
public class InputGpioPort
{
	/* Chinese */
	[DataMember( Name = "ChineseName" )]
	public string ChineseName {
		get; set;
	}

	[DataMember( Name = "ChineseSize" )]
	public string ChineseSize {
		get; set;
	}

	[DataMember( Name = "ChineseUrl" )]
	public string ChineseUrl {
		get; set;
	}

	/* Frackin' Universe */
	[DataMember( Name = "FuName" )]
	public string FuName {
		get; set;
	}

	[DataMember( Name = "FuSize" )]
	public string FuSize {
		get; set;
	}

	[DataMember( Name = "FuUrl" )]
	public string FuUrl {
		get; set;
	}

	/* Improved Containers */
	[DataMember( Name = "IcName" )]
	public string IcName {
		get; set;
	}

	[DataMember( Name = "IcSize" )]
	public string IcSize {
		get; set;
	}

	[DataMember( Name = "IcUrl" )]
	public string IcUrl {
		get; set;
	}

	/* Custom Collections UI */
	[DataMember( Name = "CcName" )]
	public string CcName {
		get; set;
	}

	[DataMember( Name = "CcSize" )]
	public string CcSize {
		get; set;
	}

	[DataMember( Name = "CcUrl" )]
	public string CcUrl {
		get; set;
	}

	/* Skizot's Dozers */
	[DataMember( Name = "SdName" )]
	public string SdName {
		get; set;
	}

	[DataMember( Name = "SdSize" )]
	public string SdSize {
		get; set;
	}

	[DataMember( Name = "SdUrl" )]
	public string SdUrl {
		get; set;
	}

	/* Trading Cards */
	[DataMember( Name = "TcName" )]
	public string TcName {
		get; set;
	}

	[DataMember( Name = "TcSize" )]
	public string TcSize {
		get; set;
	}

	[DataMember( Name = "TcUrl" )]
	public string TcUrl {
		get; set;
	}
}
