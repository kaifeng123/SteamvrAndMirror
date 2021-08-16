using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public GameObject UI;
    public AudioSource clip;
    public Text txt;
    public string content;
    void Start()
    {
        UI.SetActive(false);
        showTxt(content);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showTxt(string conntent)
    {
        txt.text = "\u3000\u3000" + conntent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayVoice();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            UI.SetActive(true);
           // Debug.Log(6666);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(false);
            clip.Stop();
            //Debug.Log(7777);
        }
    }

    public void PlayVoice()
    {
        clip.Play();
    }

}
