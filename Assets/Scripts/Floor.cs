using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    public static int count = 0;
    bool gameHasEnded = false;
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
        if (collision.gameObject.CompareTag("Zenga"))
        {
            gameHasEnded = true;
            EndGame();
            
            Restart();
            
            
        }
    }

    
    public void EndGame()
    {
        if (gameHasEnded == true)
        {
            gameHasEnded = false;
            Debug.Log("Game Over");


        }
    }

    void Restart()
    {
        new WaitForSeconds(1);
        ScoreB.scoreVal = 0;
        count = 0;
        SceneManager.LoadScene(0);
    }

}
