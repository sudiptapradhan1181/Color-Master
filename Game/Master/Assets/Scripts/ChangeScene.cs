using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
