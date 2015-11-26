using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class InstructionsHandler : MonoBehaviour {

    public List<GameObject> Instructions = new List<GameObject>();
    public GameObject insprefab;
    public RectTransform rc;

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

}
