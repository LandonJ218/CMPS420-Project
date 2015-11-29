using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewCapsuleController : MonoBehaviour {

    //Movement
    public NodeModel target;
    public NodeModel current;
    public float speed;
    float tolerance = .1f;
    protected CharacterController CC;
    protected LogicHandler LH;
    
    //Control Vars
    public bool isAtTarget;
    public bool isTestCase;
    public bool isPlay;

    //Text
    public Text msg;

    // Use this for initialization
    void Start () {
        LH = GetComponent<LogicHandler>();
        CC = GetComponent<CharacterController>();
        isAtTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        //WARNING! UNCOMMENT THE COMMENTED MESSAGE TEXT ONLY IN THE FINAL MAZE!
        if (isPlay) {
            if (isTestCase) {
                //msg.text = "Running";
                testCase();
            } else {
                //here should be a logical controller check to ensure that it does not run if the user has no instructions
                msg.text = "Running";
                if (isAtTarget && target.isGoal == true)
                {
                    LH.Message.text = "YOU WIN!!!";
                    isPlay = false;
                }
                else if (!isAtTarget)
                {
                    if (target != null)
                    {
                        GoToTarget();
                    }
                    else
                    {
                        // capsule doesnt know what to do code here
                        LH.Message.text = "Capsule doesn't know\nwhat to do...";
                    }

                }
                else
                {
                    current = target;
                    target = LH.getTarget(current);
                    isAtTarget = false;
                }
            }
        }

	}


    void testCase() {
        //TODO: Insert old code     
    }

    void GoToTarget() {
        Transform NodePos = target.GetTransform();
        Vector3 Offset = NodePos.transform.position - transform.position;
        if(Offset.magnitude > tolerance) {
            Offset = Offset.normalized * (speed * 3);
            CC.Move(Offset*Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Node")
        {
            if (other.gameObject.GetInstanceID() == target.gameObject.GetInstanceID())
            {
                isAtTarget = true;
                target.setProperty("Visited" , true);
                target.ApplyVisitMat();

                if(isTestCase) {
                    target.CheckIfDeadEnd();
                }
            }
        }
    }

    public void Teleport(Transform t) {
        CC.gameObject.transform.position = t.position;
    }


}
