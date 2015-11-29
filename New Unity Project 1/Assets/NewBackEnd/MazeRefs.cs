using UnityEngine;
using System.Collections;

public class MazeRefs : MonoBehaviour {
    public NewCapsuleController CC;
    public NodeModel[] nodes;
    public Transform CCSpawn;
    public NodeModel startNode;

    public void ResetNodes () {
        foreach (NodeModel n in nodes) {
            n.setProperty("Visited" , false);
            n.setProperty("DeadEnd",false);
            n.ResetVisitMat();
            
            CC.isPlay = false;
        }
    }
}
