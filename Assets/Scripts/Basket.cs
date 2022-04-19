using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class Basket : MonoBehaviour
{
    public Text scoreText;
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
    }
    private void Update()
    {
        Vector3 mousePosition2D = Input.mousePosition;
        mousePosition2D.z = -Camera.main.transform.position.z;
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        Vector3 position = transform.position;
        position.x = mousePosition3D.x;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision col)
    {
        GameObject collidedWith = col.gameObject;
        if (collidedWith.tag == "Apple")
            Destroy(collidedWith);

        int score = int.Parse(scoreText.text);
        score += 100;
        scoreText.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
