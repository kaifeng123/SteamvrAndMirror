using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    private InputField input;

    [SerializeField]
    public Text txt1, txt2, txt3, txt4;


    public void ClickKey(string character)
    {
        input.text += character;
    }

    public void Backspace()
    {
        if (input.text.Length > 0)
        {
            input.text = input.text.Substring(0, input.text.Length - 1);
        }
    }

    public void EnterTO()
    {
        switch (Comon.Num)
        {
            case 1:
                txt1.text = input.text;
                Debug.Log(" txt1.text :" + txt1.text);
                break;

            case 2:
                txt2.text = input.text;
                Debug.Log(" txt2.text :" + txt2.text);
                break;

            case 3:
                txt3.text = input.text;
                Debug.Log(" txt3.text :" + txt3.text);
                break;

            case 4:
                txt4.text = input.text;
                Debug.Log(" txt4.text :" + txt4.text);
                break;
        }
        Debug.Log(Comon.Num);
        ClearTxt();
    }

    public void ClearTxt()
    {
        input.text = string.Empty;
    }

    private void Start()
    {
        input = GetComponentInChildren<InputField>();
    }
}

