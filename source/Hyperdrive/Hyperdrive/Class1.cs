using System;
using System.Collections.Generic;
using Hyperdrive.ConfigParser;
using UnityEngine;

namespace Hyperdrive
{
    public class ModuleInfiniteImprobabilityDrive : PartModule
    {
        //determines an error in time
        [KSPField]
        public float timeError = 12000f;

        [KSPField]
        public static float Unexistor = 1f;

        [KSPField]
        public float Unexistor2 = (Unexistor + 101);

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
        public virtual void Hyperdrive()
        {

            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            int PlanetCount = Bodies.Count;
            float RandomLimitValue = (PlanetCount + 1);
            print(Utils.Log("Bodies loaded. Number of bodies: " + PlanetCount + "."));
            System.Random rnd = new System.Random();
            int TargetFGI = rnd.Next(1, PlanetCount);
            int ProbabilityGen = rnd.Next(1, (int)Unexistor2);
            if (ProbabilityGen == 32 && HyperdriveConfigLoader._allowExistFail)
            {
                BadStuff.Unexist();
            }
            if (ProbabilityGen == 73 && HyperdriveConfigLoader._allowKerbalDeath)
            {
                BadStuff.CrewDie();
            }
            if (ProbabilityGen == 42 && HyperdriveConfigLoader._allowBadOrbit)
            {
                BadStuff.BadOrbit(TargetFGI);
            }
            else
            {
                if (Bodies[TargetFGI] != null)
                {
                    print(Utils.Log("starting. Jumping to body: " + Bodies[TargetFGI] + "."));
                    ScreenMessages.PostScreenMessage("Hyperdrive starting.Jumping to body: " + Bodies[TargetFGI] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
                    WarpDriver.MedTechWarp(Bodies[TargetFGI], timeError);
                }
                else
                {
                    Debug.Log(Utils.Log("NullReferenceException: List " + Bodies + "Contains no instance of an object of type CelestialBody at index " + TargetFGI + "."));
                    ScreenMessages.PostScreenMessage("Sorry, the hyperdrive cannot jump to that location. We also cannot open the pod bay doors. Blame the engineers.", 5, ScreenMessageStyle.UPPER_CENTER);
                    NullRef();
                    return;
                }
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
            ScreenMessages.PostScreenMessage("Hyperdrive starting.Jumping to body: " + Bodies[1] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }
        public override void OnStart(StartState state)
        {
            print(Utils.Log("ModuleSomewhereElseDrive loaded."));
            ScreenMessages.PostScreenMessage("ModuleSomewhereElseDrive loaded. This partmodule gets a screen message.", 5, ScreenMessageStyle.UPPER_CENTER);
        }
    }
    public class ModuleSomewhereElsePlus : PartModule
    {
        //determines the error in time- notice how much smaller the multiplier is
        [KSPField]
        public float timeError = 2f;

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
        public virtual void Hyperdrive()
        {

            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            int PlanetCount = Bodies.Count;
            int RandomLimiter = (PlanetCount + 1);
            print(Utils.Log("Bodies loaded. Number of bodies: " + PlanetCount + "."));
            System.Random rnd = new System.Random();
            //Linux is the best- TMSP
            int TargetFGI = rnd.Next(1, RandomLimiter);
            if (Bodies[TargetFGI] != null)
            {
                ScreenMessages.PostScreenMessage("Hyperdrive starting.Jumping to body: " + Bodies[TargetFGI] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
                print(Utils.Log("starting. Jumping to body: " + Bodies[TargetFGI] + "."));
                WarpDriver.MedTechWarp(Bodies[TargetFGI], timeError);
            }
            else
            {
                ScreenMessages.PostScreenMessage("Sorry, the hyperdrive cannot jump to that location. We also cannot open the pod bay doors. Blame the engineers.", 5, ScreenMessageStyle.UPPER_CENTER);
                NullRef();
                return;
            }
        }

        private static void NullRef()
        {
            throw new NullReferenceException();
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back to Kerbin", unfocusedRange = 90)]
        public virtual void BackHomeDrive()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }
        public override void OnStart(StartState state)
        {
            print(Utils.Log("ModuleSomewhereElseDrive loaded."));
        }
    }
    public class ModuleSelectiveHyperdrive : PartModule
    {
        /*Template for a Hyperdrive KSPEvent:
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "NAME_HERE", unfocusedRange = 90)]
        public virtual void NAME_HERE()
        {
            WarpDriver.MedTechWarp(Bodies[FGI_HERE], 23000);
        }
        */
        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back to Kerbin", unfocusedRange = 90)]
        public virtual void BackHomeDrive()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Mun", unfocusedRange = 90)]
        public virtual void Mun()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[2], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Minmus", unfocusedRange = 90)]
        public virtual void Minmus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[3], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Moho", unfocusedRange = 90)]
        public virtual void Moho()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[4], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Eve", unfocusedRange = 90)]
        public virtual void Eve()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[5], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Duna", unfocusedRange = 90)]
        public virtual void Duna()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[6], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Ike", unfocusedRange = 90)]
        public virtual void ILikeIke()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[7], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Jool", unfocusedRange = 90)]
        public virtual void JoolIsCool()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[8], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Laythe", unfocusedRange = 90)]
        public virtual void Laythe()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[9], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Vall", unfocusedRange = 90)]
        public virtual void Vall()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[10], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Bop", unfocusedRange = 90)]
        public virtual void BoppingBop()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[11], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Tylo", unfocusedRange = 90)]
        public virtual void Tylo()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[12], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Gilly", unfocusedRange = 90)]
        public virtual void ThatOneSpeck()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[13], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Pol", unfocusedRange = 90)]
        public virtual void Pol()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[14], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Dres", unfocusedRange = 90)]
        public virtual void NobodyLikesDres()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[15], 23000);
        }

        [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Eeloo", unfocusedRange = 90)]
        public virtual void Eeloo()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[16], 23000);
        }
    }
}