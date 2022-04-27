using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Evo
{
	[System.Serializable]
	public class EFile : EObject
	{
		//public MemoryStream memoryStream;


		public byte[] byteData;

		public string name;

		public string fullName;

		public string creationTime;

		public string lastAccessTime;

		public string lastWriteTime;

		public string extension;

		public long length;

		override public void ToStream (Stream stream)
		{			
		}

		override public void FromStream(Stream stream)
		{
		}
	}
}