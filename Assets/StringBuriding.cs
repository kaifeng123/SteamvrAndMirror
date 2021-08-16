using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class StringBuriding : MonoBehaviour
{
    private StringBuilder str = new StringBuilder();
    public Text text;
    private string classname;
    // Start is called before the first frame update
    void Start()
    {
        text.text = str.AppendFormat("小灰灰:{0},{1}", "憨批", "瓜皮").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
