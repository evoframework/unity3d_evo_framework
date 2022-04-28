using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Evo
{
	/// <summary>
	/// 
	/// </summary>
	[System.Serializable]
	public class EFile : EObject
	{

		public byte[] byteData;

		public string name;

		public string fullName;

		public string creationTime;

		public string lastAccessTime;

		public string lastWriteTime;

		public string extension;

		public long length;

		/// <summary>
		/// 
		/// </summary>
		override public void ToStream (Stream stream)
		{			
		}

		/// <summary>
		/// 
		/// </summary>
		override public void FromStream(Stream stream)
		{
		}
	}
}