using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LogicHandler : MonoBehaviour {

    public Text Message;

    struct behavior
    {
        public string direction;
        public string property;
        public string action;
    }

    behavior[] instructionList;

	public void loadInstructionList (List <InstructionPacker> userInstructions) {
        instructionList = new behavior[userInstructions.Count];
        for(int i = 0; i < userInstructions.Count; i++)
        {
            // The userInstruction references do not currently exist
            instructionList[i].direction = userInstructions.ElementAt(i).TargetNode;
            instructionList[i].property = userInstructions.ElementAt(i).TargetCondition;
            //instructionList[i].action = userInstructions.ElementAt(i).iAction;
        }
	}
	
}
