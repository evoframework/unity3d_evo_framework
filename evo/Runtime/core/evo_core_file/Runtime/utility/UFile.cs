using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;
using System.Text;
using UnityEngine.Networking;

namespace Evo
{
	/// <summary>
	/// 
	/// </summary>
	public class UFile : UObject
	{

		private static volatile UFile instance;

		/// <summary>
		/// 
		/// </summary>
		private UFile()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		public static UFile getInstance()
		{
			if (instance == null)
			{
				instance = new UFile();
			}
			return instance;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ExistFile(string pathFile)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(pathFile);
				return fileInfo.Exists;
			}
			catch (System.Exception exception)
			{
				this.DoError(exception);
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool ExistDirectory(string pathFile)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(pathFile);
				return directoryInfo.Exists;
			}
			catch (System.Exception exception)
			{
				this.DoError(exception);
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void CreateDirectory(string path)
		{
			try
			{
				if (!Directory.Exists(path))
				{
					try
					{
						System.IO.Directory.CreateDirectory(path);
					}
					catch (System.Exception e)
					{
						this.DoError(e);
					}
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void DoDelFileInDirectory(string pathDirectory)
		{
			try
			{
				System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(pathDirectory);


				foreach (FileInfo file in directoryInfo.GetFiles())
				{
					file.Delete();
				}

				foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
				{
					dir.Delete(true);
				}

				System.IO.Directory.Delete(pathDirectory);

			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void DoWrite(string pathFile, string text, bool append)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(pathFile, append))
				{
					streamWriter.Write(text);
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void DoWrite(string pathFile, byte[] arrayByte, bool append)
		{
			try
			{
				FileMode fileMode = FileMode.Append;
				if (!append)
				{
					fileMode = FileMode.OpenOrCreate;
				}

				using (FileStream fileStream = new FileStream(pathFile, fileMode, FileAccess.ReadWrite))
				{
					fileStream.Write(arrayByte, 0, arrayByte.Length);
				}

			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void DoDel(string url)
		{
			try
			{
				if (IuFile.ExistFile(url))
				{
					System.IO.File.Delete(url);
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}

		}

		/// <summary>
		/// 
		/// </summary>
		public byte[] DoReadByte(string url)
		{
			try
			{
				using (FileStream fsSource = new FileStream(url,
															FileMode.Open, FileAccess.Read))
				{

					byte[] arrayByteReturn = new byte[fsSource.Length];
					int numBytesToRead = (int)fsSource.Length;
					int numBytesRead = 0;
					while (numBytesToRead > 0)
					{
						try
						{
							int n = fsSource.Read(arrayByteReturn, numBytesRead, numBytesToRead);
							if (n == 0)
							{
								break;
							}

							numBytesRead += n;
							numBytesToRead -= n;
						}
						catch (System.Exception e)
						{
							this.DoError(e);
						}
					}
					numBytesToRead = arrayByteReturn.Length;
					return arrayByteReturn;
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public byte[] DoReadFileStream(Stream fsSource)
		{
			try
			{

				if (fsSource != null)
				{
					fsSource.Seek(0, SeekOrigin.Begin);
					byte[] arrayByteReturn = new byte[fsSource.Length];
					int numBytesToRead = (int)fsSource.Length;
					int numBytesRead = 0;
					while (numBytesToRead > 0)
					{
						try
						{
							int n = fsSource.Read(arrayByteReturn, numBytesRead, numBytesToRead);
							if (n == 0)
							{
								break;
							}

							numBytesRead += n;
							numBytesToRead -= n;
						}
						catch (System.Exception e)
						{
							this.DoError(e);
						}
					}
					numBytesToRead = arrayByteReturn.Length;

					return arrayByteReturn;
					//}
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public EFile DoReadEFile(string url)
		{
			try
			{
				EFile eFile = new EFile();
				eFile.iD = IuKey.GenerateId();
				//eFile.time = IuKey.GenerateTime();
				if (ExistFile(url))
				{
					FileInfo fileInfo = new FileInfo(url);
					if (fileInfo.Extension != null)
					{
						eFile.name = fileInfo.Name.Replace(fileInfo.Extension, "");
					}
					else
					{
						eFile.name = fileInfo.Name;
					}

					eFile.extension = fileInfo.Extension;
					eFile.creationTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.CreationTimeUtc);
					eFile.lastAccessTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.LastAccessTimeUtc);
					eFile.lastWriteTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.LastWriteTimeUtc);

					using (FileStream fsSource = new FileStream(url,
															FileMode.Open, FileAccess.Read))
					{

						byte[] arrayByteReturn = new byte[fsSource.Length];
						int numBytesToRead = (int)fsSource.Length;
						int numBytesRead = 0;
						while (numBytesToRead > 0)
						{
							try
							{
								int n = fsSource.Read(arrayByteReturn, numBytesRead, numBytesToRead);
								if (n == 0)
								{
									break;
								}

								numBytesRead += n;
								numBytesToRead -= n;
							}
							catch (System.Exception e)
							{
								this.DoError(e);
							}
						}
						numBytesToRead = arrayByteReturn.Length;


						eFile.length = arrayByteReturn.Length;
						eFile.byteData = arrayByteReturn;

						return eFile;
					}
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
			return null;
		}
		
		/// <summary>
		/// 
		/// </summary>
		public EFile DoReadEFileProperty(string url)
		{
			try
			{
				EFile eFile = new EFile();
				eFile.iD = IuKey.GenerateId();
			//	eFile.time = IuKey.GenerateTime();
				if (ExistFile(url))
				{
					FileInfo fileInfo = new FileInfo(url);
					if (fileInfo.Extension != null)
					{
						eFile.name = fileInfo.Name.Replace(fileInfo.Extension, "");
					}
					else
					{
						eFile.name = fileInfo.Name;
					}

					eFile.extension = fileInfo.Extension;
					eFile.creationTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.CreationTimeUtc);
					eFile.lastAccessTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.LastAccessTimeUtc);
					eFile.lastWriteTime = System.String.Format("{0:yyyy_MM_dd-HH_mm_ss}", fileInfo.LastWriteTimeUtc);
					eFile.length = fileInfo.Length;
					return eFile;
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public string DoReadText(string path)
		{
			try
			{
				string strReturn = "";

				using (StreamReader streamReader = new StreamReader(path))
				{
					while (streamReader.Peek() >= 0)
					{
						try
						{
							strReturn += streamReader.ReadLine() + "\n";
						}
						catch (System.Exception e)
						{
							this.DoError(e);
						}
					}
				}
				return strReturn;

			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
			return "";
		}

		/// <summary>
		/// 
		/// </summary>
		public void CopyAndReplaceDirectory(string srcPath, string dstPath)
		{
			try
			{
				IuFile.DoDelFileInDirectory(dstPath);

				if (Directory.Exists(dstPath))
				{
					Directory.Delete(dstPath);
				}
				if (File.Exists(dstPath))
				{
					File.Delete(dstPath);
				}

				Directory.CreateDirectory(dstPath);

				foreach (var file in Directory.GetFiles(srcPath))
				{
					CopyAndReplaceDirectory(file, Path.Combine(dstPath, Path.GetFileName(file)));
				}

				foreach (var dir in Directory.GetDirectories(srcPath))
				{
					CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void CopyDirectory(string srcPath, string dstPath, bool overwrite)
		{
			try
			{
				//IuFile.DoDelFileInDirectory (dstPath);

				/*	if (Directory.Exists (dstPath)) {
					Directory.Delete (dstPath);
				}




				if (File.Exists (dstPath)) {
					File.Delete (dstPath);
				}*/

				FileAttributes attr = File.GetAttributes(srcPath);

				//detect whether its a directory or file
				if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
				{
					Directory.CreateDirectory(dstPath);
				}
				else
				{
					File.Copy(srcPath, dstPath, overwrite);
				}



				foreach (var file in Directory.GetFiles(srcPath))
				{
					CopyDirectory(file, Path.Combine(dstPath, Path.GetFileName(file)), overwrite);


					foreach (var dir in Directory.GetDirectories(srcPath))
					{
						CopyDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)), overwrite);
					}
				}
			}
			catch (System.Exception e)
			{
				this.DoError(e);
			}
		}

	}

}