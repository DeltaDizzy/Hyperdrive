using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.ConfigParser
{
    class HyperdriveConfigLoader : PartModule
    {
        //Module parameters
        [KSPField(isPersistant = true)]
        public static string homeWorldName;

        [KSPField(isPersistant = true)]
        public static bool allowKerbalDeath;

        [KSPField(isPersistant = true)]
        public static bool allowExistenceFailure;

        [KSPField(isPersistant = true)]
        public static bool allowBadOrbit;

        public static string crewCanDie; 

        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);

            if (crewCanDie == null && node.HasValue(nameof(allowKerbalDeath)))
            {

            }
        }
    }

    public class ImpDriveConfig : PartModule
    {
        
        
        //Module parameters
        [KSPField]
        public static bool allowKerbalDeath = true;

        [KSPField]
        public static bool allowExistenceFailure = true;

        [KSPField]
        public static bool allowBadOrbit = true;

        [KSPField]
        public static string crewCanDie;

        [KSPField]
        public static string allowUnexist;

        [KSPField]
        public static string allowWrongOrbit;

        public override void OnAwake()
        {
            allowKerbalDeath = bool.Parse(crewCanDie);
            allowExistenceFailure = bool.Parse(allowUnexist);
            allowBadOrbit = bool.Parse(allowWrongOrbit);
        }
        
    }
}
