using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace Evo
{
    [System.Serializable]
    public class EObjectIClass : IEObject
    {
        public static string TYPE_GEOBJECT = "GEObjectI";
        public static string TYPE_EOBJECT = "EObjectI";
        public static string TYPE_COBJECT = "CObject";
        public static string TYPE_GOBJECT = "GObject";
        public static string TYPE_UOBJECT = "UObject";

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


        public string name;

        public Map mapEObjectIProperty = new Map();

        public Map mapEObjectIMethod = new Map();

        public Map mapEObjectIEvent = new Map();

        public Type type;

        public string typeEvo;

        public bool isSelected;

        public string baseClass { set; get; }

        public int gType;

    }
}