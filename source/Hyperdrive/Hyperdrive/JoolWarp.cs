using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hyperdrive
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class WarpDriver : MonoBehaviour
    {
        public static void LowTechWarp(CelestialBody TargetBody, float TimeFactor)
        {
            print("Void MrcarrotHyperdrive.WarpDriver.LowTechWarp is Triggered. Beginning jump drive action.");
            var orbit = Orbit.CreateRandomOrbitFlyBy(TargetBody, 0.5);
            ///These warp drives edit reality in a way that has some issues-
            ///one of them being going forward in time 20000 seconds- and even
            ///more for Kerbin warping
            var OldUT = Planetarium.GetUniversalTime();
            var UTChange = TimeFactor * 1.667;
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print("[Hyperdrive]: UT updated. New UT: " + NewUT + ". Jumping.");

            if (FlightGlobals.ActiveVessel != null)
            {
                print("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value.");
                OrbitPhysicsManager.HoldVesselUnpack(60);
                FlightGlobals.ActiveVessel.GoOnRails();
                FlightGlobals.ActiveVessel.orbit.referenceBody = orbit.referenceBody;
                FlightGlobals.ActiveVessel.orbit.LAN = orbit.LAN;
                FlightGlobals.ActiveVessel.orbit.semiMajorAxis = orbit.semiMajorAxis;
                FlightGlobals.ActiveVessel.orbit.eccentricity = orbit.eccentricity;
                FlightGlobals.ActiveVessel.orbit.inclination = orbit.inclination;
                FlightGlobals.ActiveVessel.orbit.argumentOfPeriapsis = orbit.argumentOfPeriapsis;
                FlightGlobals.ActiveVessel.orbit.meanAnomalyAtEpoch = orbit.meanAnomalyAtEpoch;
                FlightGlobals.ActiveVessel.orbit.epoch = orbit.epoch;
                FlightGlobals.ActiveVessel.orbitDriver.orbit = orbit;
                FlightGlobals.ActiveVessel.orbitDriver.orbit.Init();
                FlightGlobals.ActiveVessel.orbitDriver.orbit.UpdateFromUT(Planetarium.GetUniversalTime());
            }
            else
            {
                print("Error. Could not initiate Jump Drive. Property FlightGlobals.ActiveVessel is null.");
                print("How on Kerbin did you even call this void if there is no active vessel?");
                return;
            }
        }
        public static void MedTechWarp(CelestialBody TargetBody, float UTChange)
        {
            print("Void MrcarrotHyperdrive.WarpDriver.MedTechWarp is Triggered. Beginning jump drive action.");

            var orbit = Orbit.CreateRandomOrbitAround(TargetBody, TargetBody.Radius + (TargetBody.sphereOfInfluence - 120000), TargetBody.Radius + (TargetBody.sphereOfInfluence - 100000));
            var OldUT = Planetarium.GetUniversalTime();
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print("[Hyperdrive]: UT updated. Jumping.");

            if (FlightGlobals.ActiveVessel != null)
            {
                print("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value.");
                OrbitPhysicsManager.HoldVesselUnpack(60);
                FlightGlobals.ActiveVessel.GoOnRails();
                FlightGlobals.ActiveVessel.orbit.referenceBody = orbit.referenceBody;
                FlightGlobals.ActiveVessel.orbit.LAN = orbit.LAN;
                FlightGlobals.ActiveVessel.orbit.semiMajorAxis = orbit.semiMajorAxis;
                FlightGlobals.ActiveVessel.orbit.eccentricity = orbit.eccentricity;
                FlightGlobals.ActiveVessel.orbit.inclination = orbit.inclination;
                FlightGlobals.ActiveVessel.orbit.argumentOfPeriapsis = orbit.argumentOfPeriapsis;
                FlightGlobals.ActiveVessel.orbit.meanAnomalyAtEpoch = orbit.meanAnomalyAtEpoch;
                FlightGlobals.ActiveVessel.orbit.epoch = orbit.epoch;
                FlightGlobals.ActiveVessel.orbitDriver.orbit = orbit;
                FlightGlobals.ActiveVessel.orbitDriver.orbit.Init();
                FlightGlobals.ActiveVessel.orbitDriver.orbit.UpdateFromUT(Planetarium.GetUniversalTime());
            }
            else
            {
                print("Error. Could not initiate Jump Drive. Property FlightGlobals.ActiveVessel is null.");
                print("How on Kerbin did you even call this void if there is no active vessel?");
                return;
            }
        }
    }
}
