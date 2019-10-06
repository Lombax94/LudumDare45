using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CollisionMap map;
   public TheAnimator myanim;
    public SpriteRenderer myrenderer;

    public int x = 0;
    public int y = 0;
  public  Vector3 movevector = Vector3.zero;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        x = 5;
        y = 5;
        movevector.x = 5.5f;
        movevector.y = 5.5f;
    }

    public bool moving = false;

    // Update is called once per frame
    void Update() {

        if (moving == false) {
           


                if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    if (map.MapCollision[x - 1, y] != 1) {
                if (myanim.AnimState == 0) {
                    myanim.StartRunning();
                        x -= 1;
                        movevector.x -= 1;
                        moving = true;
                    myrenderer.flipX = true;
                }
                    }

                } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                        if (map.MapCollision[x + 1, y] != 1) {
                    if (myanim.AnimState == 0) {
                        myanim.StartRunning();
                        x += 1;
                        movevector.x += 1;
                        moving = true;
                    myrenderer.flipX = false;
                    }
                }
            } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                            if (map.MapCollision[x, y + 1] != 1) {
                        if (myanim.AnimState == 0) {
                            myanim.StartRunning();
                        y += 1;
                        movevector.y += 1;
                        moving = true;
                        }
                    }
                } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                                if (map.MapCollision[x, y - 1] != 1) {
                            if (myanim.AnimState == 0) {
                                myanim.StartRunning();
                        y -= 1;
                        movevector.y -= 1;
                        moving = true;
                            }
                    }
                }
            
        }

        if(moving == true) {

            transform.position = Vector3.MoveTowards(transform.position, movevector, 0.5f * Time.deltaTime * speed);
            if(Vector3.Distance(transform.position, movevector) < 0.01f) {
                transform.position = movevector;
                moving = false;
                myanim.StartIdle();
            }
        }

    }
}
