using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace Evo
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct EError : IEObject
    {
        #region IEvo
        private Evo.Id _iD;

        private Evo.Time _time;

        /// <summary>
        /// Id
        /// </summary>
        public Evo.Id iD
        {
            get => _iD;
            set => _iD = value;
        }

        /// <summary>
        /// Time
        /// </summary>
        public Evo.Time time
        {
            get => _time;
            set => _time = value;
        }
        #endregion


        
        public static string ERROR_NOT_FOUND_MAIN_CANVAS = "ERROR_NOT_FOUND_MAIN_CANVAS";
        public static string ERROR_NOT_VALID_IN_MESSAGE_FOUND = "ERROR_NOT_VALID_IN_MESSAGE_FOUND";
        public static string ERROR_NOT_VALID_OUT_MESSAGE_FOUND = "ERROR_NOT_VALID_OUT_MESSAGE_FOUND";
        public static string ERROR_NOT_VALID_IN_MESSAGE = "ERROR_NOT_VALID_IN_MESSAGE";
        public static string ERROR_NOT_VALID_OUT_MESSAGE = "ERROR_NOT_VALID_OUT_MESSAGE";
        public static string ERROR_NOT_VALID_PROPERTY = "ERROR_NOT_VALID_PROPERTY";
        public static string ERROR_NOT_VALID_MAP_KEY = "ERROR_NOT_VALID_MAP_KEY";
        public static string ERROR_NOT_VALID_EOBJECT = "NOT_VALID_EOBJECT";
        public static string ERROR_NOT_VALID_UNITY_OBJECT = "NOT_VALID_UNITY_OBJECT";
        public static string ERROR_NOT_VALID_OBJECT = "NOT_VALID_OBJECT";
        public static string ERROR_NOT_VALID_EOBJECT_ID = "NOT_VALID_EOBJECT_ID";
        public static string ERROR_NOT_VALID_EOBJECT_TIME = "NOT_VALID_EOBJECT_TIME";
        public static string ERROR_NOT_VALID_ECLASS = "NOT_VALID_ECLASS";
        public static string ERROR_NOT_VALID_EMESSAGE = "NOT_VALID_EMESSAGE";
        public static string ERROR_NOT_VALID_EMESSAGE_MESSAGE = "ERROR_NOT_VALID_EMESSAGE_MESSAGE";
        public static string ERROR_NOT_VALID_TYPE = "NOT_VALID_TYPE";
        public static string ERROR_NOT_VALID_MAP = "NOT_VALID_MAP";
        public static string ERROR_NOT_FOUND_EMESSAGE_PARAMETER_TYPE = "ERROR_NOT_FOUND_EMESSAGE_PARAMETER_TYPE";
        public static string ERROR_NOT_VALID_EVENT = "ERROR_NOT_VALID_EVENT";
        public static string ERROR_NOT_VALID_EVENT_PARENT = "ERROR_NOT_VALID_EVENT_PARENT";
        public static string ERROR_NOT_VALID_RESOURCE = "ERROR_NOT_VALID_RESOURCE";
        public static string ERROR_NOT_VALID_GPPROPERTY = "ERROR_NOT_VALID_GPPROPERTY";
        public static string ERROR_NOT_VALID_GOBJECT = "ERROR_NOT_VALID_GPPROPERTY";
        public static string ERROR_NOT_FIND_ESERVER = "ERROR_NOT_FIND_ESERVER";
        public static string ERROR_NOT_FIND_ECLIENT = "ERROR_NOT_FIND_ECLIENT";
        public static string ERROR_PINNING_NOT_VALID_ID_ESERVER_REMOTE = "ERROR_PINNING_NOT_VALID_ID_ESERVER_REMOTE";
        public static string ERROR_PINNING_NOT_VALID_RSA_ESERVER_REMOTE = "ERROR_PINNING_NOT_VALID_RSA_ESERVER_REMOTE";


        public static string TYPE_ALERT_DEBUG = "TYPE_ALERT_DEBUG";
        public static string TYPE_ALERT_WARNING = "TYPE_ALERT_WARNING";
        public static string TYPE_ALERT_ERROR = "TYPE_ALERT_ERROR";
        public static string TYPE_ALERT_SUCCESS = "TYPE_ALERT_SUCCESS";


        public string type;
        public bool isAutoClose;

        
    }
}