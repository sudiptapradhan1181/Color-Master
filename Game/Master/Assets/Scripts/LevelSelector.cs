using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(5);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(8);
    }

    public void LevelFour()
    {
        SceneManager.LoadScene(10);
    }
}
