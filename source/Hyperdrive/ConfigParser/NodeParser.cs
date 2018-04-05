using System;
using System.Collections.Generic;

namespace Hyperdrive
{
	public class NodeParser
	{
		//Declare ConfigNode field and arroy of all configs. This will be important later
		public ConfigNode HDNode;
		UrlDir.UrlConfig[] nodeList;
		
		//Find all HYPERDRIVE_GLOBAL nodes, and store them in the nodeList
		nodeList = GameDatabase.Instance.GetConfigs("HYPERDRIVE_GLOBAL");
		
		if(nodeList.Length > 1)
		{
			Debug.LogWarning("No HYPERDRIVE_GLOBAL nodes found. What were/are you thinking?!")
		}
		
		foreach(UrlDir.UrlConfig config in nodeList)
            	{
			
            	}
	}
}
