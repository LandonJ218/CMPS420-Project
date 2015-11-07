using UnityEngine;
using System.Collections;

public class ScriptedControl : MonoBehaviour {
    [SerializeField] protected CapsuleController capcon;
    [SerializeField] protected SensorsManager sensors;
    [SerializeField] protected float acc;

    // Update is called once per frame
    void Update()
    {
        if (sensors.norDist > 2.0f)
        {
            capcon.zMov(true, acc);
            if (sensors.easDist > 2.0f)
            {
                capcon.xMov(true, acc);
            }
        }
        if (sensors.wesDist > 2.0f)
        {
            capcon.xMov(false, acc);
        }
        if (sensors.norDist < 2.0f && sensors.wesDist < 2.0f)
        { 
            if (sensors.easDist > 2.0f)
            {
                capcon.xMov(true, acc);
            }
            else
            {
                capcon.zMov(false, acc);
            }
        }
        
    }

    /*public void changeAcc(float newAcc) {
		acc = newAcc;
    } */

}
