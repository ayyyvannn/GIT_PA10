using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;

    public int score;

    public Text ScoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            thisAnimation.Play();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 5, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bottom")
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreObject")
        {
            score += 1;

            ScoreText.text = "SCORE : " + score;
        }
    }
}
