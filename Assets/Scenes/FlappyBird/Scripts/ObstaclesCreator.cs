using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstaclesCreator : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject bird;
    public bool canCreateObstacles = false;
    public float creationSpeed = 1; 

    public IEnumerator SpawnObstacles()
    {
        canCreateObstacles = true;

        while (canCreateObstacles) {
            var newObstacle = Instantiate(obstacle, this.transform);
            SetObstaclePosition(newObstacle);
            yield return new WaitForSeconds(creationSpeed);
        }
    }

    void SetObstaclePosition(GameObject obstacle)
    {
        var Yaxis = Random.Range(-1f, 5f);
        obstacle.transform.position = new Vector3(10f, Yaxis, 0);
    }
}
