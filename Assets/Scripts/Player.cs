using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float highscore = 0f;
    public float jumpforce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sR;
    public string currentColor;
    public static int score;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI GameOverScoreText;



    void Start()
    {
        RandomColor();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 1) {

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Jump();
            }
        }

        if(Input.GetMouseButton(0))
        {
            Jump();
        }

        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
    void Jump()
    {
        rb.velocity = Vector2.up * jumpforce;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "star")
        {
            score++;
            scoreText.text = "" + score;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "ColorChange")
        {
            RandomColor();
            Destroy(collision.gameObject);
        }

        else if((collision.tag != currentColor || collision.tag == "Base" ) && collision.tag != "star")
        {
            SceneManager.LoadScene(1);
            Debug.Log("GameOver");
        }
        
    }
    void RandomColor()
    {
        int i = Random.Range(0, 4);
        switch(i)
        {
            case 0:
                currentColor = "Turq";
                sR.color = new Color(0.2078432f, 0.8862746f, 0.9490197f);
                break;
            case 1:
                currentColor = "Yellow";
                sR.color = new Color(0.9647059f, 0.8745099f, 0.05490196f);
                break;
            case 2:
                currentColor = "Pink";
                sR.color = new Color(1f,0f, 0.5019608f);
                break;
            case 3:
                currentColor = "Purple";
                sR.color = new Color(0.5490196f, 0.07450981f, 0.9843138f);
                break;
        }
    }
}
