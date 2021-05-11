using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zenga")
        {
            if (collision.gameObject.name != "ZengaCube_L6" && collision.gameObject.name != "ZengaCube_L7")
            {
                ScoreB.scoreVal++;
                Debug.Log("SCORE 1 ADDED");

                
            }

            if (collision.gameObject.name == "ZengaCube_L6")
            {
                Debug.Log("ZENGA 6 COLIDED");
                ScoreB.scoreVal += 0;

            }
            



        }
    }
}
