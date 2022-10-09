using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public AudioSource screenAudioSource;
    public AudioClip clickSound;

    public void GameStart()
    {
        SceneManager.LoadScene("GAME");

        screenAudioSource.clip = clickSound;
        screenAudioSource.Play();
    }
}
