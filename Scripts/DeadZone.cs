using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Colisión");
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Trigger");
    //}

    public Text scorePlayerText;
    public Text scoreEnemyText;

    public int scorePlayerQuantity;
    public int scoreEnemyQuantity;

    public SceneChanger sceneChanger;

    public AudioSource pointAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Left"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if (gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }

        collision.GetComponent<BallBehaviour>().gameStarted = false;
        pointAudio.Play();
        CheckScore();
    }

    void CheckScore()
    {
        if(scorePlayerQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        } else if(scoreEnemyQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
