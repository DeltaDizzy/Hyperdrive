using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using KSP.UI.Screens;
using KSP.Localization;
using TMPro;

namespace BMSHyperdrive
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class DrawUI : MonoBehaviour
    {
        private void Awake()
        {
            List<CelestialBody> targetlist = new List<CelestialBody>();
            targetlist = FlightGlobals.Bodies;

            //targetBody = targetlist.Find();
        }
        //Constants
        private const float width = 370.0f;
        private const float height = 425.0f;
        private const float button_width = 75.0f;
        private const float button_height = 25.0f;
        private const float targetbutton_width = 120.0f;
        private const float slider_width = 170.0f;
        private const float error_slidermin = 1.0f;
        private const float error_slidermax = 50.0f;
        private const int page_padding = 10;
        

        //version
        private static string version = " v0.1.0";

        //Page enum
        private enum PageType
        {
            BODYSELECT = 0,
            WARPSETTINGS
        }

        CelestialBody targetBody;

        private static int spawned = 0;
        private static bool visible = false;

        //GUI elements
        private static MultiOptionDialog multi_dialog;
        private static PopupDialog popup_dialog;
        private static DialogGUIBox page_box;

        private static DialogGUIVerticalLayout target_page;
        private static DialogGUIVerticalLayout settings_page;

        private static DialogGUILabel destination_label;
        private static DialogGUILabel prompt;

    }
}
