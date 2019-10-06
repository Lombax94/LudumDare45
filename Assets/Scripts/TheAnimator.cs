using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAnimator : MonoBehaviour {

    Animator myAnimator;
    public int AnimState = 0;

    public void StartRunning() {
        AnimState = 1;
        myAnimator.SetInteger("State", AnimState);
    }

    public void StartFish() {
        AnimState = 2;
        myAnimator.SetInteger("State", AnimState);
    }

    public void StartIdle() {
        AnimState = 0;
        myAnimator.SetInteger("State", AnimState);

    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
