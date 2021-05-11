using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zenga")
        {
        
            if (collision.gameObject.name != "ZengaCube_L1" && collision.gameObject.name != "ZengaCube_L2")
            {
                Debug.Log(" 1A ");
                ScoreB.scoreVal++;

            }


        }
    }
}
