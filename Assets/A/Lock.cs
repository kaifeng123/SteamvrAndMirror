using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Transform target;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        this.transform.forward = new Vector3(transform.position.x - target.position.x, 0, transform.position.z - target.position.z);
    }
}
