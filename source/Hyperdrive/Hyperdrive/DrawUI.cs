using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using KSP.UI.Screens;

namespace Hyperdrive
{
    class DrawUI : MonoBehaviour
    {
        private ApplicationLauncherButton button;
        private Texture2D AppTex;
        private bool DialogWindowDisplayed;
        private PopupDialog HyperdriveTravel { get; set; }
        public static Vector2 AnchorMin = new Vector2(0.5f, 1f);
        public static Vector2 AnchorMax = new Vector2(0.5f, 1f);
        public List<CelestialBody> bodylist = FlightGlobals.Bodies;

        private PopupDialog createDialog(List<CelestialBody> bodylist)
        {
            List<DialogGUIBase> dialog = new List<DialogGUIBase>();

            dialog.Add(new DialogGUIHorizontalLayout(true, false, 0, new RectOffset(), TextAnchor.UpperCenter, new DialogGUIBase[]
            {
                new DialogGUILabel("Choose your destination");
            }));
        }

    }
}
