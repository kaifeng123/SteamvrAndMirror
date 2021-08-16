using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMove : MonoBehaviour
{
    private Rigidbody gaRigibody;
    private void Awake()
    {
        gaRigibody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gaRigibody.velocity = transform.right * 10;
        TimerManager.instance.DoOnce(10000, () => { Destroy(gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Rigidbody>().AddForce(Vector3.right * 50, ForceMode.Force);
    }
    Transform tran;
    private void OnCollisionEnter(Collision collision)
    {
        tran = collision.transform;
        if (collision.transform.CompareTag("qiang"))
        {
            gaRigibody.velocity = Vector3.zero;
            transform.rotation = tran.rotation;
            gaRigibody.velocity = -transform.right * 10;
        }
    }
}
