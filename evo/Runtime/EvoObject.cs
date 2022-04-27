using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Threading.Tasks;
using System.Threading;

namespace Evo
{
    [System.Serializable]
    public abstract class EvoObject : MonoBehaviour, IEvo
    {

        public static readonly string EVO_VERSION = "20211117";

        public float timeDelay = 0.1f;

        public bool isInitialized = false;

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

        /// <summary>
        /// 
        /// </summary>
        void OnEnable()
        {
            this.Try(() =>
            {

                iD = new Id(GetType().Name + "(" + GetInstanceID().ToString().Replace("-", "0") + ")");

                OnDidEnable("OnEnable");

            });
        }

        /// <summary>
        /// 
        /// </summary>
        #pragma warning disable CS1998
        public async void Start()
        #pragma warning restore CS1998
        {
            this.Try(async () =>
            {
                #if !UNITY_WEBGL
                await Task.Delay(TimeSpan.FromSeconds(timeDelay));
                #endif
                OnDidStart(null);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        void OnDisable()
        {
            this.Try(() =>
            {
                OnDidStop("OnDestroy");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        void OnApplicationQuit()
        {
            OnDisable();
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnDidEnable(System.Object obj)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnDidStart(System.Object obj)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void OnDidStop(System.Object obj)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        virtual protected void OnMemoryWarning(System.Object obj)
        {
        }

        protected static List<Action> listActions = new List<Action>();

        public static void DoThreadAction(Action action)
        {
            try
            {

                {
                    listActions.Add(action);
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }


        void Update()
        {
            try
            {

                if (listActions.Count != 0)
                {

                    {
                        var listActionsTmp = new List<Action>(listActions);
                        foreach (var action in listActionsTmp)
                        {
                            try
                            {
                                action();
                            }
                            catch (Exception exception)
                            {
                                Debug.LogException(exception);
                            }
                        }

                        listActions.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }

        }
    }
}