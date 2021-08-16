using UnityEngine;
using System.Collections;

public class ShowTool : MonoBehaviour
{
    //public GameObject lit;
    public GameObject go;

    private bool isShow = false;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
       // lit.SetActive(false);
        go.SetActive(false);
    }

    void Update()
    {
        //防止Start函数没加载成功，保证SteamVR_ TrackedObject组件获取成功
        if (trackedObj.isValid)
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
        }
        //根据index，获取手柄
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //当按下菜单按键，弹出列表菜单
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            //Debug.Log("光线操作");
            Show();
        }
    }

    /// <summary>
    /// 显示操作
    /// </summary>
    private void Show()
    {
        if (!isShow)
        {
            //lit.SetActive(true);
            go.SetActive(false);
            isShow = true;
        }
        else
        {
            //lit.SetActive(false);
            go.SetActive(true);
            isShow = false;
        }
    }
}
