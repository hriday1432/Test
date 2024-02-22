using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    [SerializeField] bool blocked;

    public Vector2Int cords;

    GridGenerator gridManager;

    void Start()
    {
        if (blocked)
        {
            gridManager.BlockNode(cords);
        }
    }
}