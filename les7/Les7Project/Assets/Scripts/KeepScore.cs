using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    private TMP_Text ScoreField;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        ScoreField = GetComponent<TMP_Text>();
        score = 0;
        ScoreField.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int add)
    {
        score += add;
        ScoreField.text = "" + score;
    }
}
