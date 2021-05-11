using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring4 : MonoBehaviour
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
            if (collision.gameObject.name == "ZengaCube_L3")
            {
                Debug.Log("ZENGA 3 COLIDED");
                // ScoreB.scoreVal += 0;

            }
            if (collision.gameObject.name != "ZengaCube_L3" && collision.gameObject.name != "ZengaCube_L4" && collision.gameObject.name != "ZengaCube_L5")
            {
                Debug.Log(" 1A ");
                ScoreB.scoreVal++;

            }


        }
    }
}
