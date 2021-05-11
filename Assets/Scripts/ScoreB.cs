using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreB : MonoBehaviour
{
    public static int scoreVal = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
     
    }

    // Update is called once per frame
    void Update()
    {  
        score.text = scoreVal.ToString();
    }
}
/*
    private void OnGUI()
    {

        GUI.Box(new Rect(100, 100, 100, 100), Score.ToString());
    } */
