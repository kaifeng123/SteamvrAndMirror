using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5);
    }
}
