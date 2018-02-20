using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hyperdrive.API.GPP
{
    public class ModuleGPPHDrive : PartModule
    {
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Back to Gael", unfocusedRange = 90)]
        public virtual void BackHomeDrive()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[1], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Ceti", unfocusedRange = 90)]
        public virtual void Ceti()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[2], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Icarus", unfocusedRange = 90)]
        public virtual void Icarus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[3], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Augustus", unfocusedRange = 90)]
        public virtual void Augustus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[4], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Otho", unfocusedRange = 90)]
        public virtual void Otho()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[5], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Tellumo", unfocusedRange = 90)]
        public virtual void Tellumo()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[6], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Thalia", unfocusedRange = 90)]
        public virtual void Thalia()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[7], 23000);
        }
            [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Eta", unfocusedRange = 90)]
        public virtual void Eta()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[8], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Niven", unfocusedRange = 90)]
        public virtual void Niven()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[9], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Iota", unfocusedRange = 90)]
        public virtual void Iota()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[10], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Lili", unfocusedRange = 90)]
        public virtual void Lili()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[11], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Gratian", unfocusedRange = 90)]
        public virtual void Gratian()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[12], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Geminus", unfocusedRange = 90)]
        public virtual void Geminus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[13], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Hephaestus", unfocusedRange = 90)]
        public virtual void Hephaestus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[14], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Jannah", unfocusedRange = 90)]
        public virtual void Jannah()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[15], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Gauss", unfocusedRange = 90)]
        public virtual void Gauss()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[16], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Loki", unfocusedRange = 90)]
        public virtual void Loki()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[17], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Catullus", unfocusedRange = 90)]
        public virtual void Catullus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[18], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Tarsiss", unfocusedRange = 90)]
        public virtual void Tarsiss()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[19], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Nero", unfocusedRange = 90)]
        public virtual void Nero()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[20], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Hadrian", unfocusedRange = 90)]
        public virtual void Hadrian()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[21], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Narisse", unfocusedRange = 90)]
        public virtual void Narisse()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[22], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Muse", unfocusedRange = 90)]
        public virtual void Muse()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[23], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Minona", unfocusedRange = 90)]
        public virtual void Minona()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[24], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Agrippina", unfocusedRange = 90)]
        public virtual void Agrippina()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[25], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Julia", unfocusedRange = 90)]
        public virtual void Julia()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[26], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Hox", unfocusedRange = 90)]
        public virtual void Hox()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[27], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Argo", unfocusedRange = 90)]
        public virtual void Argo()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[28], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Leto", unfocusedRange = 90)]
        public virtual void Leto()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[29], 23000);
        }
        [KSPEvent(externalToEVAOnly = true, guiActive = true, guiActiveEditor = false, guiActiveUnfocused = true, guiName = "Jump to Grannus", unfocusedRange = 90)]
        public virtual void Grannus()
        {
            List<CelestialBody> Bodies = FlightGlobals.Bodies;
            WarpDriver.MedTechWarp(Bodies[30], 23000);
        }
    }
}
