using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoretext;
    [SerializeField] TextMeshProUGUI highscoretext_;


    private void Awake()
    {
        _scoretext.text = Player.score.ToString();
        highscoretext_.text = " " + PlayerPrefs.GetInt("Highscore");
        Player.score = 0;
    }
    public void retry()
    {
        Player.score = 0;
        SceneManager.LoadScene(0);
    }

}
