using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BMSHyperdrive;

namespace BMSHyperdrive.API
{
    public class ModuleAPIJumpDrive : PartModule
    {
        [KSPField]
        public float timeError = 2f;

        [KSPField]
        public static float FGITarget = 1f;
        public static int Target = (int)FGITarget;

        static List<CelestialBody> Bodies = FlightGlobals.Bodies;

        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump", unfocusedRange = 90)]
        public virtual void JumpNow()
        {
            int PlanetCount = Bodies.Count;
            print(BMSHyperdrive.Utils.Log("Bodies loaded. Number of bodies: " + PlanetCount + "."));
            if (Bodies[Target] != null)
            {
                    ScreenMessages.PostScreenMessage(("#LOC_MRC_HDrive_API_GENERIC_DRIVES" + Bodies[Target].bodyDisplayName + "#LOC_MRC_HDrive_API_GENERIC_DRIVESP2"), 5, ScreenMessageStyle.UPPER_CENTER);
                    print("[BMSHyperdrive]: starting. Jumping to body: " + Bodies[Target] + ".");
                    WarpDriver.MedTechWarp(Bodies[Target], timeError);
            }
            else
            {
                ScreenMessages.PostScreenMessage("#autoLOC_MRC_HDrive_API_GENERIC_DRIVEF", 5, ScreenMessageStyle.UPPER_CENTER);
                NullRef();
                return;
            }
        }
        private static void NullRef()
        {
            throw new NullReferenceException();
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back to Kerbin or whatever your home planet is", unfocusedRange = 90)]
        public virtual void BackHome()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }
        public override void OnStart(StartState state)
        {
            print("PartModule ModuleAPIJumpDrive loaded.");
        }
    }
}
