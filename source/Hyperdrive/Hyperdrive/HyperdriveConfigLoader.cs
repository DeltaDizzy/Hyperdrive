using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static ConfigNode;

namespace Hyperdrive.ConfigParser
{
    public class HyperdriveConfigLoader : MonoBehaviour
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
            ConfigNode hyperdrive = new ConfigNode("HYPERDRIVE");
            hyperdrive = hyperdrive.GetNode("HYPERDRIVE");

            if (hyperdrive.HasValue("allowDeath"))
            {
                _allowKerbalDeath = bool.Parse(hyperdrive.GetValue("allowDeath"));
            }
            if (hyperdrive.HasValue("allowUnexist"))
            {
                _allowExistFail = bool.Parse(hyperdrive.GetValue("allowUnexist"));
            }
            if (hyperdrive.HasValue("allowBadOrbit"))
            {
                _allowBadOrbit = bool.Parse(hyperdrive.GetValue("allowBadOrbit"));
            }
        }

    }
}
