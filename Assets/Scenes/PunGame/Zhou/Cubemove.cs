using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubemove : MonoBehaviour
{
    public float moveSpeed = 10;
    private bool isCubeMove = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (!GetComponent<PhotonView>().IsMine)
        //    return;
        //float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        //float vertical = Input.GetAxis("Vertical"); //W S 上 下

        //transform.Translate(-Vector3.forward * vertical * moveSpeed * Time.deltaTime);//W S 上 下
        //transform.Translate(-Vector3.right * horizontal * moveSpeed * Time.deltaTime);//A

    }
    private void FixedUpdate()
    {
        if (!GetComponent<PhotonView>().IsMine)
            return;
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下

        transform.Translate(-Vector3.forward * vertical * moveSpeed * Time.deltaTime);//W S 上 下
        transform.Translate(-Vector3.right * horizontal * moveSpeed * Time.deltaTime);//A

        if (isCubeMove && item != null)
        {

            item.transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            //  item.SetCubePositionRPC();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isCubeMove = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (itemTest != null)
            {
                itemTest.isWrite = false;
                itemTest.SetCubeTranSformViewIsMoveRPC(false);
                isCubeMove = false;
                itemTest = null;
                item = null;
            }
        }
    }
    CubeTransformViewTest itemTest = null;
    //CubeMoveTest item = null;
    GameObject item = null;
    // CubeTransformViewTest test;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Move"))
        {
            if (isCubeMove && itemTest == null)
            {
                
                // item = other.GetComponent<CubeMoveTest>();
                // item.SetCubePositionRPC();
                itemTest = other.GetComponent<CubeTransformViewTest>();
                if (!itemTest.isNoMove)
                {
                    itemTest.isWrite = true;
                    itemTest.SetCubeTranSformViewIsMoveRPC(true);
                    item = other.gameObject;
                }
                else
                    itemTest = null;
                Debug.Log("进入触发检测");
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Move"))
        {
            if (!isCubeMove && itemTest!=null)
            {
                itemTest.isWrite = false;
                itemTest.SetCubeTranSformViewIsMoveRPC(false);
                //item.OpenCubePositionRPC();
                itemTest = null;
            }
            // other.GetComponent<CubeTransformViewTest>().isWrite = false;
            Debug.Log("退出触发检测");
        }
    }
}
