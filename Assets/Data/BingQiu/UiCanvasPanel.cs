using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiCanvasPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(BtnClick);
    }
    public void BtnClick()
    {
        Debug.Log("开始按钮");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
