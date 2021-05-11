using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring3 : MonoBehaviour
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
            if (collision.gameObject.name == "ZengaCube_L2")
            {
                Debug.Log("ZENGA 2 COLIDED");
                // ScoreB.scoreVal += 0;

            }
            if (collision.gameObject.name != "ZengaCube_L2" && collision.gameObject.name != "ZengaCube_L3" && collision.gameObject.name != "ZengaCube_L4")

            {
                Debug.Log(" 1A ");
                ScoreB.scoreVal++;

            }


        }
    }

    /*   if (collision.gameObject.tag == "Zenga")
       {
       if (collision.gameObject.name != "ZengaCube_L2")
       {
           ScoreB.scoreVal += 2;
       }


} */

}
