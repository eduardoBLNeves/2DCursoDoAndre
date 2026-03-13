using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateEnemy()
    {
        while (GameObject.FindGameObjectWithTag("Player").GetComponent<EntitiesStats>().hp>0) {
            var random = new System.Random();
            var randomPos = new Vector3(random.Next(-8, 8), random.Next(-5, 5), 1);
            GameObject enemy = Instantiate(Enemy, randomPos, Quaternion.identity); 
            yield return new WaitForSeconds(.5f);
        }

    }
}

