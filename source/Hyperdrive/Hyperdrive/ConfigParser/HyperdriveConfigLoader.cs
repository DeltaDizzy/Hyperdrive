using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.ConfigParser
{

    public class HyperdriveConfigLoader : MonoBehaviour
    {    
        //Module parameters
        public static bool allowKerbalDeath = true;   
        public static bool allowExistenceFailure = true;
        public static bool allowBadOrbit = true;

        [KSPField]
        public static string crewCanDie;

        [KSPField]
        public static string allowUnexist;

        [KSPField]
        public static string allowWrongOrbit;

        public void Awake()
        {
            allowKerbalDeath = bool.Parse(crewCanDie);
            allowExistenceFailure = bool.Parse(allowUnexist);
            allowBadOrbit = bool.Parse(allowWrongOrbit);
        }
        
    }
}
