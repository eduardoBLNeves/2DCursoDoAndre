using System;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GameObject UI;
    public ObstaclesCreator obstaclesCreator;
    public float moveSpeed = 1.0f;
    public bool isRunning = true;


    void Start()
    {
        GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void PlayerMovement()
    {
        if (!isRunning) return;

        bool isPressed = Input.GetKeyDown(KeyCode.Space);
        if (isPressed)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
        }
    }

    public void ResetGame()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        isRunning = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        SetupUIText();
        UI.SetActive(false);
        StartCoroutine(obstaclesCreator.SpawnObstacles());

        foreach (Transform child in obstaclesCreator.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void GameOver()
    {
        obstaclesCreator.canCreateObstacles = false;
        isRunning = false;
        UI.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    void SetupUIText()
    {
        var UIText = UI.GetComponentInChildren<TextMeshProUGUI>();
        if (UIText != null && UIText.text == "WELCOME!")
            UIText.text = "GAME OVER!";
    }
}
