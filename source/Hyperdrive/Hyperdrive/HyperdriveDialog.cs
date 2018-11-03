using KSP.Localization;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hyperdrive
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class HyperdriveDialog : MonoBehaviour
    {
        private string WarpTitle = "Planet Selector";
        List<CelestialBody> bodylist = FlightGlobals.Bodies;
        public static CelestialBody target;
        private PopupDialog pop;
        private Part drive;
        private PartModule mod;
        private List<Part> parts;
        private enum TechLevel
        {
            Low = 0,
            Med = 1
        }
        Vessel aves = FlightGlobals.ActiveVessel;

        private void Start()
        {
            CreateDialog();
        }
        public void CloseDialog(PopupDialog pop)
        {
            pop.Dismiss();
        }

        private MultiOptionDialog CreateDialog()
        {
            List<DialogGUIBase> dialogBase = new List<DialogGUIBase>();
            DialogGUIBase[] scrollList = new DialogGUIBase[bodylist.Count];
            scrollList[0] = new DialogGUIContentSizer(ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.PreferredSize, true);
            TechLevel tLev = new TechLevel();
            foreach (CelestialBody body in bodylist)
            {
                if ()
                {

                }

                dialogBase.Add(new DialogGUIButton(body.displayName ?? body.name, //LowTechWarp Button
                    delegate
                    {
                        target = body;

                        // Gets a list of parts on a vessel with the specified PartModule
                        if (mod.part.Modules.Contains<ModuleMedTechWarp>())
                        {
                            parts = WarpHelp.PartsWithModule(aves, typeof(ModuleMedTechWarp));
                            tLev = TechLevel.Med;
                        }
                        else
                        {
                            parts = WarpHelp.PartsWithModule(aves, typeof(ModuleLowTechWarp));
                            tLev = TechLevel.Low;
                        }

                        if (tLev == TechLevel.Med)
                        {
                            if (ModuleMedTechWarp.isModuleActive == true)
                            {
                                ModuleMedTechWarp.MedTechWarp(target, 50000);
                                print(Utils.Log("MedTechWarp activated. Enjoy your flight!"));
                            }
                        }
                        else if (tLev == TechLevel.Low) //TODO: Implement button functionality
                        {
                            if (ModuleLowTechWarp.isModuleActive == true)
                            {
                                ModuleLowTechWarp.LowTechWarp(target, 100000);
                                print(Utils.Log("LowTechWarp activated. Enjoy your flight!"));
                            }
                        }


                    }
                    ));
            }
            MultiOptionDialog dialog = new MultiOptionDialog("HyperDialog", "Please select a planet", "Hyperdrive Planet Selector", HighLogic.UISkin, dialogBase.ToArray());

            return dialog;
        }

        private PopupDialog SpawnDialog(MultiOptionDialog dialog)
        {
            pop = PopupDialog.SpawnPopupDialog(Vector2.one, Vector2.one, dialog, false, HighLogic.UISkin);
            return pop;
        }
    }
}
