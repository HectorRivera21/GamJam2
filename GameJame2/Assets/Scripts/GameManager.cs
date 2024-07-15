using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI high_score;
    [SerializeField] private TextMeshProUGUI player_score;

    public int highscore;
    public int playerscore;
    private const string ScoreKey = "HighScore";

    void Awake()
    {
        // Ensure there is only one instance of the GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        LoadScore();
        changeScore();
    }

    public void AddScore(int score)
    {
        playerscore += score;
        changeScore();
        SaveScore();
    }

    void changeScore()
    {
        player_score.text = "Score: " + playerscore;
        if (playerscore > highscore)
        {
            high_score.text = "HighScore: " + playerscore;
        }
    }

    void SaveScore()
    {
        if (playerscore > PlayerPrefs.GetInt(ScoreKey, 0))
        {
            PlayerPrefs.SetInt(ScoreKey, playerscore);
        }

    }

    void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            highscore = PlayerPrefs.GetInt(ScoreKey);
            high_score.text = "HighScore: " + highscore;
        }
    }
}