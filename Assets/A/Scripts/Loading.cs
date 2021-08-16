using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    #region
    [SerializeField]
    private GameObject loadingPanel;
    [SerializeField]
    private Image mImage;
    [SerializeField]
    private Text text;

    #endregion


    private AsyncOperation async;

    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        mImage.fillAmount = 0;
        text.text = (int)(mImage.fillAmount * 100) + "%";

        StartCoroutine(Test());
    }


    void Update()
    {
        if (mImage.fillAmount < 1)
        {
            loadingPanel.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -300));
        }
    }

    IEnumerator Test()
    {
        yield return 1;
        yield return new WaitForSeconds(0.2f);
        mImage.fillAmount += 0.03f;
        SetLabelValue(mImage.fillAmount);

        if (mImage.fillAmount < 1)
        {
            StartCoroutine(Test());
        }
        else
        {
            //Application.LoadLevel("Skeletal_Lab");
            SceneManager.LoadScene("Skeletal_Lab");
        }
    }



    void SetLabelValue(float value)
    {
        if (text != null)
        {
            text.text = (int)(mImage.fillAmount * 100) + "%";
        }
    }

}

