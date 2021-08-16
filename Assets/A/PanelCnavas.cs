using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class PanelCnavas : MonoBehaviour
{
    /// <summary>
    /// ��¼���
    /// </summary>
    [SerializeField]
    public GameObject LogOnPanel;

    /// <summary>
    /// ע�����
    /// </summary>
    [SerializeField]
    public GameObject RegPanel;

    public Text _Txt;
    /// <summary>
    /// ȫ����
    /// </summary>
    [SerializeField]
    public GameObject KeyboardPanel;

    Keyboard keyTxt;

    private bool isOn = false;

    public GameObject textPanel;

    #region  ��¼���
    /// <summary>
    /// ȥע��
    /// </summary>
    public void ToReg()
    {
        RegPanel.SetActive(true);
        LogOnPanel.SetActive(false);
    }

    /// <summary>
    /// ��¼--TODO
    /// </summary>
    public void LogOn()
    {
        textPanel.SetActive(true);
        LogOnPanel.SetActive(false);
    }

    public void LogOnInput()
    {

    }

    public void RegInput()
    {

    }

    #endregion

    #region ע�����
    
    /// <summary>
    /// ע���˺�
    /// </summary>
    public void Reg()
    {

    }

    /// <summary>
    /// ���ص�¼
    /// </summary>
    public void ToLogOn()
    {
        LogOnPanel.SetActive(true);
        RegPanel.SetActive(false);
    }
    #endregion

    #region
    public void LogOnText(int i)
    {
        Debug.Log(2333);
        Comon.Num = i;
    }

    public void RegText(int i)
    {
        Debug.Log(3333);
        Comon.Num = i;
    }

    public void RegLogOnText(int i)
    {
        Debug.Log(4444);
        Comon.Num = i;
    }

    public void RegOnText(int i)
    {
        Debug.Log(5555);
        Comon.Num = i;
    }

    #endregion


    public void ShowKeyboard()
    {
        if (isOn==false)
        {
            KeyboardPanel.SetActive(true);
            isOn = true;
        }          
        else
        {
            KeyboardPanel.SetActive(false);
            isOn = false;
        }    
    }

         
    #region 
    void Start()
    {
        RegPanel.SetActive(false);
        KeyboardPanel.SetActive(false);
    }
    #endregion
}
