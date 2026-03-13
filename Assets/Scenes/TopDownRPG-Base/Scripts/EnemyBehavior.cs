using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EntitiesStats entityStats;
    [SerializeField] float moveSpeed = 0.8f;
    GameObject PlayerObejct;

    void Start()
    {
        PlayerObejct = GameObject.FindGameObjectWithTag("Player");
        entityStats = gameObject.GetComponent<EntitiesStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerObejct.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntitiesStats>().hp -= entityStats.attackDamage;
            entityStats.hp -= entityStats.maxHP + 1;
        }
    }
}
