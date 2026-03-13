using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && isActive)
        {
            GameManager.Instance.SetScoreUp();
            StartCoroutine(ReloadScore());
        }
    }

    private void Update()
    {
        if(!GameManager.IsRunning)
            GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator ReloadScore()
    {
        isActive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(10);
        GetComponent<SpriteRenderer>().enabled = true;
        isActive = true;
    }
}
