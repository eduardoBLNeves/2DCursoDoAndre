using UnityEngine;

public class EntitiesStats : MonoBehaviour
{

    public float maxHP;
    public float hp;
    public float baseMoveSpeed;
    public float attackSpeed;
    public float projectileSpeed;
    public float attackDamage;

    private void Start()
    {
        hp = maxHP;   
    }

    private void Update()
    {
        Death();
    }

    private void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
