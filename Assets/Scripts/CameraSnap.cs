using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnap : MonoBehaviour {

    public Transform player;
  public  Vector3 movetopos = Vector3.zero;

 public   float LeftX = 0;
    public float RightX = 0;
    public float UpY = 0;
    public float DownY = 0;

    // Start is called before the first frame update
    void Start()
    {
        movetopos.x = LeftX;
        movetopos.y = DownY;
        movetopos.z = -10f;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.position.x < movetopos.x) {
            if(player.position.x < LeftX)
              movetopos.x = LeftX;
            else
                movetopos.x = player.position.x;

        }else
        if (player.position.x > movetopos.x) {
            if (player.position.x > RightX)
                movetopos.x = RightX;
            else
                movetopos.x = player.position.x;

        }

        if (player.position.y < movetopos.y) {
            if (player.position.y < DownY)
                movetopos.y = DownY;
            else
                movetopos.y = player.position.y;

        } else
       if (player.position.y > movetopos.y) {
            if (player.position.y > UpY)
                movetopos.y = UpY;
            else
                movetopos.y = player.position.y;

        }


        



        transform.position = Vector3.MoveTowards(transform.position, movetopos, 0.5f * Time.deltaTime * 4);

    }
}
