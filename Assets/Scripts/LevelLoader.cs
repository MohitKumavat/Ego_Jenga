using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator trans;
    
    // Update is called once per frame
    void Update()
    {
       //if (OVRInput.GetDown(OVRInput.Button.Two))

        if(ScoreB.scoreVal >= 5)
        {
           // ScoreB.scoreVal++;
            Floor.count = 0;
            StartCoroutine(LoadLevel(1));
        }   
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        ScoreB.scoreVal = 0;
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
