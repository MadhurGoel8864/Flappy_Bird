using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public GameObject PlayButton;
    public GameObject GameOver;
    public PlayerScript player;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public  void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void Play()
    {
        score = 0;
        PlayButton.SetActive(false);
        GameOver.SetActive(false);
        Time.timeScale += 1f;
        player.enabled = true;
        //PipesMOvement[] pipes = FindObjectOfType<PipesMOvement>();
        PipesMOvement[] pipes = FindObjectsOfType<PipesMOvement>();
        for(int i = 0;i< pipes.Length;i++)
        {
            Destroy(pipes[i].gameObject);
        }        

    }


    


    public void gameEnd()
    {
        GameOver.SetActive(true);
        PlayButton.SetActive(true);
        print("Game Over");
        Pause();
    }
    public void IncreaseScore()
    { 
        score++;

        print("Score:" + score);
    }
}
