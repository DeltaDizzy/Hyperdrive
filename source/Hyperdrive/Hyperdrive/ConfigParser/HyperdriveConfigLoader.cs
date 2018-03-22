using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.ConfigParser
{

<<<<<<< HEAD
    public class HyperdriveConfigLoader : MonoBehaviour
    {    
=======
    public class HyperDriveConfigLoader : MonoBehaviour
    {
        
        
>>>>>>> b7ca82db6ad445eee78c4d46d5d84847a1f6f846
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
            Debug.Log("[HYPERDRIVE]: Parsing Configs, Please Stand By");
            allowKerbalDeath = bool.Parse(crewCanDie);
            allowExistenceFailure = bool.Parse(allowUnexist);
            allowBadOrbit = bool.Parse(allowWrongOrbit);

        }
        
    }
}
