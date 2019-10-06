using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour {

    public Transform TheHook;
    public TheHook hook;
    public CurrencyManager currency;
    public TheAnimator myanim;
    public SpriteRenderer myrenderer;
    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;
    LineRenderer lineRenderers;

    void Start() {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = lengthOfLineRenderer;

      
        lineRenderers  = GetComponent<LineRenderer>();

        endPos = transform.position + startPos;
        lineRenderers.SetPosition(0, transform.position + startPos);
        lineRenderers.SetPosition(1,  endPos);

    }


    public bool throwing = false;


    public bool StartFish = true;

    public Vector3 startPos;
    public Vector3 endPos;

    float timeStart = 0;
    public float speed = 5;

    float startY = 0;
    float offest = 0;

    void Update() {

        if (StartFish == false) {


                if (Input.GetMouseButtonDown(0)) {
          

                    endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if(endPos.x < transform.position.x) {

                        myrenderer.flipX = true;
                    } else {
                        myrenderer.flipX = false;

                    }



                    if ((endPos.y < 4.5f || endPos.x < 4.5f) && (transform.position.x <= 5.5 || transform.position.y <= 5.5)) {

                    if (myanim.AnimState == 0) {
                        myanim.StartFish();

                        TheHook.transform.position = lineRenderers.GetPosition(1);
                        offest = Vector3.Distance(transform.position + startPos, endPos);
                        lineRenderers.enabled = true;

                        endPos.y += offest;
                        startY = endPos.y;
                        timeStart = 0;
                        StartFish = true;
                        throwing = true;
                        TheHook.gameObject.SetActive(true);
                    }
                }
            }
        } else {



            if (throwing == true) {



                timeStart += Time.deltaTime * speed;

                if (timeStart < offest) {
                    endPos.y = startY - timeStart;
                }



                for (int i = 0; i < 1; i++) {
                    lineRenderers.SetPosition(0, transform.position + startPos);
                    lineRenderers.SetPosition(1, Vector3.MoveTowards(lineRenderers.GetPosition(1), endPos, 0.5f * Time.deltaTime * speed));
                    TheHook.transform.position = lineRenderers.GetPosition(1);


                    //   lineRenderers.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
                }

                if (Vector3.Distance(lineRenderers.GetPosition(1), endPos) < 0.01f && timeStart >= offest) {
                    endPos = startPos + transform.position;
                    throwing = false;
                    hook.enableHit = true;
                }

            } else {

                lineRenderers.SetPosition(0, transform.position + startPos);
                lineRenderers.SetPosition(1, Vector3.MoveTowards(lineRenderers.GetPosition(1), endPos, 0.5f * Time.deltaTime * speed / 4));
                TheHook.transform.position = lineRenderers.GetPosition(1);

                if (Vector3.Distance(lineRenderers.GetPosition(1), endPos) < 0.01f) {
                    StartFish = false;
                    TheHook.gameObject.SetActive(false);

                    for(int i = 0; i < hook.debree.Count; i++) {
                        if(hook.debree[i].myType == DebreeType.Wood) {
                            currency.addWood(1);
                        } else {
                            currency.addLeaves(1);
                        }

                    }
                    for (int i = 0; i < hook.debree.Count; i++) {
                        Destroy(hook.debree[i].gameObject);

                    }
                    hook.debree.Clear();

                    hook.enableHit = false;
                    lineRenderers.enabled = false;
                    myanim.StartIdle();

                }

            }

        }
    }
}
