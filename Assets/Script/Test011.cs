using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test011 : MonoBehaviour {

    public GameObject go;
    public int cnt;

    int i = 0;
    // Use this for initialization
    void Awake()
    {
        i = PlayerPrefs.GetInt("miwen");

        //if (i > cnt)
        //{
        //    Application.Quit();
        //}

        i++;
        PlayerPrefs.SetInt("miwen", i);

    }
    private void Start()
    {
        SceneManager.LoadScene(1);//跳转到场景1
    }


    //// Update is called once per frame
    void Update()
    {
        if (i > cnt)
        {
            go.SetActive(false);
        }
    }

    public void Close()
    {
        Application.Quit();
    }
}
