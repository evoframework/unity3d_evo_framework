using UnityEngine;
using System.Collections;

namespace Evo
{
    [System.Serializable]
    public abstract class GObject : EvoObject
    {

        /// <summary>
        /// 
        /// </summary>
        public bool isViewOnstart = false;

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidStart(System.Object obj)
        {
            this.Try(() =>
            {
                if (isViewOnstart)
                {
                    OnView(obj);
                }
                else
                {
                 //   OnHide(obj);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidStop(System.Object obj)
        {
            this.Try(() =>
            {
                OnHide(obj);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnView(System.Object obj)
        {
            this.Try(() =>
            {
                gameObject.SetActive(true);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnHide(System.Object obj)
        {
            this.Try(() =>
            {
                gameObject.SetActive(false);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnInteractable(bool isEnabled)
        {
        }
    }
}