using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public bool[,] obstacleGrid = new bool[10, 10];
}
