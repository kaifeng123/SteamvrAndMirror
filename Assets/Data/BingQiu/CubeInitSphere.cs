using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInitSphere : MonoBehaviour
{
    public GameObject sphereGa;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        TimerManager.instance.DoLoop(5000, initSphereGa);
    }
    public void initSphereGa()
    {
        GameObject sphereItemGa = GameObject.Instantiate(sphereGa,transform,false);
       // sphereGa.GetComponent<Rigidbody>().AddForce(-sphereGa.transform.forward * 200);
       // sphereGa.GetComponent<Rigidbody>().velocity = -sphereGa.transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
