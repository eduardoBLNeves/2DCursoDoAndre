using System.Collections;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 1.0f;
    BirdController birdController;

    void Start()
    {
        birdController = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
        StartCoroutine(ScheduleDestroy());
    }

    void FixedUpdate()
    {
        if (birdController.isRunning)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
        }
    }
    IEnumerator ScheduleDestroy()
    {
        yield return new WaitForSeconds(10);
        if(birdController.isRunning)
            Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            birdController.GameOver();
    }
}
