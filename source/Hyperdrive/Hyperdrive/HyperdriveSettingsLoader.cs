using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace BMSHyperdrive
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class BMSHyperdriveSettingsLoader : GameParameters.CustomParameterNode
    {
        private static readonly BMSHyperdriveSettingsLoader instance = new BMSHyperdriveSettingsLoader();
        public static BMSHyperdriveSettingsLoader Instance
        {
            get
            {
                return instance;
            }
        }


        #region CustomParams
        [GameParameters.CustomParameterUI("Kerbals can die?", toolTip = "If checked, each jump has a chance to kill a kerbal.")]
        public bool allowKerbalDeath = true;

        [GameParameters.CustomParameterUI("Orbit can be bad?", toolTip = "If checked, each jump has a chance to give you a bad orbit.")]
        public bool allowBadOrbit = true;

        [GameParameters.CustomParameterUI("Existence Failure possible?", toolTip = "If checked, each jump has a chance to kill your crew and delete your ship.")]
        public bool allowExistFail = true;

        
        public static bool AllowExistFail
        {
            get
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                return settings.allowExistFail;
            }
            set
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                settings.allowExistFail = value;
            }
        }

        public static bool AllowKerbalDeath
        {
            get
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                return settings.allowKerbalDeath;
            }
            set
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                settings.allowKerbalDeath = value;
            }
        }

        public static bool AllowBadOrbit
        {
            get
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                return settings.allowBadOrbit;
            }
            set
            {
                BMSHyperdriveSettingsLoader settings = HighLogic.CurrentGame.Parameters.CustomParams<BMSHyperdriveSettingsLoader>();
                settings.allowBadOrbit = value;
            }
        }
        #endregion

        #region CustomParameterNode
        public override string DisplaySection
        {
            get
            {
                return Section;
            }
        }
        public override string Section
        {
            get
            {
                return "BMSHyperdrive";
            }
        }
        public override string Title
        {
            get
            {
                return "BMSHyperdrive Global Settings";
            }
        }
        public override int SectionOrder
        {
            get
            {
                return 2;  //Show deference to the grandmaster
            }
        }
        public override GameParameters.GameMode GameMode
        {
            get
            {
                return GameParameters.GameMode.ANY;
            }
        }
        public override bool HasPresets
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region Reader
        public ConfigNode[] hyperNodes;
        public const string settingsFilename = "BMSHyperdriveSettings.cfg";
        public const string settingsNode = "BMSHyperdriveSettings";
        public ConfigNode[] GetNodes()
        {
            hyperNodes = GameDatabase.Instance.GetConfigNodes(settingsNode);
            return hyperNodes;
        }

        public ConfigNode GetSettingsFromFile()
        {
            string settingsFile = KSPUtil.ApplicationRootPath.Replace("\\", "/") + "GameData/" + settingsFilename;

            if (!System.IO.File.Exists(settingsFile))
            {
                return null;
            }

            ConfigNode node = ConfigNode.Load(settingsFilename);
            if (node.HasNode(settingsNode))
            {
                node = node.GetNode(settingsNode);
            }
            return node;
        }
        public void Awake()
        {
            ConfigNode BMSHyperdrive = new ConfigNode("BMSHyperdrive");
            BMSHyperdrive = BMSHyperdrive.GetNode("BMSHyperdrive");

            if (BMSHyperdrive.HasValue("allowDeath"))
            {
                allowExistFail = bool.Parse(BMSHyperdrive.GetValue("allowDeath"));
            }
            if (BMSHyperdrive.HasValue("allowUnexist"))
            {
                allowExistFail = bool.Parse(BMSHyperdrive.GetValue("allowUnexist"));
            }
            if (BMSHyperdrive.HasValue("allowBadOrbit"))
            {
                allowBadOrbit = bool.Parse(BMSHyperdrive.GetValue("allowBadOrbit"));
            }
        }
        #endregion
    }
}
