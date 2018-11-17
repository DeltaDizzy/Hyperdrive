using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BMSHyperdrive;

namespace BMSHyperdrive
{
    public class ModuleMedTechWarp : PartModule
    {
        [KSPField]
        public static bool isModuleActive;

        public static void MedTechWarp(CelestialBody TargetBody, float UTChange)
        {
            print(Utils.Log("BMSBMSHyperdrive.WarpDriver.MedTechWarp is Triggered. Beginning jump drive action."));

            //Ccreate orbital params and change UT
            var orbit = Orbit.CreateRandomOrbitAround(TargetBody, TargetBody.Radius + (TargetBody.sphereOfInfluence - 120000), TargetBody.Radius + (TargetBody.sphereOfInfluence - 100000));
            var OldUT = Planetarium.GetUniversalTime();
            var NewUT = (OldUT + UTChange);
            Planetarium.SetUniversalTime(NewUT);
            print(Utils.Log("UT updated. Jumping."));

            if (FlightGlobals.ActiveVessel != null)
            {
                print(Utils.Log("Activating WarpDrive, property FlightGlobals.ActiveVessel has a value."));
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
                Debug.LogError(Utils.Log("BMSHyperdrive.WarpDriver.MedTechWarp has encountered an 'anomaly'. Jump canceled."));
                print(Utils.Log(String.Format("How on ", FlightGlobals.GetHomeBodyDisplayName(), "did you even call this if there is no active vessel?")));
                return;
            }
        }
    }
}
