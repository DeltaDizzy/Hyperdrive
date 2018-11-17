using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace BMSHyperdrive
{
    class BadStuff : MonoBehaviour
    {
        public static void CrewDie()
        {
            ScreenMessages.PostScreenMessage("Sorry, your crew has died in a tragic accident. Your warranty expired yesterday.", 5, ScreenMessageStyle.UPPER_CENTER);
            FlightGlobals.ActiveVessel.MurderCrew();
        }
        public static void BadOrbit(int FGIAvoid)
        {
            print("[BMSHyperdrive]: Activating BMSHyperdrive.BadStuff.BadOrbit. Cleverly inventing new destination.");
            ScreenMessages.PostScreenMessage("Unfortunately, your jump drive malfunctioned, and it will now be taking you to anywhere but your destination.", 7, ScreenMessageStyle.UPPER_CENTER);
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            System.Random rnd = new System.Random();
            int TargetFGI = rnd.Next(1, Bodies.Count);
            if (TargetFGI != FGIAvoid)
            {
                WarpDriver.MedTechWarp(Bodies[TargetFGI], 1200000);
            }
            else
            {
                int NewTarget = rnd.Next(1, Bodies.Count);
                if (NewTarget == FGIAvoid)
                {
                    print("[IID]: Error. Could not go to anywhere but the target. Unexisting vessel.");
                    ScreenMessages.PostScreenMessage("The infinite improbability drive has failed, and will now unexist you.", 7, ScreenMessageStyle.UPPER_CENTER);
                    Unexist();
                }
                else
                {
                    WarpDriver.MedTechWarp(Bodies[FGIAvoid], 1200000);
                }
            }
        }
        public static void Unexist()
        {
            print("[IID]: Unexisting active vessel; switching to nearest controllable vessel.");
            Vessel UnexistingVessel = FlightGlobals.ActiveVessel;
            Vessel NextVessel = FlightGlobals.FindNearestControllableVessel(UnexistingVessel);
            if(NextVessel != null)
            {
                FlightGlobals.SetActiveVessel(NextVessel);
            }
            else
            {
                return;
            }
            UnexistingVessel.MurderCrew();
            FlightGlobals.RemoveVessel(UnexistingVessel);
        }
    }
}
