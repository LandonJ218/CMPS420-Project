using UnityEngine;
using System.Collections;

public class MazeRefs : MonoBehaviour {
    public NewCapsuleController CC;
    public NodeModel[] nodes;
    public Transform CCSpawn;

    public void ResetNodes () {
        foreach (NodeModel n in nodes) {
            n.setProperty("hasVisited" , false);
        }
    }
}
