using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public Text flashingText;

    public int coins;

    public bool inGame;

    public AudioClip startSound;
    public Animator startAnimator;
    private AudioSource audio;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("3") || Input.GetKeyDown("4"))
        {
            flashingText.text = "PRESS START";
            coins++;
            audio.time = 0;
            audio.Play();
        }

        if (!inGame)
        {
            
            if ((Input.GetKeyDown("1") || Input.GetKeyDown("2")) && coins > 0)
            {
                inGame = true;
                flashingText.text = "LETS GO!";
                startAnimator.SetTrigger("start");
                audio.PlayOneShot(startSound);
            }
        } else
        {
            if ((Input.GetKeyDown("1") && coins > 0))
            {
                coins--;
                GameObject.Find("Player 1").GetComponent<PlayerController>().AddLives(2);
            }
            if ((Input.GetKeyDown("2") && coins > 0))
            {
                coins--;
                GameObject.Find("Player 2").GetComponent<PlayerController>().AddLives(2);
            }
        }
    }
}
