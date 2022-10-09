using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    public Text Timer, WALL_COUNTER;
    public float gameMaxTime = 300;
    public static int BodyCount = 0;

    private int playerCount;
    private bool isRunning = true;

    private int minutos = 5, segundos = 0;

    // Update is called once per frame
    void Update()
    {
        playerCount = getPlayerCount();

        if (isRunning)
        {
            if (playerCount == 0)
                SceneManager.LoadScene("YOU_LOSE");

            gameMaxTime -= Time.deltaTime;

            minutos = Mathf.RoundToInt(gameMaxTime) / 60;
            segundos = Mathf.RoundToInt(gameMaxTime) - (minutos*60);

            Timer.text = minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2,'0');

            if (gameMaxTime < 0)
                isRunning = false;

            WALL_COUNTER.text = BodyCount.ToString();
        }
        else
            SceneManager.LoadScene("YOU_WIN");
    }

    public int getPlayerCount()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        return players.Length;
    }
}
