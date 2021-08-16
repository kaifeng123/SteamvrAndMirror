using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1 : MonoBehaviour
{
    public GameObject player;

    private GameObject go;

    private void Start()
    {
        //GetGo();   
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            LoadToVR();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadToKey();
        }
    }

    public void LoadToVR()
    {
        SceneManager.LoadScene("new_BKDGL");
    }

    public void LoadToKey()
    {
        SceneManager.LoadScene("new_BKDGL_key");
    }
	
    public void MainScene()
    {
        SceneManager.LoadScene("main");
    }

    private void GetGo()
    {
        go = Instantiate(player) as GameObject;
        go.transform.position = new Vector3(518f, 0f, 107f);
        go.transform.localScale = Vector3.one;
    }
}
