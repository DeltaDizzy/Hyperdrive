using System;
using System.Collections.Generic;

namespace HyperDrive
{
 public struct ImpDriveConfig
    {
        //Module parameters
        public string homeWorldName;
        public bool allowKerbalDeath;
        public bool allowExistenceFailure;
        public bool allowBadOrbit;
        public ImpDriveConfig(string homeWorldName, bool allowCrewDeath, bool allowUnexist, bool, alloBadOrbit)
        {
            homeWorldName
            body = b; 
            scale = ConfigNode.ParseVector3(s); 
            shader = Shader.Find(sh); 
            rotation = Quaternion.Euler(ConfigNode.ParseVector3(r)); 
            invertNormals = bool.Parse(inv); 
            this.tex = GameDatabase.Instance.GetTexture(tex, false); 
            this.type = type; 
            this.ignoreLight = bool.Parse(ignoreLight);
        }
    }
}
