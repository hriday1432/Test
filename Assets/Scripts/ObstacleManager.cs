using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab;
    GridGenerator gridManager;
    private void Start()
    {
        gridManager = FindObjectOfType<GridGenerator>();
    }
    void Update()
    {
        GenerateObstacles();

    }

    private void GenerateObstacles()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (obstacleData.obstacleGrid[x, y])
                {
                    Vector2Int cords = new Vector2Int(x, y);
                    Vector3 position = new Vector3(x, 0.5f, y);
                    Instantiate(obstaclePrefab, position, Quaternion.identity);
                    gridManager.BlockNode(cords);
                }
            }
        }
    }
}
