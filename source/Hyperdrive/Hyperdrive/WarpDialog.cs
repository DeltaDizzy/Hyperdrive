using KSP.Localization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hyperdrive
{
    public class WarpDialog : MonoBehaviour
    {
        private string WarpTitle = "Planet Selector";
        List<CelestialBody> bodylist = FlightGlobals.Bodies;
        CelestialBody target;
        public void CloseDialog(PopupDialog dialog)
        {
            dialog.Dismiss();
        }

        private PopupDialog CreateDialog()
        {
            List<DialogGUIBase> dialog = new List<DialogGUIBase>();
            dialog.Add(new DialogGUILabel(Localizer.Format(WarpTitle)));
            dialog.Add(new DialogGUIVerticalLayout());
            DialogGUIBase[] scrolllist = new DialogGUIBase[bodylist.Count];
            scrolllist[0] = new DialogGUIContentSizer(ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.PreferredSize, true);
            foreach (CelestialBody body in bodylist)
            {
                dialog.Add(new DialogGUIButton(body.displayName ?? body.name,
                    delegate
                    {
                        target = body;
                        StartWarp(WarpMode.Targeted);
                    }
                    ));
            }
        }
    }
}
