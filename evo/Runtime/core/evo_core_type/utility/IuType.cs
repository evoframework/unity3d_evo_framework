using System;
using UnityEngine;
namespace Evo{
public class IuType 
{
	public static bool isEObjectI(System.Object obj){
		return UType.getInstance().isEObject(obj);
	}
	
	public static bool isArray(System.Object obj){
		return UType.getInstance().isArray(obj);
	}

	public static bool isHashtable(System.Object obj){
		return obj.GetType ().Equals(typeof(System.Collections.Hashtable));
	}
	
	public static bool isSortedDictionary(System.Object obj){
		return obj.GetType ().Equals(typeof(System.Collections.Generic.SortedDictionary<string,System.Object>));
	}

	public static bool isMap(System.Object obj){
		return obj.GetType ().Equals(typeof(Map));
	}

	public static bool isArrayByte(System.Object obj){

		return obj.GetType ().Equals(typeof(byte[]));
	}

	public static bool isTexture(System.Object obj){
		
		return obj.GetType ().Equals(typeof(Texture));
	}

	public static bool isTexture2D(System.Object obj){
		
		return obj.GetType ().Equals(typeof(Texture2D));
	}

	public static bool isTexture3D(System.Object obj){
		
		return obj.GetType ().Equals(typeof(Texture3D));
	}
}
}