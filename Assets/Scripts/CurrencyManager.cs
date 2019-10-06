using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

    public int Leavs = 2;
    public int Wood = 2;

   public Text leav;
   public Text woo;

    public void addLeaves(int leaves) {
        Leavs += leaves;
        leav.text = "" + Leavs;
    }

    public void addWood(int wood) {
        Wood += wood;
        woo.text = "" + Wood;
    }

    private void Start() {
        leav.text = "" + Leavs;
        woo.text = "" + Wood;

    }


}
