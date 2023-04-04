using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int lives;
    private int maxLives;
    Image[] images;
    Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        int count = 0;
        foreach(Image image in images)
        {
            if (image.name == "Heart") 
            {
                count++;
            }

        }

        hearts = new Image[count];
        count = 0;
        foreach (Image image in images)
        {
            if (image.name == "heart")
            {
                hearts[count] = image;
                count++;
            }
        }
        lives = hearts.Length;
        maxLives = hearts.Length;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= maxLives && value >= 0)
            {
                lives = value;
                for (int i = 0; i < hearts.Length; i++)
                {
                    if (i < lives)
                    {
                        hearts[i].enabled = true;
                    }
                    else
                    {
                        hearts[i].enabled = false;
                    }
                }
                if(lives == 0)
                {
                    pauseGame();
                }
            }
        }
    }
    private void pauseGame()
    {
        Time.timeScale = 0;
    }
}
