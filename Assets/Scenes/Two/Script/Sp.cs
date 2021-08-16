using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp : MonoBehaviour {

    string txt = "RequestCode-2,1234,10,3|11,234,0,0|1,123,8,6/3";

    // Use this for initialization
    void Start () {
        string[] one = txt.Split('-');
        foreach (var o in one)
        {
            Debug.Log("one :" +o);
        }

        string[] two = one[1].Split('/');
        foreach (var t in two)
        {
            Debug.Log("two :" +t);
        }

        string[] san = two[0].Split('|');
        foreach (var s in san)
        {
            Debug.Log("san :" + s);
        }
        Debug.Log("=====================");
        foreach (var f in san)
        {
            string[] s = f.Split(',');
            foreach (var i in s)
            {
                Debug.Log(i);
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
