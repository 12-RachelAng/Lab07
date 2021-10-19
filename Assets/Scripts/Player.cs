using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Vector3 Jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;

    public GameObject ScoreCounter;
    public static int Score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Jump = new Vector3(0.0f, 2.0f, 0.0f);
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Jump * jumpForce, ForceMode.Impulse);
            thisAnimation.Play();
        }

        ScoreCounter.GetComponent<Text>().text = "Score: " + Score;
            
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Border (Bottom)" || other.gameObject.tag == "Border (Top)")
        {
            //GameManager.thisManager.GameOver();
            SceneManager.LoadScene("Lose");
        }

        if (other.gameObject.tag == "Obstacles")
        {
            //GameManager.thisManager.GameOver();
            SceneManager.LoadScene("Lose");
        }
    }

    //Retry Button
    public void RetryButton()
    {
        Score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
