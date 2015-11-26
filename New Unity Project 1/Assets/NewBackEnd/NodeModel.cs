using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeModel : MonoBehaviour {

    [SerializeField] protected NodeModel NorthNode;
    [SerializeField] protected NodeModel EastNode;
    [SerializeField] protected NodeModel WestNode;
    [SerializeField] protected NodeModel SouthNode;

    [SerializeField] protected GameObject Finish;

    public Material VisitMat;
    public Material NoVisitMat;
    public Material DeadEndMat;
    
    //Testing
    public bool isGoal;

    public Dictionary<string , bool> properties;

	// Use this for initialization
	void Start () {
        properties = new Dictionary<string , bool>();
        properties.Add("hasVisited" , false);
        properties.Add("isDeadEnd", false);
        properties.Add("isGoal" , isGoal);
        if(isGoal) {
            Finish.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public Transform GetTransform() {
        return GetComponent<Transform>();
    }

    public NodeModel GetNorth() {
        if(NorthNode != null) {
            return NorthNode;
        } else {
            return null;
        }
    }
    public NodeModel GetEast() {
        if (EastNode != null) {
            return EastNode;
        } else {
            return null;
        }
    }
    public NodeModel GetWest() {
        if (WestNode != null) {
            return WestNode;
        } else {
            return null;
        }
    }
    public NodeModel GetSouth() {
        if (SouthNode != null) {
            return SouthNode;
        } else {
            return null;
        }
    }

    public bool getProperty(string propertyName) {
        bool propValue;
        if(properties.TryGetValue(propertyName, out propValue)) {
            return propValue;
        } else {
            print("Failure to access: " + propertyName);
            return false;
        }
    }
    public void setProperty(string propertyName, bool newValue) {
        bool propValue;
        if(properties.TryGetValue(propertyName, out propValue)) {
            properties[propertyName] = newValue;
        } else {
            print("Property does not exist");
        }
    }
    public void ApplyVisitMat() {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        MR.material = VisitMat;
    }
    public void ResetVisitMat() {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        MR.material = NoVisitMat;
    }
    public void ResetDeadEnd() {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        MR.material = NoVisitMat;
    }
    public void CheckIfDeadEnd() {
        int i = 0;
        if (NorthNode != null) i++;
        if (EastNode != null) i++;
        if (WestNode != null) i++;
        if (SouthNode != null) i++;

        if(i <= 1 && isGoal != true) {
            setProperty("isDeadEnd" , true);
            MeshRenderer MR = GetComponent<MeshRenderer>();
            MR.material = DeadEndMat;
        }
    }


}
