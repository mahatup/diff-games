using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }//получение себя
    [SerializeField]
    private TextMeshProUGUI scoreText; //класс объекта текст компонента UI
    private int score;
    private void Start()
    {
        Instance = this;
    }
    public void SetScore (int score) //установление очков
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }

}
