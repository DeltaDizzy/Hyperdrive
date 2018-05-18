using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.ConfigParser
{
<<<<<<< HEAD
    public class HyperDriveConfigLoader : MonoBehaviour
    {
        //Module parameters
        [KSPField]
        public static bool allowKerbalDeath = true;

        [KSPField]
        public static bool allowExistFail = true;

        [KSPField]
=======

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
>>>>>>> 8545ff707192dfeea20108596e9a693dc876f936
        public static bool allowBadOrbit = true;

        [KSPField]
        public static string _allowKerbalDeath;

        [KSPField]
        public static string _allowExistFail;

        [KSPField]
        public static string _allowBadOrbit;

        public void Awake()
        {
            Debug.Log("[HYPERDRIVE]: Parsing Configs, Please Stand By");
            allowKerbalDeath = bool.Parse(_allowKerbalDeath);
            allowExistFail = bool.Parse(_allowExistFail);
            allowBadOrbit = bool.Parse(_allowBadOrbit);
            Debug.Log("[HYPERDRIVE]: Configs parsed and loaded, time to squeeze the oranges!");
        }
        
    }
}
