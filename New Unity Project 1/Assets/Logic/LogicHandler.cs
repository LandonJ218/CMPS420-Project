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
    }

    behavior[] instructionList;

	public void loadInstructionList (List <InstructionPacker> userInstructions) {
        instructionList = new behavior[userInstructions.Count];
        for(int i = 0; i < userInstructions.Count; i++)
        {
            instructionList[i].direction = userInstructions.ElementAt(i).TargetNode;
            instructionList[i].property = userInstructions.ElementAt(i).TargetCondition;
        }
	}

    public NodeModel getTarget(NodeModel current)
    {
        NodeModel target = null;

        for (int i = 0; i < instructionList.Length; i++)
        {
            if (instructionList[i].direction == "North")
            {
                if ((current.GetNorth() != null) && (current.GetNorth().getProperty("DeadEnd") == false))
                {
                    if (current.GetNorth().getProperty(instructionList[i].property))
                    {
                        target = current.GetNorth();
                        return target;
                    }
                }
            }
            else if (instructionList[i].direction == "South")
            {
                if ((current.GetSouth() != null) && (current.GetSouth().getProperty("DeadEnd") == false))
                {
                    if (current.GetSouth().getProperty(instructionList[i].property))
                    {
                        target = current.GetSouth();
                        return target;
                    }
                }
            }
            else if (instructionList[i].direction == "East")
            {
                if ((current.GetEast() != null) && (current.GetEast().getProperty("DeadEnd") == false))
                {
                    if (current.GetEast().getProperty(instructionList[i].property))
                    {
                        target = current.GetEast();
                        return target;
                    }
                }
            }
            else if (instructionList[i].direction == "West")
            {
                if ((current.GetWest() != null) && (current.GetWest().getProperty("DeadEnd") == false))
                {
                    if (current.GetWest().getProperty(instructionList[i].property))
                    {
                        target = current.GetWest();
                        return target;
                    }
                }
            }
            else if (instructionList[i].direction == "Current")
            {
                current.CheckIfDeadEnd();
            }
        }

        return target;
    }	
}
