using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Evo
{
	/// <summary>
	/// 
	/// </summary>
	public enum FoundationEnum
	{
		Mediator_Only,
		Foundation_Only,
		Mediator_Foundation
	}

	/// <summary>
	/// 
	/// </summary>
	public enum EnumSort
	{
		Ascending,
		Descending
	}

	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public unsafe struct EQuery : IEObject
	{
		#region IEvo
		private Id _iD;
		private Time _time;

		/// <summary>
		/// Id
		/// </summary>
		public Id iD
		{
			get => _iD;
			set => _iD = value;
		}

		/// <summary>
		/// Time
		/// </summary>
		public Time time
		{
			get => _time;
			set => _time = value;
		}
		#endregion

		public System.Type queryType;

		public FoundationEnum foundationEnum;

		public string queryId;

		public string orderByChild;

		public int limit;

		public bool isCrypt;

		public bool isMediator;

		public EnumSort sort;

		public bool isFoundation;

		public EObject eObject;

		public EObject eLog;

		public string query;

		public string sender;

		public string to;

		public string messageBack;

		public bool isOnValue;

		public bool isOnChildAdded;

		public bool isOnChildChanged;

		public bool isOnChildRemoved;

		public bool isOnChildMoved;

		public EvoCallback<System.Object> evoCallback;

	}
}