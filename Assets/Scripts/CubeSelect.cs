using UnityEngine;

public class CubeSelect : MonoBehaviour
{
    private Renderer render;

    private void Start()
    {
        render=GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        render.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        render.material.color = Color.white;
    }
}
