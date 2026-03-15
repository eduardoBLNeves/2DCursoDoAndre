using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    EntitiesStats stats;
    float moveSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = gameObject.GetComponent<EntitiesStats>();
        moveSpeed = stats.baseMoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WASD_Move();
    }

    void WASD_Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if((horizontal>0 || horizontal<0) && (vertical>0 || vertical < 0)){
            moveSpeed = stats.baseMoveSpeed * 0.66f;
        }
        else
        {
            moveSpeed = stats.baseMoveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime));
    }

}
