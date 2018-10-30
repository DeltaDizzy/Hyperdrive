using KSP.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hyperdrive
{
    class WarpDialog
    {
        private string WarpTitle = "Plancet Selector";
        List<CelestialBody> bodylist = FlightGlobals.Bodies;

        public void CloseDialog(PopupDialog dialog)
        {
            dialog.Dismiss();
        }

        private PopupDialog spawnDialog()
        {
            List<DialogGUIBase> dialog = new List<DialogGUIBase>();
            dialog.Add(new DialogGUILabel(Localizer.Format(WarpTitle)));
            dialog.Add(new DialogGUIVerticalLayout());
        }
    }
}
