using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreRec;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreRec.text = "Score: " + Player.score;
        highScoreText.text = "High Score: " + Player.highScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(7);
    }

    public void MainMenu()
    {
        Application.Quit();
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ContinueTwo()
    {
        SceneManager.LoadScene(8);
    }

    public void ContinueThree()
    {
        SceneManager.LoadScene(10);
    }


}
