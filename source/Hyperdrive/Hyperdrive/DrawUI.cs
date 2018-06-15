using System.Collections.Generic;
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
        private MultiOptionDialog hyperDialog;
        public static Vector2 AnchorMin = new Vector2(0.5f, 1f);
        public static Vector2 AnchorMax = new Vector2(0.5f, 1f);
        public List<CelestialBody> bodylist = FlightGlobals.Bodies;



        /*
        public GUIStyle HyperdriveGUIStyle = new GUIStyle();
        public GUIStyle CreateStyle(GUIStyle style)
        {
            style.name = "HyperdriveGUIStyle";
            style.alignment = TextAnchor.MiddleCenter;
            style.border = new RectOffset();
            style.clipping = TextClipping.Clip;
            style.contentOffset = new Vector2(0,0);
            style.fixedHeight = 0;
            style.fixedWidth = 0;
            style.font = null;
            style.margin = new RectOffset();
            style.padding = new RectOffset();
            style.richText = true;
            style.stretchHeight = true;
            style.stretchWidth = true;
            style.wordWrap = true;
            return style;
        }

        GUISkin HyperdriveSkin = new GUISkin();
        public void PopulateSkin(GUISkin skin, GUIStyle style)
        {
            skin.font = style.font;
            skin.box = style;
            skin.button = style;
            skin.toggle = style;
            skin.label = style;
            skin.textField = style;
            skin.textArea = style;
            skin.window = style;
            skin.horizontalSlider = style;
            skin.horizontalSliderThumb = style;
            skin.horizontalScrollbar = style;
            skin.horizontalScrollbarThumb = style;
            skin.horizontalScrollbarLeftButton = style;
            skin.horizontalScrollbarRightButton = style;
            skin.verticalSlider = style;
            skin.verticalSliderThumb = style;
            skin.verticalScrollbar = style;
            skin.verticalScrollbarThumb = style;
            skin.verticalScrollbarUpButton = style;
            skin.verticalScrollbarDownButton = style;
        }
        */

        private PopupDialog CreateDialog(List<CelestialBody> bodylist)
        {
            List<DialogGUIBase> dialog = new List<DialogGUIBase>
            {
                new DialogGUIHorizontalLayout(true, false, 0, new RectOffset(), TextAnchor.UpperCenter, new DialogGUIBase[]
            {
                new DialogGUILabel("Choose your destination")
            })
            };

            HyperdriveTravel = PopupDialog.SpawnPopupDialog(hyperDialog, false, HighLogic.UISkin);
            return HyperdriveTravel;

        }

        private void CreateAppLaunchButton()
        {

        }
    }
}
