// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************


using System.IO;
namespace Evo
{
	/// <summary>
	/// 
	/// </summary>
	public class IuFile
	{
		/// <summary>
		/// 
		/// </summary>
		public static bool ExistFile(string pathFile)
		{
			return UFile.getInstance().ExistFile(pathFile);
		}

		/// <summary>
		/// 
		/// </summary>
		public static bool ExistDirectory(string pathFile)
		{
			return UFile.getInstance().ExistDirectory(pathFile);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void CreateDirectory(string path)
		{
			UFile.getInstance().CreateDirectory(path);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void DoDelFileInDirectory(string pathDirectory)
		{
			UFile.getInstance().DoDelFileInDirectory(pathDirectory);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void DoWrite(string pathFile, string text, bool append)
		{
			UFile.getInstance().DoWrite(pathFile, text, append);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void DoWrite(string pathFile, byte[] arrayByte, bool append)
		{
			UFile.getInstance().DoWrite(pathFile, arrayByte, append);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void DoDel(string url)
		{
			UFile.getInstance().DoDel(url);
		}

		/// <summary>
		/// 
		/// </summary>
		public static byte[] DoReadByte(string url)
		{

			return UFile.getInstance().DoReadByte(url);
		}

		/// <summary>
		/// 
		/// </summary>
		public static EFile DoReadEFile(string url)
		{

			return UFile.getInstance().DoReadEFile(url);
		}

		/// <summary>
		/// 
		/// </summary>
		public static EFile DoReadEFileProperty(string url)
		{

			return UFile.getInstance().DoReadEFileProperty(url);
		}

		/// <summary>
		/// 
		/// </summary>
		public static string DoReadText(string path)
		{
			return UFile.getInstance().DoReadText(path);

		}

		/// <summary>
		/// 
		/// </summary>
		public static void CopyAndReplaceDirectory(string srcPath, string dstPath)
		{
			UFile.getInstance().CopyAndReplaceDirectory(srcPath, dstPath);
		}

		/// <summary>
		/// 
		/// </summary>
		public static void CopyDirectory(string srcPath, string dstPath, bool overwrite)
		{
			UFile.getInstance().CopyDirectory(srcPath, dstPath, overwrite);
		}

		/// <summary>
		/// 
		/// </summary>
		public static byte[] DoReadFileStream(Stream fsSource)
		{
			return UFile.getInstance().DoReadFileStream(fsSource);
		}
	}
}