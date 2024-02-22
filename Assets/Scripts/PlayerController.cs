using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    [SerializeField] Transform player;

    [SerializeField] LayerMask ground;

    bool isMoving = false;

    List<Node> path = new List<Node>();

    GridGenerator gridManager;
    Pathfinding pathFinder;
    void Start()
    {
        gridManager = FindObjectOfType<GridGenerator>();
        pathFinder = FindObjectOfType<Pathfinding>();
    }
    void Update()
    {
 
            if (Input.GetMouseButtonDown(0) && isMoving == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                bool hasHit = Physics.Raycast(ray, out hit,Mathf.Infinity,ground);



                if (hasHit)
                {
                    Vector2Int targetCords = hit.transform.GetComponent<TileInfo>().cords;
                    Vector2Int startCords = new Vector2Int((int)player.transform.position.x, (int)player.transform.position.z);
                    pathFinder.SetNewDestination(startCords, targetCords);
                    RecalculatePath(true);
                    isMoving = true;
                }
            }
        
    }
    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
        if (resetPath)
        {
            coordinates = pathFinder.StartCords;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = player.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].cords);
            float travelPercent = 0f;

            player.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                Vector3 offset = new Vector3(0, 0.5f, 0);
                player.position = Vector3.Lerp(startPosition, endPosition+offset, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        player.rotation = Quaternion.identity;
        isMoving = false;
    }
}
