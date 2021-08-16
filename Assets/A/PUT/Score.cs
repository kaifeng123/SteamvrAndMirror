using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField]
    private int cc;

    private bool isOO;

    BoxCollider box;

    void Start()
    {
        box = this.GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider col)
    {
        if (!isOO)
        {
            if (col.transform.position != this.transform.position)
                return;
            else
            {
                isOO = true;
                col.transform.position = this.transform.position;
                Comon.AddNum(cc);
                box.enabled = false;
                Debug.Log("num:" + Comon.Count);
                Debug.Log(isOO);
            }
        }
    }

    //void OnTriggerExit(Collider col)
    //{
    //    if (isOO)
    //    {
    //        if (col.transform.position == this.transform.position)
    //            return;
    //        else
    //        {
    //            isOO = false;
    //            //col.transform.position = this.transform.position;
    //            Comon.RemoveNum(cc);
    //            box.enabled = false;
    //            Debug.Log("num:" + Comon.Count);
    //            Debug.Log(isOO);
    //        }
    //    }
    //}
}
