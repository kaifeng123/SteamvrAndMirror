using UnityEngine;
using System.Collections;

public class Leftctrl : MonoBehaviour
{
    public GameObject player;

    public void Teleport()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 20))
        {
            if (hit.transform.tag == "Others" || hit.transform.tag == "UI" || hit.transform.tag == "Skeletal")
            {
                Debug.Log("Hitting tag ==" + hit.collider.tag);
                return;
            }
            else
                player.transform.position = hit.point;
        }
    }
}
