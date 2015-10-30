using UnityEngine;
using System.Collections;

public class PrioximitySensor : MonoBehaviour {
    [SerializeField] protected GameObject player;


    public bool prioximityPing(string tag, float radius) {
       int t = LayerMask.GetMask(tag);

        return Physics.CheckSphere(player.transform.position , radius, t);
    }
}
