using Assets.Scripts.Factories;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Models.Buildings;
using Assets.Scripts.Models;

namespace Assets.Scripts.Services
{
    public class TileService
    {
        private TileFactory tileFactory;
        private BuildingFactory buildingFactory;

        public TileService()
        {
            tileFactory = new TileFactory();
            buildingFactory = new BuildingFactory();
        }

        public TileModel[,] GenerateTiles(int rows, int cols)
        {
            TileModel[,] tiles = new TileModel[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    tiles[row, col] = tileFactory.CreateTile(row, col, TileType.Grass);
                }
            }

            tiles[0, 0].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.up);
            tiles[0, 1].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.up);
            tiles[0, 2].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.right);
            tiles[1, 2].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.right);
            tiles[2, 2].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.down);
            tiles[2, 1].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.down);
            tiles[2, 0].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.left);
            tiles[1, 0].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.left);
            //tiles[0, 0].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.up);
            tiles[0, 0].Item = new ItemModel(ItemType.IronOre);
            tiles[0, 1].Item = new ItemModel(ItemType.IronOre);
            tiles[0, 2].Item = new ItemModel(ItemType.IronOre);
            //tiles[1, 2].Item = new ItemModel(ItemType.IronOre);
            //tiles[2, 2].Item = new ItemModel(ItemType.IronOre);
            //tiles[2, 1].Item = new ItemModel(ItemType.IronOre);
            //tiles[2, 0].Item = new ItemModel(ItemType.IronOre);

            return tiles;
        }
    }
}