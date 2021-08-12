using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody r;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public GameObject youWinUI;
    public Image WinLoseBG;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            r.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            r.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            r.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            r.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        if (other.gameObject.tag == "Goal")
        {
            youWinUI.SetActive(true);
            WinLoseText.text = "You Win!";
            WinLoseText.color = Color.black;
            WinLoseBG.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        if (health == 0)
        {
            youWinUI.SetActive(true);
            WinLoseText.text = "Game Over!";
            WinLoseBG.color = Color.red;
            WinLoseText.color = Color.white;
            StartCoroutine(LoadScene(3));
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}