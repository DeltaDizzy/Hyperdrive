using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hyperdrive
{
    public class Utils
    {
        public static string Log(string logMessage)
        {
            return String.Format("[HYPERDRIVE]: " + logMessage);
        }
    }

    public class FileSetup : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }

    public class WarpHelp : MonoBehaviour
    {
        // Gets a list of parts on a vessel with the specified PartModule
        public static List<Part> PartsWithModule(Vessel v, Type partModuleType)
        {
            List<Part> returnList = new List<Part>();
            foreach (Part p in v.Parts)
            {
                IEnumerator ting = p.Modules.GetEnumerator();
                bool tingStatus = ting.MoveNext();
                for (int i = 0; i < p.Modules.Count; i++)
                {
                    if (ting.Current.GetType() == partModuleType)
                    {
                        returnList.Add(p);
                    }
                    if (tingStatus)
                    {
                        tingStatus = ting.MoveNext();
                    }
                }
            }
            return returnList;
        }

    }
}