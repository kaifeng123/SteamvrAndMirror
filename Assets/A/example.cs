using UnityEngine;
using System.Collections;

public class example : MonoBehaviour
{
    private Color gocolor;
    private Texture goTextture;

    private GameObject objgo;


    void Start()
    {
        Example();

    }

    void Example()
    {


       
        foreach (Transform child in transform)
        {
            print(child.name);
            
            
        }

    }
}