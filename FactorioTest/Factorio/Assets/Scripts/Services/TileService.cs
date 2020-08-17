using Assets.Scripts.Factories;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Models.Buildings;

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

            tiles[0, 0].Building = buildingFactory.CreateBuilding(BuildingType.ConveyorBelt, DirectionType.right);

            return tiles;
        }
    }
}
