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
    public string[] p1Modifiers;
    public Image[] p1ModifierSlots;
    private int p1OccupiedSlots = 0;

    [Header("Player 2")]
    public Text p2Score;
    public Text p2Lives;
    public string[] p2Modifiers;
    public Image[] p2ModifierSlots;
    private int p2OccupiedSlots = 0;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
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
        }
    }

    public void AddModifier(int player, string mod)
    {
        if (player == 1)
        {
            
        } else if (player == 2)
        {
            
        }
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
