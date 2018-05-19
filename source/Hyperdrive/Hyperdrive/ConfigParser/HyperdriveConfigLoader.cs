using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.ConfigParser
{
    public class HyperDriveConfigLoader : MonoBehaviour
    {
        //Module parameters
        [KSPField]
        public static bool _allowKerbalDeath = true;

        [KSPField]
        public static bool _allowExistFail = true;

        [KSPField]

        public static bool _allowBadOrbit = true;

        [KSPField]
        public static string allowKerbalDeath;

        [KSPField]
        public static string allowExistFail;

        [KSPField]
        public static string allowBadOrbit;

        public void Awake()
        {
            Debug.Log("[HYPERDRIVE]: Parsing Configs, Please Stand By");
            allowKerbalDeath = bool.Parse(allowKerbalDeath);
            allowExistFail = bool.Parse(_allowExistFail);
            _allowBadOrbit = bool.Parse(_allowBadOrbit);
            Debug.Log("[HYPERDRIVE]: Configs parsed and loaded, time to squeeze the oranges!");
        }
        
    }
}
