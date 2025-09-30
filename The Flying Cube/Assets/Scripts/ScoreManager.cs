using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }//��������� ����
    [SerializeField]
    private TextMeshProUGUI scoreText; //����� ������� ����� ���������� UI
    private int score;
    private void Start()
    {
        Instance = this;
    }
    public void SetScore (int score) //������������ �����
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }

}
