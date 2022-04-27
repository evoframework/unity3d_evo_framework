using UnityEngine;
using System.Collections;
using System;
namespace Evo
{
    public enum EnumVisibilty
    {
        VISIBILITY_PUBLIC,
        VISIBILITY_PROTECTED,
        VISIBILITY_PRIVATE,
        VISIBILITY_STATIC_PUBLIC,
        VISIBILITY_STATIC_PROTECTED,
        VISIBILITY_STATIC_PRIVATE
    }

    public class EObjectIProperty : IEObject
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

        public string name;

        public EnumVisibilty visibility;

        public Type type;
        public string typeName;

        public int gType;

        public System.Object value;

        public GObject gObjectLink;

    }
}