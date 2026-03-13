using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject ProjectTile_;
    private EntitiesStats stats;
    float cooldown_ = 0;
    bool canAttack = true;

    void Start()
    {
        stats = gameObject.GetComponent<EntitiesStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            GameObject projectileInstance = Instantiate(ProjectTile_, transform.position, Quaternion.identity);
            projectileInstance.GetComponent<ProjectileDamage>().SetDamage(stats.attackDamage);

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) -  transform.position;
            direction.Normalize();

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(direction * stats.projectileSpeed, ForceMode2D.Impulse);

            canAttack = false;
            cooldown_ = 0;
        }

        Cooldown();
    }

    void Cooldown()
    {
        if( cooldown_ > stats.attackSpeed && !canAttack)
        {
            canAttack = true;
        }
        else
        {
            cooldown_ += Time.deltaTime;
        }
    }


}
