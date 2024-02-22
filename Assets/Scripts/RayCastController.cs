using UnityEngine;
using TMPro;
public class RayCastController : MonoBehaviour
{
    public TextMeshProUGUI Maintext;
    private GameObject previousHitObject;
    void Update()
    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            if (tileInfo != null)
            {
                Maintext.text = "Selected Tile: " + tileInfo.cords;
            }
        }
        else
        {
            Maintext.text = " "; 
        }
        
    }
}
