using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hyperdrive
{
    public class ModuleSomewhereElseDrive : PartModule
    {
        static List<CelestialBody> Bodies = FlightGlobals.Bodies;
        static int PlanetCount = Bodies.Count; //Count bodies
        static System.Random rnd = new System.Random();
        int TargetFGI = rnd.Next(1, PlanetCount);

        //determines an error in time
        [KSPField]
        public float timeError = 12000f;

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
        public virtual void Hyperdrive()
        {

            try
            {
                
                float RandomLimitValue = (PlanetCount + 1);
                print("[Hyperdrive]: Bodies loaded. Number of bodies: " + PlanetCount + ".");

                if (Bodies[TargetFGI] != null)
                {
                    print(Utils.HyperdriveLogger("starting. Jumping to body: " + Bodies[TargetFGI] + "."));
                    ScreenMessages.PostScreenMessage(Utils.HyperdriveLogger("starting.Jumping to body: " + Bodies[TargetFGI] + "."), 5, ScreenMessageStyle.UPPER_CENTER);
                    WarpDriver.LowTechWarp(Bodies[TargetFGI], timeError);
                }
                else
                {
                    Debug.LogError("Exception: List " + Bodies + "Contains no instance of an object with type CelestialBody at list place " + TargetFGI + ".");
                    ScreenMessages.PostScreenMessage("Sorry, the hyperdrive cannot jump to that location. We also cannot open the pod bay doors. Blame the engineers.", 5, ScreenMessageStyle.UPPER_CENTER);
                    throw new NullReferenceException();
                    return;
                }
            }
            catch (NullReferenceException nre)
            {
                Debug.LogError(nre.Message);
                Debug.LogError("List " + Bodies + "Contains no instance of an object with type CelestialBody at list place " + TargetFGI + ".");
            }
        }
        private static void NullRef()
        {
            throw new NullReferenceException();
        }
        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back Home", unfocusedRange = 90)]
        public virtual void BackHomeDrive()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            ScreenMessages.PostScreenMessage("[Hyperdrive]: starting.Jumping to body: " + Bodies[1] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
            WarpDriver.LowTechWarp(Bodies[1], 23000);
        }
        public override void OnStart(StartState state)
        {
            print(Utils.HyperdriveLogger("ModuleSomewhereElseDrive loaded."));
            ScreenMessages.PostScreenMessage("ModuleSomewhereElseDrive loaded. This Module[TM] gets a screen message. Think about it.", 5, ScreenMessageStyle.UPPER_CENTER);
        }
    }
}
