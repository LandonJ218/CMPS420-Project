using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastCompassManager : MonoBehaviour {
    //As a note, I use the Mnemonic "NEWS" to remember my compass directions when I first learned it so it stuck with me

    [SerializeField] protected RaycastManager NRay;
    [SerializeField] protected RaycastManager ERay;
    [SerializeField] protected RaycastManager WRay;
    [SerializeField] protected RaycastManager SRay;

    public float getDistances(int i) {
        if (i == 0) {
            return NRay.getDist();
        } else if (i == 1) {
            return ERay.getDist();
        } else if (i == 2) {
            return WRay.getDist();
        } else if (i == 3) {
            return SRay.getDist();
        } else {
            return -99f;
        }
    }
}
