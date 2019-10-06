using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHook : MonoBehaviour {

    public bool enableHit = false;
    public List<debreeMover> debree = new List<debreeMover>();



    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log ("HIT");
        if(enableHit == true) {
            debree.Add(collision.gameObject.GetComponent<debreeMover>());
           collision.gameObject.GetComponent<debreeMover>().DisableMovement = true;
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

}
