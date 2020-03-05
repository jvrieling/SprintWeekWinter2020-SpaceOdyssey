using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Sprite[] icons;

    [Header("Player 1")]
    public Text p1Score;
    public Text p1Lives;
    public bool[] p1ModifierDisplayed; 
    public string[] p1Modifiers;
    private int p1ModifierCount = 0;
    public Image[] p1ModifierSlots;
    private int p1OccupiedSlots = 0;

    [Header("Player 2")]
    public Text p2Score;
    public Text p2Lives;
    public string[] p2Modifiers;
    public bool[] p2ModifierDisplayed;
    public Image[] p2ModifierSlots;
    private int p2OccupiedSlots = 0;


    private void Awake()
    {
        instance = this;
        p1Modifiers = new string[8];
        p2Modifiers = new string[8];
        p1ModifierDisplayed = new bool[8];
        p2ModifierDisplayed = new bool[8];
    }

    private void Update()
    {
        /*
        p1OccupiedSlots = 0;
        foreach(string i in p1Modifiers)
        {
            foreach (Sprite j in icons)
            {
                if( j.name == i)
                {
                    p1ModifierSlots[p1OccupiedSlots].sprite = j;
                    p1ModifierSlots[p1OccupiedSlots].color = new Color(1, 1, 1, 1);
                    p1OccupiedSlots++;
                    Debug.Log("Occupued slots " + p1OccupiedSlots);
                }
            }
        }*/

        for(int i = 0; i < p1ModifierSlots.Length; i++)
        {
            if (p1ModifierDisplayed[i])
            {
                p1ModifierSlots[i].color = new Color(1, 1, 1, 1);
            } else
            {
                p1ModifierSlots[i].color = new Color(1, 1, 1, 0);
            }
        }
        for (int i = 0; i < p2ModifierSlots.Length; i++)
        {
            if (p2ModifierDisplayed[i])
            {
                p2ModifierSlots[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                p2ModifierSlots[i].color = new Color(1, 1, 1, 0);
            }
        }

    }

    public void AddModifier(int player, string mod)
    {
        if (player == 1)
        {
            switch (mod)
            {
                case "multiShot":
                    p1ModifierDisplayed[0] = true;
                    break;
                case "splitShot":
                    p1ModifierDisplayed[7] = true;
                    break;
                case "decreaseMoveSpeed":
                    p1ModifierDisplayed[6] = true;
                    break;
                case "increaseMoveSpeed":
                    p1ModifierDisplayed[1] = true;
                    break;
                case "fasterEnemies":
                    p1ModifierDisplayed[2] = true;
                    break;
                case "spartanLaser":
                    p1ModifierDisplayed[3] = true;
                    break;
            }
        }
        if (player == 2)
        {
            switch (mod)
            {
                case "multiShot":
                    p2ModifierDisplayed[0] = true;
                    break;
                case "splitShot":
                    p2ModifierDisplayed[7] = true;
                    break;
                case "decreaseMoveSpeed":
                    p2ModifierDisplayed[6] = true;
                    break;
                case "increaseMoveSpeed":
                    p2ModifierDisplayed[1] = true;
                    break;
                case "fasterEnemies":
                    p2ModifierDisplayed[2] = true;
                    break;
                case "spartanLaser":
                    p2ModifierDisplayed[3] = true;
                    break;
            }
        }

        /*Debug.Log(p1Modifiers.Length);
        if (player == 1)
        {
           p1Modifiers[p1ModifierCount] = mod;
           p1ModifierCount++;
        } else if (player == 2)
        {
           p2Modifiers[p2Modifiers.Length] = mod;
        }*/
    }

    public void SetLives(int player, int amt)
    {
        if (player == 1)
        {
            p1Lives.text = amt.ToString();
        }
        else if (player == 2)
        {
            p2Lives.text = amt.ToString();
        }
    }

    public void SetScore(int player, int amt)
    {
        if (player == 1)
        {
            p1Score.text = amt.ToString("000000000");
        }
        else if (player == 2)
        {
            p2Score.text = amt.ToString("000000000");
        }
    }
}
