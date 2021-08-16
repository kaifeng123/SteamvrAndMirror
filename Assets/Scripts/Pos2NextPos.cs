using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos2NextPos : MonoBehaviour {

    public Transform[] trans;
    public GameObject target;

    public void NextPoint(int i)
    {
        switch (i)
        {
            case 1:
                SetTrans(trans[0]);
                break;
            case 2:
                SetTrans(trans[1]);
                break;
            case 3:
                SetTrans(trans[2]);
                break;
            case 4:
                SetTrans(trans[3]);
                break;
            case 5:
                SetTrans(trans[4]);
                break;
            case 6:
                SetTrans(trans[5]);
                break;
            case 7:
                SetTrans(trans[6]);
                break;
            case 8:
                SetTrans(trans[7]);
                break;
            case 9:
                SetTrans(trans[8]);
                break;
            case 10:
                SetTrans(trans[9]);
                break;
            case 11:
                SetTrans(trans[10]);
                break;
            case 12:
                SetTrans(trans[11]);
                break;
            case 13:
                SetTrans(trans[12]);
                break;
            case 14:
                SetTrans(trans[13]);
                break;
            case 15:
                SetTrans(trans[14]);
                break;
            case 16:
                SetTrans(trans[15]);
                break;
            case 17:
                SetTrans(trans[16]);
                break;
            case 18:
                SetTrans(trans[19]);
                break;
            case 19:
                SetTrans(trans[20]);
                break;
            case 20:
                SetTrans(trans[21]);
                break;
            case 21:
                SetTrans(trans[22]);
                break;

            default:
                break;
        }
    }

    private void SetTrans(Transform trans)
    {
        target.transform.position = trans.transform.position;
    }
}
