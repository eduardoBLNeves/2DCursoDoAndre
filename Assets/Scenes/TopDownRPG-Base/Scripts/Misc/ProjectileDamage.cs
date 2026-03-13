using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
 
    float projectileDamage;
    void Start()
    {
        Destroy(gameObject,2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EntitiesStats>().hp -= projectileDamage;
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage)
    {
        projectileDamage = damage;
    }
}
