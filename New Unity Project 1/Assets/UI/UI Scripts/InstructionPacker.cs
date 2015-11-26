using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionPacker : MonoBehaviour {

    //UI stuff
    public Dropdown Direction;
    public Dropdown Check;
    public Text EventName;
    public InstructionsHandler IH;

    //Data Stuff
    public string TargetNode;
    public string TargetCondition;

    void OnGUI() {
        //TargetNode
        TargetNode = Direction.captionText.text;
        TargetCondition = Check.captionText.text;
        if (TargetCondition == "DeadEnd") {
            EventName.text = "CheckDE";
        } else if(TargetNode == "Current" && (TargetCondition == "Visited" || TargetCondition == "NotVisited" || TargetCondition == "Goal")) {
            EventName.text = "No Action"; 
        } else {
            EventName.text = "Move";
        }
    }

    public void deleteThis() {
        IH.RemoveIns(gameObject);
        Destroy(gameObject);
    }
}
