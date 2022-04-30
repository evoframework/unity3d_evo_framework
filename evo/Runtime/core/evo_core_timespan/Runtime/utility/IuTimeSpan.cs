using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;
using UnityEngine;
namespace Evo
{
    public static class IuTimeSpan
    {
        /// <summary>
        /// 
        /// </summary>
        public static double Time(Action action, string title)
        {
            try
            {
                //Debug.ClearDeveloperConsole ();
                var initialMemory = System.GC.GetTotalMemory(true);
                Debug.Log("\nStart " + title + "\tMemory start:" + (initialMemory / 8000).ToString() + " KB ");

                DateTime dateTimeNow = DateTime.Now;

                try
                {
                    ((Action)action)();
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

                TimeSpan ts = DateTime.Now - dateTimeNow;
                var finalMemory = System.GC.GetTotalMemory(true);
                var consumption = finalMemory - initialMemory;
                Debug.Log("Memory end:" + (finalMemory / 8000).ToString() + " KB" + " Memory consumption:" + (consumption).ToString() + " byte");

                Debug.Log("End " + title + "\t\tTime Total: " + ts.Hours + "h:" + ts.Minutes + "m:" + ts.Seconds + "." + (ts.Milliseconds / 10) + "s");

                return ts.Milliseconds;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double SubTime(Action action, string title, bool isLogEnabled = true)
        {
            try
            {
                var initialMemory = System.GC.GetTotalMemory(true);
                if (isLogEnabled)
                {
                    Debug.Log("---------------------------" + "\n"
                    + "Start " + title + "\tMemory start:" + (initialMemory / 8000).ToString() + " KB "
                     + "---------------------------" + "\n");
                }
                DateTime t = DateTime.Now;

                try
                {
                    ((Action)action)();
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

                TimeSpan ts = DateTime.Now - t;
                var finalMemory = System.GC.GetTotalMemory(true);
                var consumption = finalMemory - initialMemory;
                if (isLogEnabled)
                {
                    Debug.Log(
                    "---------------------------" + "\n"
                    + "Memory end:\t" + (finalMemory / 8000).ToString() + " KB" + "\n"
                    + " Memory consumption:\t" + (consumption).ToString() + " byte" + "\n"
                    + "End" + "\n"
                    + title + "\n"
                    + "Time Total:\t" + ts.Hours + "h:" + ts.Minutes + "m:" + ts.Seconds + "." + (ts.Milliseconds / 10) + "s" + "\n"
                    + "---------------------------\n");
                }
                return ts.TotalMilliseconds;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return 1;

        }

        /// <summary>
        /// 
        /// </summary>
        public static double TimeLoop(int loopCounter, Action action, string title, bool isLogEnabled = true)
        {
            try
            {

                var initialMemory = System.GC.GetTotalMemory(true);
                if (isLogEnabled)
                {
                    Debug.Log(
                         "---------------------------" + "\n" + "\n"
                         + title + " count loop: " + loopCounter.ToString("N1") + "\n"
                         + "Memory start: " + (initialMemory / 8000).ToString() + " KB " + "\n"
                         + "---------------------------" + "\n");
                }
                DateTime t = DateTime.Now;
               // Debug.unityLogger.logEnabled = isLogEnabled;
                try
                {

                    for (int i = 0; i < loopCounter; i++)
                    {
                        try
                        {
                            ((Action)action)();
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

                TimeSpan ts = DateTime.Now - t;
                var finalMemory = System.GC.GetTotalMemory(true);
                var consumation = finalMemory - initialMemory;
                if (isLogEnabled)
                {
                    Debug.Log(
                        "---------------------------" + "\n"
                        + "Memory end:\t" + (finalMemory / 8000).ToString() + " KB" + "\n"
                        + "Memory consumption: " + (consumation).ToString() + " byte" + "\n"
                        + "Time single avg:\t" + (ts.TotalMilliseconds / loopCounter).ToString() + "ms\n"
                        + "Time Total:\t" + ts.Hours + "h:" + ts.Minutes + "m:" + ts.Seconds + "." + (ts.Milliseconds / 10) + "s" + "\n"
                        + "---------------------------\n");
                }
                return ts.TotalMilliseconds;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Effort(double time1, double time2, string title)
        {
            try
            {
                double effort = (time1 / time2);
                string result = "";
                if (effort < 1.0f)
                {

                    double effortFaster = 1.0f / (effort);

                    if (effortFaster > 10)
                    {
                        result = effortFaster.ToString("F2") + "x faster :-O";
                    }
                    else
                    {
                        result = effortFaster.ToString("F2") + "x faster :-)";
                    }
                }
                else
                {
                    result = effort.ToString("F2") + "x slower  :-(";
                }

                Debug.Log("\t\tEffort " + title + " \t" + " " + result);

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GarbageCollector()
        {
            try
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.GC.Collect();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}

