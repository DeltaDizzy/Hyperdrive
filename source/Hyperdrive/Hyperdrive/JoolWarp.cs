/* 
 * Hyperdrive for KSP 1.3.1
 * Copyright Mrcarrot 2018 for PartModule and
 * DeltaDizzy 2018 for Log system improvements
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Hyperdrive;

namespace Hyperdrive
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class WarpDriver : MonoBehaviour
    {

        public static void LowTechWarp(CelestialBody TargetBody, float TimeFactor)
        {
            Debug.Log(HyperdriveLogFormatter("Hyperdrive.WarpDriver.LowTechWarp is Triggered.Beginning jump drive action."));
            var orbit = Orbit.CreateRandomOrbitFlyBy(TargetBody, 0.5);//Create rndom orbit parameters

            ///These warp drives blow raspberries at reality in a way that has some issues-
            ///one of them being going forward in time 20000 seconds- and even more for Kerbin warping
            ///Remember kids, DON'T BLOW RASPBERRIES AT REALITY!!!
            
            //Time warp - Set new UT
            var OldUT = Planetarium.GetUniversalTime();
            var UTChange = TimeFactor * 1.667;
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print(HyperdriveLogFormatter("UT updated. New UT: " + NewUT + ". Jumping."));

            if (FlightGlobals.ActiveVessel != null) //If you have a vessel
            {
                print(HyperdriveLogFormatter("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value."));

                OrbitPhysicsManager.HoldVesselUnpack(60);

                FlightGlobals.ActiveVessel.GoOnRails();//Make vessel controllable by code

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
                print(HyperdriveLogFormatter("Error. Could not initiate Jump Drive. Property FlightGlobals.ActiveVessel is null."));
                print("How on Kerbin did you even call this void if there is no active vessel?");
                return;
            }
        }
        public static void MedTechWarp(CelestialBody TargetBody, float UTChange)
        {
            print("MrcarrotHyperdrive.WarpDriver.MedTechWarp is Triggered. Beginning jump drive action.");
            
            //Ccreate orbital params and change UT
            var orbit = Orbit.CreateRandomOrbitAround(TargetBody, TargetBody.Radius + (TargetBody.sphereOfInfluence - 120000), TargetBody.Radius + (TargetBody.sphereOfInfluence - 100000));
            var OldUT = Planetarium.GetUniversalTime();
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print(HyperdriveLogFormatter("UT updated. Jumping."));

            if (FlightGlobals.ActiveVessel != null)
            {
                print(HyperdriveLogFormatter("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value."));
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
                Debug.LogError(HyperdriveLogFormatter("Hyperdrive.WarpDriver.MedTechWarp has encountered an 'anomaly'. Jump canceled."));
                print("How on Kerbin did you even call this if there is no active vessel?");
                return;
            }
        }
    }
}
