using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueOrFalse : MonoBehaviour
{
    public GameObject go;

    public GameObject showUI;

    private void Start()
    {
        showUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag!=go.tag)
        {
            showUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        showUI.SetActive(false);
        //if (other.gameObject.tag ==null || other.gameObject.tag.Length == 0)
        //{
           
        //}
    }

}
 