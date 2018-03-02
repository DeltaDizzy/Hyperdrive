/* 
 * Infinite ImprobabilityDrive for KSP 1.3.1
 * Copyright Mrcarrot 2018 for PartModule
 * Copyright DeltaDizzy 2018 for Config Node Parser and Log system improvements
 */

using Hyperdrive;
using Hyperdrive.ConfigParser;
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

    

    //Run on Game Startup
    public override void OnStart(StartState state)
    {
        //Print load confirmation to log
        Debug.Log(GeneralStuff.ImpDriveLogFormatter("ModuleInfiniteImprobabliltyDrive loaded"));
        ScreenMessages.PostScreenMessage("ModuleInfiniteImprobabilityDrive loaded. This partmodule gets a screen message because it's awesome. Deal with it. ", 5, ScreenMessageStyle.UPPER_CENTER);

        UrlDir.UrlConfig[] ImpDriveNodes;
        ImpDriveNodes = GameDatabase.Instance.GetConfigs("IMPDRIVE_CONFIG"); //Grab all IMPDRIVE nodes
        Debug.Log(GeneralStuff.ImpDriveLogFormatter("ConfigNode Parser loaded"));

    }

    [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
    public virtual void ImprobabilityDrive()
    {

        List<CelestialBody> Bodies = FlightGlobals.Bodies;
        int PlanetCount = Bodies.Count;
        float RandomLimitValue = (PlanetCount + 1);
        print(GeneralStuff.ImpDriveLogFormatter("Bodies loaded. Number of bodies: " + PlanetCount + "."));
        System.Random rnd = new System.Random();
        int TargetFGI = rnd.Next(1, PlanetCount);
        int ProbabilityGen = rnd.Next(1, (int)Unexistor2);

        if (ProbabilityGen == 32 && Hyperdrive.ConfigParser.ImpDriveConfig.allowExistenceFailure == true)
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
                Debug.Log(GeneralStuff.ImpDriveLogFormatter("Starting ImpDrive. Jumping to " + Bodies[TargetFGI]));
                ScreenMessages.PostScreenMessage("Starting ImpDrive. Jumping to " + Bodies[TargetFGI] + ".", 5, ScreenMessageStyle.UPPER_CENTER);
                WarpDriver.MedTechWarp(Bodies[TargetFGI], timeError);
            }
            else
            {
                Debug.Log("NullReferenceException: List " + Bodies + "Contains no instance of an object with type CelestialBody at list place " + TargetFGI + ".");
                ScreenMessages.PostScreenMessage("Sorry, the Improbabilty Drive cannot jump to that location. Normality Assert-I-Tron detected", 5, ScreenMessageStyle.UPPER_CENTER);
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
        ScreenMessages.PostScreenMessage(GeneralStuff.ImpDriveLogFormatter("starting. Jumping to body: " + Bodies[1] + "."), 5, ScreenMessageStyle.UPPER_CENTER);
        WarpDriver.MedTechWarp(Bodies[1], 23000);
    }

}
