using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreB.scoreVal = 0;  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zenga")
        {
            if (collision.gameObject.name == "ZengaCube_L5")
            {
                Debug.Log("ZENGA 5 COLIDED");
               // ScoreB.scoreVal += 0;

            } 
            if (collision.gameObject.name != "ZengaCube_L5" && collision.gameObject.name != "ZengaCube_L6" && collision.gameObject.name != "ZengaCube_L7")
            {
                Debug.Log(" 1A ");
                ScoreB.scoreVal++;

            }
           

        }
    }
}
