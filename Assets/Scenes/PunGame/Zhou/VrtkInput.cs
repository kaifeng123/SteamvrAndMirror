using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using static SteamVR_Controller;

public class VrtkInput : MonoBehaviour
{
    private bool isTriggerGa = false;
    private VrtkTriggerGaMove vrtkGaMove;
    private Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        isTriggerGa = false;
        GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerTouchStart);
        GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggerGa && triggerGameobject != null)
        {
            triggerGameobject.transform.position = transform.position - v3;
        }
        //GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerTouchStart);
    }
    private void DoTriggerTouchStart(object sender, ControllerInteractionEventArgs e)
    {
        if (triggerGameobject != null)
        {
            vrtkGaMove = triggerGameobject.GetComponent<VrtkTriggerGaMove>();
            v3 = transform.position - triggerGameobject.transform.position;
            isTriggerGa = true;
            vrtkGaMove = triggerGameobject.GetComponent<VrtkTriggerGaMove>();
            vrtkGaMove.StartRpc();
        }
        Debug.Log("进入");
    }
    private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {
        triggerGameobject = null;
        isTriggerGa = false;
        if(vrtkGaMove)
        {
            vrtkGaMove.StopRpc();
            vrtkGaMove = null;
        }
        Debug.Log("退出");
    }

    private GameObject triggerGameobject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("moveAndGa"))
        {
            triggerGameobject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("moveAndGa"))
        {
            triggerGameobject = null;
        }
    }
}
