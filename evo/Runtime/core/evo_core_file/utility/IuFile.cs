using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using System.Text;
namespace Evo
{
	public class IuFile
	{

		public static bool ExistFile(string pathFile)
		{
			return UFile.getInstance().ExistFile(pathFile);
		}

		public static bool ExistDirectory(string pathFile)
		{
			return UFile.getInstance().ExistDirectory(pathFile);
		}

		public static void CreateDirectory(string path)
		{
			UFile.getInstance().CreateDirectory(path);
		}

		public static void DoDelFileInDirectory(string pathDirectory)
		{
			UFile.getInstance().DoDelFileInDirectory(pathDirectory);
		}

		public static void DoWrite(string pathFile, string text, bool append)
		{
			UFile.getInstance().DoWrite(pathFile, text, append);
		}

		public static void DoWrite(string pathFile, byte[] arrayByte, bool append)
		{
			UFile.getInstance().DoWrite(pathFile, arrayByte, append);
		}

		public static string DoRead(string url)
		{
			return UFile.getInstance().DoRead(url);

		}

		public static void DoDel(string url)
		{
			UFile.getInstance().DoDel(url);
		}

		public static byte[] DoReadByte(string url)
		{

			return UFile.getInstance().DoReadByte(url);
		}

		public static EFile DoReadEFile(string url)
		{

			return UFile.getInstance().DoReadEFile(url);
		}

		public static EFile DoReadEFileProperty(string url)
		{

			return UFile.getInstance().DoReadEFileProperty(url);
		}

		public static string DoReadText(string path)
		{
			return UFile.getInstance().DoReadText(path);

		}

		public static void CopyAndReplaceDirectory(string srcPath, string dstPath)
		{

			UFile.getInstance().CopyAndReplaceDirectory(srcPath, dstPath);

		}

		public static void CopyDirectory(string srcPath, string dstPath, bool overwrite)
		{
			UFile.getInstance().CopyDirectory(srcPath, dstPath, overwrite);
		}

		public static byte[] DoReadFileStream(Stream fsSource)
		{
			return UFile.getInstance().DoReadFileStream(fsSource);
		}
	}
}