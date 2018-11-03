using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hyperdrive
{
    public class ModuleLowTechWarp : PartModule
    {
        [KSPField]
        public static bool isModuleActive;

        public static void LowTechWarp(CelestialBody TargetBody, float TimeFactor)
        {
            Debug.Log(Utils.Log("Hyperdrive.WarpDriver.LowTechWarp is Triggered. Beginning jump drive action."));
            System.Random days = new System.Random();
            int orbdays = days.Next(1,10);
            Orbit orbit = Orbit.CreateRandomOrbitFlyBy(TargetBody, (orbdays / 10)); //Create random orbit parameters

            ///These warp drives blow raspberries at reality in a way that has some issues-
            ///one of them being going forward in time 20000 seconds- and even more for Kerbin warping
            ///Remember kids, DON'T BLOW RASPBERRIES AT REALITY!!!

            //Time warp - Set new UT
            var OldUT = Planetarium.GetUniversalTime();
            var UTChange = TimeFactor * 1.667;
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print(Utils.Log("UT updated. New UT: " + NewUT + ". Jumping."));

            if (FlightGlobals.ActiveVessel != null) //If you have a vessel
            {
                print(Utils.Log("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value."));

                OrbitPhysicsManager.HoldVesselUnpack(60);

                FlightGlobals.ActiveVessel.GoOnRails(); //Make vessel controllable by code

                //Set vessel orbit params to those generated earlier
                FlightGlobals.ActiveVessel.orbit.referenceBody = orbit.referenceBody;
                FlightGlobals.ActiveVessel.orbit.LAN = orbit.LAN;
                FlightGlobals.ActiveVessel.orbit.semiMajorAxis = orbit.semiMajorAxis;
                FlightGlobals.ActiveVessel.orbit.eccentricity = orbit.eccentricity;
                FlightGlobals.ActiveVessel.orbit.inclination = orbit.inclination;
                FlightGlobals.ActiveVessel.orbit.argumentOfPeriapsis = orbit.argumentOfPeriapsis;
                FlightGlobals.ActiveVessel.orbit.meanAnomalyAtEpoch = orbit.meanAnomalyAtEpoch;
                FlightGlobals.ActiveVessel.orbit.epoch = orbit.epoch;
                FlightGlobals.ActiveVessel.orbitDriver.orbit = orbit;

                //Activate OPS-201 PRO - Inotialize orbit
                FlightGlobals.ActiveVessel.orbitDriver.orbit.Init();
                FlightGlobals.ActiveVessel.orbitDriver.orbit.UpdateFromUT(Planetarium.GetUniversalTime());
            }
            else
            {
                print(Utils.Log("Error. Could not initiate Jump Drive. Property FlightGlobals.ActiveVessel is null."));
                print(Utils.Log(String.Format("How on ", FlightGlobals.GetHomeBodyDisplayName(), "did you even call this if there is no active vessel?")));
                return;
            }
        }
    }
}
