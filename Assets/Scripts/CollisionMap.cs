using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMap : MonoBehaviour {

    public int[,] MapCollision = new int[25, 25];



    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < 25; i++) {
            for (int j = 0; j < 25; j++) {
                MapCollision[i, j] = 1;
            }
        }
    }



    public void SetWalking(int x, int y, int z) {
        MapCollision[x, y] = z;
    }


}
