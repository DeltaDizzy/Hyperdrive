using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive
{
    public class Zyansias : PartModule
    {
        [KSPField]
        public float timeError = 2f;

        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me To Licono (zyansias 1.0.5)", unfocusedRange = 90)]
        public virtual void Licono()
        {

            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            int PlanetCount = Bodies.Count;
            print("[Hyperdrive]: Bodies loaded. Number of bodies: " + PlanetCount + ".");
            if (Bodies[104] != null)
            {
                if(FlightGlobals.ActiveVessel.orbit.referenceBody = Bodies[35])
                {
                    ScreenMessages.PostScreenMessage("#autoLOC_MRC_HDrive_API_ZNS_WormholeSuccess", 5, ScreenMessageStyle.UPPER_CENTER);
                    print("[Hyperdrive]: starting. Jumping to body: " + Bodies[104] + ".");
                    WarpDriver.MedTechWarp(Bodies[104], timeError);
                }
                else
                {
                    ScreenMessages.PostScreenMessage("#autoLOC_MRC_HDrive_API_ZNS_WormholeError", 5, ScreenMessageStyle.UPPER_CENTER);
                }
            }
            else
            {
                NullRef();
                return;
            }
        }

        private static void NullRef()
        {
            throw new NullReferenceException();
        }

        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to 1.0 Licono", unfocusedRange = 90)]
        public virtual void LiconoOld()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[96], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back to Caparis", unfocusedRange = 90)]
        public virtual void BackHome()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }
        public override void OnStart(StartState state)
        {
            print("PartModule Zyansias loaded.");
        }
    }
}
