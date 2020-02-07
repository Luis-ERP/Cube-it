using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject _player;
    public GameObject _base;

    public GameObject _enemyFactory;

    public GameObject _joystick;

    public GameObject timerLabel;
    public GameObject scoreLabel;

    public GameObject blurCanvas;
    // pause canvas
    public GameObject pauseScoreLabel;
    public GameObject _label1;
    // game over canvas
    public GameObject gameOverScoreLabel;
    public GameObject gameOverHighscoreLabel;

    public GameObject achievements;

    public int score = 0;
    public int highScore;
    private float timer = 3;
    public bool gameOver = false;
    public bool paused = false;
    private int nuEnemies = 0;
    private bool gameSaved = false;
    private bool dataLoaded = false;


    // Start is called before the first frame update
    void Start()
    {
        _base.GetComponent<BaseSpawn>().SpawnBase();
        _enemyFactory.GetComponent<EnemyCreator>().CreateEnemy();
        _enemyFactory.GetComponent<EnemyCreator>().SpawnAllEnemies();
        nuEnemies += 1;
        _base.SetActive(true);
        _enemyFactory.GetComponent<EnemyCreator>().ActivateAllEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timerLabel.GetComponent<Text>().text = ((int)timer).ToString();
        }
        else
        {
            timerLabel.SetActive(false);
            _label1.SetActive(false);
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            _player.GetComponent<PlayerMovement>().enabled = true;
            _enemyFactory.GetComponent<EnemyCreator>().EnableMovementAllEnemies(true);
            Play();
        }
    }

    void Play()
    {
        scoreLabel.GetComponent<Text>().text = score.ToString();
        pauseScoreLabel.GetComponent<Text>().text = score.ToString();
        gameOverScoreLabel.GetComponent<Text>().text = score.ToString();

        if (score >= 10 && nuEnemies == 1)
        {
            _enemyFactory.GetComponent<EnemyCreator>().CreateEnemy(_spawn:true, _move:true, _enabled:true);
            nuEnemies += 1;
            //_enemy2.SetActive(true);
        }

        if (gameOver)
        {
            if (!dataLoaded){
                LoadHighScore(); }
            if (!gameSaved){
                SaveData();}
            blurCanvas.GetComponent<BlurCanvas>().EnableCanvas(true, "gameOver");
            StopGame();
        }
        else
        {
            if (paused)
            {
                blurCanvas.GetComponent<BlurCanvas>().EnableCanvas(true, "pause");
                StopGame();
            }
            else
            {
                blurCanvas.GetComponent<BlurCanvas>().EnableCanvas(false, "pause");
                ResumeGame();
            }
        
        }
    }

    void StopGame()
    {
        _player.GetComponent<PlayerMovement>().enabled = false;
        _enemyFactory.GetComponent<EnemyCreator>().EnableMovementAllEnemies(false);
        _joystick.SetActive(false);
    }

    void ResumeGame()
    {
        _player.GetComponent<PlayerMovement>().enabled = true;
        _enemyFactory.GetComponent<EnemyCreator>().EnableMovementAllEnemies(true);
        _joystick.SetActive(true);
    }

    void SaveData()
    {
        SaveSystem.SaveUser(this, achievements.GetComponent<MainAchievements>());
        gameSaved = true;
    }

    void LoadHighScore()
    {
        try
        {
            UserData data = SaveSystem.LoadData();
            if (score > data.highScore)
            {
                highScore = score;
            }
            else
            {
                highScore = data.highScore;
            }
        }
        catch
        {
            highScore = score;
        }
        dataLoaded = true;
        gameOverHighscoreLabel.GetComponent<Text>().text = highScore.ToString();
    }
}
