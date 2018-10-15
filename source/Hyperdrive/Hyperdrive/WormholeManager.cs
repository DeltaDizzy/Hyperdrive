using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hyperdrive
{
    class WormholeManager : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
            string GameData = (KSPUtil.ApplicationRootPath + "/GameData");
        }
    }
}
