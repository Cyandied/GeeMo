using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveMap;
    [SerializeField] private Tilemap tillMap;
    [SerializeField] private Tilemap signMap;
    [SerializeField] private Tile tilledTile;
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
        MoveHighligher(mousePos);
        if(Input.GetMouseButtonDown(0)){
            switch(Player.WhatTool()){
                case 0:
                    break;
                case 1:
                    TillSoil(mousePos);
                break;
                default:
                    break;
            }
        }
    }

    void MoveHighligher(Vector3Int mousePos){
        if(!mousePos.Equals(prevoiusMousePos)){
            interactiveMap.SetTile(prevoiusMousePos,null);
            interactiveMap.SetTile(mousePos,hoverTile);
            prevoiusMousePos = mousePos;
        }
    }

    void TillSoil(Vector3Int mousePos){
        if(!tillMap.GetTile<Tile>(mousePos) == tilledTile){
            tillMap.SetTile(mousePos,tilledTile);
        }
    }

    Vector3Int GetMousePosition(){
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return grid.WorldToCell(mousePos);
    }
}
