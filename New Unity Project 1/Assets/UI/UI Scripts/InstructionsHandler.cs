using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class InstructionsHandler : MonoBehaviour {

    public List<GameObject> Instructions = new List<GameObject>();
    public GameObject insprefab;
    public RectTransform rc;
    public LogicHandler LH;

    public Text MessageText;
    public bool running;

    public void addINS() {
        GameObject nins = Instantiate(insprefab);
        nins.transform.SetParent(this.transform,false);
        nins.transform.SetAsLastSibling();
        Instructions.Add(nins);

        InstructionPacker IP = nins.GetComponent<InstructionPacker>();
        IP.IH = this;
    }

    public void RemoveIns(GameObject RootINS) {
        Instructions.Remove(RootINS);
    }

    public void GetINS(int i) {
        //Instructions.IndexOf(i)
        //Grab the stuff
        //Return the struct
    }
    public void PackInstructions() {
        if (!running) {

            List<InstructionPacker> IP = new List<InstructionPacker>();
            foreach (GameObject G in Instructions) {
                IP.Add(G.GetComponent<InstructionPacker>());
            }

            if (IP.Count != 0) {
                LH.loadInstructionList(IP);
                running = true;
            } else {
                MessageText.text = "At least one instruction\nmust be present";
            }

        } else {
            MessageText.text = "Please wait or hit the\nreset button";
        }
    }

    public void MazePlayState(bool st) {
        running = st;

    }
}
