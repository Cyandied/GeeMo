using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap;
    [SerializeField] private Tilemap tillMap;
    [SerializeField] private Tilemap signMap;
    [SerializeField] private RuleTile Highlight;
    [SerializeField] private Tile hoverTile;
    [SerializeField] private Tile signTile;
    private Vector3Int prevoiusMousePos = new Vector3Int();

    void Start(){
        grid = gameObject.GetComponent<Grid>();
    }

    void Update()
    {
        Vector3Int mousePos = GetMousePosition();
        if(!mousePos.Equals(prevoiusMousePos)){
            interactiveMap.SetTile(prevoiusMousePos,null);
            interactiveMap.SetTile(mousePos,hoverTile);
            prevoiusMousePos = mousePos;
        }
    }

    Vector3Int GetMousePosition(){
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return grid.WorldToCell(mousePos);
    }
}
