using Hyperdrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ModuleInfiniteImprobabilityDrive : PartModule
{
    //determines an error in time
    [KSPField]
    public float timeError = 12000f;

    [KSPField]
    public static float Unexistor = 1f;

    [KSPField]
    public float Unexistor2 = (Unexistor + 101);



    public override void OnStart(StartState state)
    {
        print("ModuleInfiniteImprobabliltyDrive loaded");
        ScreenMessages.PostScreenMessage("ModuleInfiniteImprobabilityDrive loaded. This partmodule gets a screen message because it's awesome. Deal with it. ", 5, ScreenMessageStyle.UPPER_CENTER);

        UrlDir.UrlConfig[] ImpDriveNodes;
        ImpDriveNodes = GameDatabase.Instance.GetConfigs("IMPDRIVE_CONFIG"); //Grab all IMPDRIVE nodes

    }

    [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
    public virtual void Hyperdrive()
    {

        List<CelestialBody> Bodies = FlightGlobals.Bodies;
        int PlanetCount = Bodies.Count;
        float RandomLimitValue = (PlanetCount + 1);
        print("[Hyperdrive]: Bodies loaded. Number of bodies: " + PlanetCount + ".");
        System.Random rnd = new System.Random();
        int TargetFGI = rnd.Next(1, PlanetCount);
        int ProbabilityGen = rnd.Next(1, (int)Unexistor2);

        if (ProbabilityGen == 32 && ImpDriveConfig.allowExistenceFailure == true)
        {
            BadStuff.Unexist();
        }
        if (ProbabilityGen == 73 && ImpDriveConfig.allowKerbalDeath == true)
        {
            BadStuff.CrewDie();
        }
        if (ProbabilityGen == 42 && ImpDriveConfig.allowBadOrbit == true)
        {
            BadStuff.BadOrbit(TargetFGI);
        }
        else
        {
            if (Bodies[TargetFGI] != null)
            {
                print("[ImpDrive]: starting ImpDrive. Jumping to " + Bodies[TargetFGI] + ".");
                ScreenMessages.PostScreenMessage("[ImpDrive] Starting ImpDrive. Jumping to " + Bodies[TargetFGI] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
                WarpDriver.MedTechWarp(Bodies[TargetFGI], timeError);
            }
            else
            {
                Debug.Log("Exception: List " + Bodies + "Contains no instance of an object with type CelestialBody at list place " + TargetFGI + ". Throwing System.NullReferenceException.");
                ScreenMessages.PostScreenMessage("Sorry, the Improbabilty Drive cannot jump to that location. We're sorry but we can't do that, Dave", 5, ScreenMessageStyle.UPPER_CENTER);
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
        ScreenMessages.PostScreenMessage("[Hyperdrive]: starting.Jumping to body: " + Bodies[1] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
        WarpDriver.MedTechWarp(Bodies[1], 23000);
    }

}

public struct ImpDriveConfig
{
    //Module parameters
    public static string homeWorldName;
    public static bool allowKerbalDeath;
    public static bool allowExistenceFailure;
    public static bool allowBadOrbit;
    public ImpDriveConfig(string homeName, string allowDeath, string allowUnexist, string allowWrongOrbit)
    {
        homeWorldName = homeName;
        allowKerbalDeath = bool.Parse(allowDeath);
        allowExistenceFailure = bool.Parse(allowUnexist);
        allowBadOrbit = bool.Parse(allowWrongOrbit);

    }
}