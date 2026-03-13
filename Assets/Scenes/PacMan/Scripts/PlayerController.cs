using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseMoveSpeed = 1;
    float currentMoveSpeed;

    void Start()
    {
        currentMoveSpeed = baseMoveSpeed;
    }

    void FixedUpdate()
    {
        if (!GameManager.IsRunning) return;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        if ((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0))
        {
            currentMoveSpeed = baseMoveSpeed* 0.66f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * currentMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * currentMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * currentMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * currentMoveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameManager.Instance.GameOver();
        }
        if (collision.collider.tag == "Score")
        {
            GameManager.Instance.SetScoreUp();
        }
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}
