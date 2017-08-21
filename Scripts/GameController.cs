using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject block;
    public GameObject brick;
    public GameObject player1;
    public GameObject player2;
    public Button restart;
    public Button quit;
    public Button resume;
    public Text gameOver;
    public Vector3 lowSpawnBrick;
    public Vector3 highSpawnBrick;
    Quaternion spawnRotation = Quaternion.identity;
    int countX;
    int countY = 1;
    int r;
    bool spawnable;

    private void Awake()
    {
        gameOver.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        Time.timeScale = 1;

        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
        resume.onClick.AddListener(Resume);
    }

    void Resume()
    {
        Time.timeScale = 1;
        restart.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Quit()
    {
        Application.Quit();
    }

    public void Start()
    {
        SpawnBlocks();

    }

    void SpawnBlocks()
    {
        for (float i = lowSpawnBrick.x; i <= highSpawnBrick.x; i++)
        {
            countX++;
            for (float j = lowSpawnBrick.z; j <= highSpawnBrick.z; j++)
            {
                spawnable = true;
                if ((i == -9 && j == 6) || (i == -8 && j == 6) || (i == -9 && j == 5) || (i == 9 && j == 6) || (i == 8 && j == 6) || (i == 9 && j == 5))
                    spawnable = false;
                r = Random.Range(0, 2);
                countY++;
                if (countX % 2 == 0 && countY % 2 == 0)
                    Instantiate(block, new Vector3(i, 0.5f, j), spawnRotation);
                else if (r != 0 && spawnable)
                    Instantiate(brick, new Vector3(i, 0.5f, j), spawnRotation);
            }
        }
    }

    private void Update()
    {
        if (!player1.GetComponent<PlayerBehaviour>().isAlive)
        {
            Player1Death();
        }
        else if (!player2.GetComponent<PlayerBehaviour>().isAlive)
        {
            Player2Death();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            restart.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
            resume.gameObject.SetActive(true);
        }
    }

    void Player1Death()
    {
        gameOver.text = "Player 2 Wins!";
        gameOver.color = new Color(255, 0, 0, 255);
        Destroy(player1.gameObject);
        GameOver();

    }

    void Player2Death()
    {
        gameOver.text = "Player 1 Wins!";
        gameOver.color = new Color(0, 0, 255, 255);
        Destroy(player2.gameObject);
        GameOver();
    }

    void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
