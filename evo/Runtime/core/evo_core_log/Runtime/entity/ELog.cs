// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System.Runtime.InteropServices;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public  class ELog : EObject
    {
        public EvoObject evoObject;

        public string idCaller;

        public string trace;

        public string tag;

        public long tick;

        public long tickOffset;

        public string message;

        public string messageBack;

        public string messageEvoCallBack;

        public System.Object parameter;
        public string traceStr;

        public bool isLocal;

        public UnityEngine.Object objectContext;

        public MapObject<string> mapTrace;

        public MapObject<string> mapStackTrace;

        public MapObject<string> arrayTrace;

    }
}