using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 

public class Player : MonoBehaviour
{
    //public ColorChanger _colorChanger;
    public Text angleText;

    public static int datacurr = 0;
    public static int dataprev = 0;
    public static bool firestatus = false;
    
    public float jumpForce = 2f;
    public static Vector3 gravity;

    //public GameObject destroyedVersion;
    public GameObject EnemyPrefab;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public Text scoreText;
    public Text motivationText;
    public static int score;
    public static int highScore;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    void Start()
    {
        MusicSource.clip = MusicClip;
        EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = 0;

        // MusicSource1.clip = MusicClip1;
        //MusicSource2.clip = MusicClip2;
        //MusicSource3.clip = MusicClip3;
        //MusicSourceColor.clip = MusicClipColor;
        score = 0;
        datacurr = 0;
        UpdateScore();
        UpdateAngle();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        //UpdateMotivation();
        SetRandomColor();
        motivationText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("Waitforgravity");
        //EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = 1;
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        /*datacurr = Jump.angles[3];
        Debug.Log(datacurr);
        UpdateAngle();
        //if (datacurr > 0) { EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = 1.0f; }
        if (datacurr <= 25) { dataprev = datacurr;  }
        if (dataprev <= 25 && datacurr >=45) { firestatus = true; dataprev = datacurr; }
        if (firestatus == true)*/
        {
           EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            rb.velocity = Vector2.up * jumpForce;
            //Physics.gravity = new Vector3(0, -1.0f, 0);
            score++;
            UpdateScore();
            firestatus = false;
        }
    }

    IEnumerator Waitforgravity()
    {
        EnemyPrefab.GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(5); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 10;
            UpdateScore();
            UpdateAngle();
            SetRandomColor();
            Destroy(col.gameObject);
            UpdateMotivation();
            return;
        }

        if (col.tag == "Won")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 100;
            UpdateScore();
            UpdateAngle();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
            SetRandomColor();
            Destroy(col.gameObject);
            UpdateMotivation();
            return;
        }

        if (col.tag == "Won2")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 200;
            UpdateScore();
            UpdateAngle();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            SceneManager.LoadScene(9) ;
            SetRandomColor();
            Destroy(col.gameObject);
            UpdateMotivation();
            return;
        }

        if (col.tag == "Won3")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 300;
            UpdateScore();
            UpdateAngle();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            SceneManager.LoadScene(11);
            SetRandomColor();
            Destroy(col.gameObject);
            UpdateMotivation();
            return;
        }

        if (col.tag == "Won4")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 500;
            UpdateScore();
            UpdateAngle();
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            SceneManager.LoadScene(2);
            SetRandomColor();
            Destroy(col.gameObject);
            UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 20;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer1")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 30;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer2")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 50;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer3")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 100;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer4")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 40;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer5")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 60;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer6")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 100;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }

        if (col.tag == "Pointer7")
        {
            MusicSource.clip = MusicClip;
            MusicSource.Play();
            score += 200;
            UpdateScore();
            UpdateAngle();
            //SetRandomColor();
            Destroy(col.gameObject);
            //UpdateMotivation();
            return;
        }
        if (col.tag != currentColor)
        {
            //Instantiate(destroyedVersion, transform.position, transform.rotation);
            //Destroy(gameObject);
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }
            UpdateScore();
            UpdateAngle();
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene(3);

            /* Debug.Log("GAME OVER!");
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);*/
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
    /*void SetColor()
    {
        currentColor = _colorChanger.currentColor;
        sr.color = _colorChanger.sr.color;
    }*/
    void UpdateScore()
    {
        scoreText.text = " Score: " + score;
    }

    void UpdateAngle()
    {
        angleText.text = " Angle: " + datacurr;
    }

    void UpdateMotivation()
    {
        if (score > 50)
        {
            motivationText.text = "You are doing well";
        }

        if(score>100)
        {
            motivationText.text = "You can do it!!!!";
        }
    }

    void DelayInExplosion()
    {
        UpdateScore();
        Debug.Log("GAME OVER!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}

