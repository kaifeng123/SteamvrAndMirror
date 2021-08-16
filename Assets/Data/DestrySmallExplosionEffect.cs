using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrySmallExplosionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimerManager.instance.DoOnce(1500,()=> { Destroy(gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
