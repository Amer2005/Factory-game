using Assets.Scripts.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    // Start is called before the first frame update

    private GameController gameController;

    private string GroundPath = "Prefabs/Tiles/";
    private string BuildingPath = "Prefabs/Buildings/";
    private string ItemPath = "Prefabs/Items/";

    private GameObject[,] tileGameObjects;
    private GameObject[,] buildingGameObjects;
    private GameObject[,] itemGameObjects;

    void Start()
    {
        int rows = 10;
        int cols = 10;

        gameController = new GameController(rows, cols);

        tileGameObjects = new GameObject[rows, cols];
        buildingGameObjects = new GameObject[rows, cols];
        itemGameObjects = new GameObject[rows, cols];

        RenderEverything();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RenderEverything()
    {
        RenderTiles();
        RenderBuildings();
        RenderItems();
    }

    private void RenderTiles()
    {
        GameModel gameModel = gameController.GetGameModel();

        GameObject tiles = new GameObject("GroundTiles");

        for (int row = 0; row < gameModel.Rows; row++)
        {
            for (int col = 0; col < gameModel.Cols; col++)
            {
                GameObject tilePrefabNow = Resources.Load<GameObject>(GroundPath + gameModel.Tiles[row, col].TileType.ToString());

                tileGameObjects[row, col] = (GameObject)GameObject.Instantiate(tilePrefabNow, new Vector3(row, col), Quaternion.identity, tiles.transform);
                tileGameObjects[row, col].name = $"{row}, {col}";
            }
        }
    }

    private void RenderBuildings()
    {
        GameModel gameModel = gameController.GetGameModel();

        GameObject buildings = new GameObject("Buildings");

        for (int row = 0; row < gameModel.Rows; row++)
        {
            for (int col = 0; col < gameModel.Cols; col++)
            {
                if (gameModel.Tiles[row, col].Building == null)
                {
                    continue;
                }

                GameObject buildingNowPrefab = Resources.Load<GameObject>(BuildingPath + gameModel.Tiles[row, col].Building.BuildingType.ToString());

                buildingGameObjects[row, col] = (GameObject)GameObject.Instantiate(buildingNowPrefab, new Vector3(row, col), Quaternion.identity);
                buildingGameObjects[row, col].name = $"{row}, {col}";
                buildingGameObjects[row, col].transform.parent = buildings.transform;

                RotateGameObjectByDirection(tileGameObjects[row, col], gameModel.Tiles[row, col].Building.Direction);
            }
        }
    }

    private void RenderItems()
    {
        GameModel gameModel = gameController.GetGameModel();

        GameObject items = new GameObject("Items");

        for (int row = 0; row < gameModel.Rows; row++)
        {
            for (int col = 0; col < gameModel.Cols; col++)
            {
                if (gameModel.Tiles[row, col].Item == null)
                {
                    continue;
                }

                GameObject itemNowPrefab = Resources.Load<GameObject>(ItemPath + gameModel.Tiles[row, col].Item.ItemType.ToString());

                itemGameObjects[row, col] = (GameObject)GameObject.Instantiate(itemNowPrefab, new Vector3(row, col), Quaternion.identity);
                itemGameObjects[row, col].name = $"{row}, {col}";
                itemGameObjects[row, col].transform.parent = items.transform;
            }
        }
    }

    private void RotateGameObjectByDirection(GameObject now, DirectionType direction)
    {
        if(direction == DirectionType.up)
        {
            now.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (direction == DirectionType.right)
        {
            now.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (direction == DirectionType.down)
        {
            now.transform.eulerAngles = new Vector3(0, 0, -90);
        }

        if (direction == DirectionType.left)
        {
            now.transform.eulerAngles = new Vector3(0, 0, -180);
        }

    }
}
