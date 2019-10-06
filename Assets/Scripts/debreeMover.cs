using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debreeMover : MonoBehaviour {

    public SpriteRenderer mySprite;
    public Vector3 travelGoal = Vector3.zero;
    public float Speed = 4;

    public bool DisableMovement = false;
    public DebreeType myType;

    // Update is called once per frame
    void Update()
    {
        if(DisableMovement == false) {

        transform.position = Vector3.MoveTowards(transform.position, travelGoal, 0.5f * Time.deltaTime * Speed);
        if (Vector3.Distance(transform.position, travelGoal) < 0.01f)
            Destroy(gameObject);
        }
    }



}
