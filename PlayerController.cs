using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float screenWidth = Screen.width;
    public static float speed = 8;

    public int collectedCoins = 0;
    private static int highScore = 0;

    public Text highScoreText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        List<Color> colors = new List<Color> { Color.red, Color.blue, Color.cyan, Color.green };
        Color randomColor = colors[Random.Range(0, colors.Count)];
        GetComponent<Renderer>().material.color = randomColor;

        highScoreText.text = "High score: " + highScore;
        scoreText.text = "Score: " + collectedCoins;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0)
        {
            //Gépi irányítés
            if(Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f)
            {
                transform.position += Vector3.left;
            }
            if(Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f)
            {
                transform.position += Vector3.right;
            }

            //Telefonos irámyítás
            for(int i = 0; i < Input.touchCount; i++)
            {
                if(Input.GetTouch(i).position.x < screenWidth / 2 
                && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x > -1.5f)
                {
                    transform.position += Vector3.left;
                }
                if(Input.GetTouch(i).position.x > screenWidth / 2 
                && Input.GetTouch(i).phase == TouchPhase.Ended && transform.position.x < 1.5f)
                {
                    transform.position += Vector3.right;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().name.Contains("Obstacle"))
        {
            Destroy(other.gameObject);

            if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
            {
                StartCoroutine(gameEnd());
            }
        }

        if (other.GetComponentInChildren<Transform>().name.Contains("Coin"))
        {
            collectedCoins += 1;
            speed += 1;
            scoreText.text = "Score: " + collectedCoins;
            if (highScore < collectedCoins)
            {
                highScore = collectedCoins;
                highScoreText.text = "High score: " + highScore;
            }

            ObjectPools.Instance.ReturnToPool(other.GetComponent<CoinController>());
        }
    }

    IEnumerator gameEnd()
    {
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = 8;
        SceneManager.LoadScene("SampleScene");
    }
}   
