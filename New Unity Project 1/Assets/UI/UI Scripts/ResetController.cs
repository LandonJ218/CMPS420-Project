using UnityEngine;
using System.Collections;

public class ResetController : MonoBehaviour {

    public MazeRefs[] mazes;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetMazes() {
        foreach (MazeRefs m in mazes) {
            m.CC.Teleport(m.CCSpawn);
            m.ResetNodes();
            m.CC.target = m.startNode;
            m.CC.isAtTarget = false;
        }
    }
}
