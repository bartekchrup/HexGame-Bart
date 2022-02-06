using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapGenerator : MonoBehaviour
{
    public Tilemap hexMap;
    public Tilemap selectionMap;
    public Tile plainsTile;
    public Tile oceanTile;
    public Tile selectionTile;
    public int width;
    public int height;

    void Start() {
        addTiles();
    }

    void addTiles() {
        for (int x = 0; x <= width; x++) {
            for (int y = 0; y <= height; y++) {
                if (Random.Range(0,3) == 0) { //33% chance of spawning as land
                    hexMap.SetTile(new Vector3Int(x - (width / 2), y - (height / 2), 0), plainsTile);
                } else {
                    hexMap.SetTile(new Vector3Int(x - (width / 2), y - (height / 2), 0), oceanTile);
                }

            }
        }
    }

    void selectTile(Vector3Int coordinate)
    {

        selectionMap.ClearAllTiles();
        selectionMap.SetTile(coordinate, selectionTile);
        Debug.Log(coordinate);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tileCoord = selectionMap.WorldToCell(mousePos);
            selectTile(tileCoord);
            
        }
    }
}
