using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class UpLoad : MonoBehaviour
{
    public Text countTxt;
    public Text scoreTxt;

    private int num = 0;

    public float timeCount;

    bool isStop = false;

    public GameObject startBtn;
    public GameObject upBtn;

    public GameObject grab;
    VRTK_InteractGrab _vrtk;
    //[SerializeField]
    //private VRTK_InteractableObject[] objs;

    STInfo info = new STInfo();
    void Start()
    {
        upBtn.SetActive(false);
        _vrtk = grab.GetComponent<VRTK_InteractGrab>();
        _vrtk.enabled = false;
    }

    void Update()
    {
        if (!Comon.IsCount)
        {
            Comon.Count = 0;
        }
            

        if(isStop)
        {
            countTxt.text = "目前得分："+Comon.Count.ToString();
            timeCount -= Time.deltaTime;
            scoreTxt.text = "倒计时" + timeCount.ToString("f1") + "秒";
            num = Comon.Count;
            if (timeCount <= 0)
            {
                scoreTxt.text = "做题结束！！！";
                upBtn.SetActive(true);
                _vrtk.enabled = false;
            }
        }
    }

    /// <summary>
    ///开始计时
    /// </summary>
    public void Count()
    {
        isStop = true;
        startBtn.SetActive(false);
        Comon.IsCount = true;
        _vrtk.enabled = true;
    }

    /// <summary>
    /// 上传成绩
    /// </summary>
    public void UpTo()
    {
        info.score = num;
        Debug.Log(info.score);
    }
}
