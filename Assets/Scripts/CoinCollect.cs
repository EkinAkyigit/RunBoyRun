using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CoinCollect : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController pController;
    public int maxScore;

    public Animator anim;
    public GameObject Player;
    public GameObject finish;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("finish"))
        {
            pController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            finish.SetActive(true);

            if (score >= maxScore)
                anim.SetBool("win", true);
            else
                anim.SetBool("lose", true);
        }
    }

    public void RestartGame()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
