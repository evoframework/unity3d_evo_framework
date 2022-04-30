using UnityEngine;
using System.Collections;

namespace Evo
{
    public class EditorEvoObject : IEvo
    {
        #region IEvo
        public string iD { get; set; }
        public long time { get; set; }
        #endregion
    }
}