﻿/* 
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
        Debug.Log(Utils.ImpDriveLogFormatter("ModuleInfiniteImprobabliltyDrive loaded"));
        ScreenMessages.PostScreenMessage("ModuleInfiniteImprobabilityDrive loaded. This partmodule gets a screen message because it's awesome. Deal with it. ", 5, ScreenMessageStyle.UPPER_CENTER);

        UrlDir.UrlConfig[] ImpDriveNodes;
        ImpDriveNodes = GameDatabase.Instance.GetConfigs("IMPDRIVE_CONFIG"); //Grab all IMPDRIVE nodes
        Debug.Log(Utils.ImpDriveLogFormatter("ConfigNode Parser loaded"));

    }

    [KSPEvent(active = true, externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Take Me Somewhere", unfocusedRange = 90)]
    public virtual void ImprobabilityDrive()
    {

        List<CelestialBody> Bodies = FlightGlobals.Bodies;
        int PlanetCount = Bodies.Count;
        float RandomLimitValue = (PlanetCount + 1);
        print(Utils.ImpDriveLogFormatter("Bodies loaded. Number of bodies: " + PlanetCount + "."));
        System.Random rnd = new System.Random();
        int TargetFGI = rnd.Next(1, PlanetCount);
        int ProbabilityGen = rnd.Next(1, (int)Unexistor2);

<<<<<<< HEAD
        if (ProbabilityGen == 32 && Hyperdrive.ConfigParser.HyperdriveConfigLoader.allowExistenceFailure == true)
=======
        if (ProbabilityGen == 32 && Hyperdrive.ConfigParser.HyperDriveConfigLoader.allowExistenceFailure == true)
>>>>>>> b7ca82db6ad445eee78c4d46d5d84847a1f6f846
        {
            BadStuff.Unexist();
        }
        if (ProbabilityGen == 73 && HyperDriveConfigLoader._allowKerbalDeath == true)
        {
            BadStuff.CrewDie();
        }
        if (ProbabilityGen == 42 && HyperDriveConfigLoader._allowBadOrbit == true)
        {
            BadStuff.BadOrbit(TargetFGI);
        }
        else
        {
            if (Bodies[TargetFGI] != null)
            {
                Debug.Log(Utils.ImpDriveLogFormatter("Starting ImpDrive. Jumping to " + Bodies[TargetFGI]));
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
        ScreenMessages.PostScreenMessage(Utils.ImpDriveLogFormatter("starting. Jumping to body: " + Bodies[1] + "."), 5, ScreenMessageStyle.UPPER_CENTER);
        WarpDriver.MedTechWarp(Bodies[1], 23000);
    }

}
<<<<<<< HEAD

public struct ImpDriveConfig
{
    //Module parameters
    public static string homeWorldName;
    public static bool allowKerbalDeath;
    public static bool allowExistenceFailure;
    public static bool allowBadOrbit;

    //Config processing
    public ImpDriveConfig(string homeName, string allowDeath, string allowUnexist, string allowWrongOrbit)
    {
        homeWorldName = homeName;
        allowKerbalDeath = bool.Parse(allowDeath);
        allowExistenceFailure = bool.Parse(allowUnexist);
        allowBadOrbit = bool.Parse(allowWrongOrbit);

    }
}
=======
>>>>>>> 47c858ad4db8a1a163a470063019778dc32f39dd
