using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LogicHandler : MonoBehaviour {

    struct behavior
    {
        public string direction;
        public string property;
        public string action;
    }

    behavior[] instructionList;

	void loadInstructionList (List <GameObject> userInstructions) {
        instructionList = new behavior[userInstructions.Count];
        for(int i = 0; i < userInstructions.Count; i++)
        {
            // The userInstruction references do not currently exist
            //instructionList[i].direction = userInstructions.ElementAt(i).iDirection;
            //instructionList[i].property = userInstructions.ElementAt(i).iProperty;
            //instructionList[i].action = userInstructions.ElementAt(i).iAction;
        }
	}
	
}
