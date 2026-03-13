using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public EntitiesStats PlayerStats;
    public Slider HP_Bar;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP();
    }

    void PlayerHP()
    {
        HP_Bar.maxValue = PlayerStats.maxHP;
        HP_Bar.value = PlayerStats.hp;
    }
}
