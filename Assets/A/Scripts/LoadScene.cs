//**********************************************************
//文件名(File Name) :         LoadScene.cs
//
//作者(Author):               
//
//创建时间(CreatTime):        2016-12-09 14:17:22
//
//功能(Funtion)：  
//**********************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour 
{
    public void Load(int i)
    {
        switch (i)
        {
            case 1:
                LoadInScene(Tools.Menu);
                break;
            case 2:
                LoadInScene(Tools.XiaoHua_Lab);
                break;
            case 3:
                LoadInScene(Tools.Muscular_Lab);
                break;
            case 4:
                LoadInScene(Tools.Skeletal_Lab);
                break;
            case 5:
                LoadInScene(Tools.Nervous_Lab);
                break;
        }
    }

    /// <summary>
    /// 通过封装好的api加载
    /// </summary>
    /// <param name="name"></param>
    private void LoadInScene(string name)
    {
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

}