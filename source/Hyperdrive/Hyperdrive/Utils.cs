using System;
using UnityEngine;


namespace Hyperdrive
{
    public class Utils
    {
        public static string HyperdriveLogger(string logMessage)
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
}