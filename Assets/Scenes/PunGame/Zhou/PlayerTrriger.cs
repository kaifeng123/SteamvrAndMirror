using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTrriger : MonoBehaviourPunCallbacks
{
  //  PhotonView view;
    private Slider playerHPSlider;
    private void Awake()
    {
       // view = transform.GetComponent<PhotonView>();
        playerHPSlider = transform.Find("Canvas/Slider").GetComponent<Slider>();
        playerHPSlider.value = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView == null)
            return;
       // if (other.CompareTag("ZhiDan"))
        if (other.CompareTag("ZhiDan")&& !photonView.IsMine)
        {
            //Debug.Log(transform.name); 
            GameObject ga = Resources.Load<GameObject>("SmallExplosionEffect");
            Vector3 v3 = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            Instantiate(ga, v3, new Quaternion(0, 0, 0, 0));
            photonView.RPC("SetPlayerHP", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    private void SetPlayerHP()
    { 
        playerHPSlider.value--;
    }
}
