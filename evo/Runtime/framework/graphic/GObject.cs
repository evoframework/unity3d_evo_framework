using UnityEngine;
using System.Collections;
using System;
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
            try
            {
                if (isViewOnstart)
                {
                    OnView(obj);
                }
                else
                {
                    //   OnHide(obj);
                }
            }
            catch (Exception exception)
            {
                this.DoException(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidStop(System.Object obj)
        {
            try
            {
                OnHide(obj);
            }
            catch (Exception exception)
            {
                this.DoException(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnView(System.Object obj)
        {
            try
            {
                gameObject.SetActive(true);
            }
            catch (Exception exception)
            {
                this.DoException(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnHide(System.Object obj)
        {
            try
            {
                gameObject.SetActive(false);
            }
            catch (Exception exception)
            {
                this.DoException(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnInteractable(bool isEnabled)
        {
        }
    }
}