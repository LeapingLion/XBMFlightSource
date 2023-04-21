using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour

{

    public GameObject playButton;
    public GameObject gameOver;

    public Player player;

    private int score;


    private void Awake()
    {

        Pause();

    }

    public void Play()
    {

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Ghost[] ghost = FindObjectsOfType<Ghost>();

        for (int i = 0; i < ghost.Length; i++)
        {
            Destroy(ghost[i].gameObject);
        }



    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;


    }




    public void GameOver()
    {

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }


    private void IncreaseScore()
    {
        score++;
    }
}
