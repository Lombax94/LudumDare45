using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DebreeType { Wood, Leavs };

public class debree : MonoBehaviour {

    public GameObject prefab;

    debreeMover objects;
    public Sprite[] sprites;

    public float rngtime = 4f;
    float timers = 0;

    // Update is called once per frame
    void Update() {

        timers += Time.deltaTime;

        if (timers > rngtime) {
            timers = 0;
            if (Random.Range(0, 2) == 0) {
                objects = Instantiate(prefab, new Vector3(25, Random.Range(0.5f, 4.5f), 0), Quaternion.identity).GetComponent<debreeMover>();
                objects.myType = DebreeType.Wood;
                objects.travelGoal = new Vector3(-1, objects.transform.position.y, 0);
                objects.mySprite.sprite = sprites[0];
            } else {

                objects = Instantiate(prefab, new Vector3(Random.Range(0.5f, 4.5f), 25, 0), Quaternion.identity).GetComponent<debreeMover>();
                objects.myType = DebreeType.Leavs;
                objects.travelGoal = new Vector3(objects.transform.position.x, -1, 0);
                objects.mySprite.sprite = sprites[1];

            }
        }





    }
}
