using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPoint : MonoBehaviour
{
    public GameObject[] pnt;
    public GameObject UI;
    public GameObject player;

    // Use this for initialization
    void Start () {
        UI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(false);          
        }
    }

    public void NextToPnt(int i)
    {
        switch (i)
        {
            case 1:
                player.transform.position = pnt[0].transform.position;
                break;
            case 2:
                player.transform.position = pnt[1].transform.position;
                break;
            case 3:
                player.transform.position = pnt[2].transform.position;
                break;
            case 4:
                player.transform.position = pnt[3].transform.position;
                break;
            case 5:
                player.transform.position = pnt[4].transform.position;
                break;
            case 6:
                player.transform.position = pnt[5].transform.position;
                break;
            case 7:
                player.transform.position = pnt[6].transform.position;
                break;
            case 8:
                player.transform.position = pnt[7].transform.position;
                break;
            case 9:
                player.transform.position = pnt[8].transform.position;
                break;
            case 10:
                player.transform.position = pnt[9].transform.position;
                break;
            default:
                player.transform.position = this.transform.position;
                break;
                    
        }
    }
}
