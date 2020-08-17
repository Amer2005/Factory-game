using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class ConveyorBeltService
    {
        public void UpdateConveyorBelts(GameModel gameModel)
        {
            bool[,] visited = new bool[gameModel.Rows, gameModel.Cols];

            for (int row = 0; row < gameModel.Rows; row++)
            {
                for (int col = 0; col < gameModel.Cols; col++)
                {
                    if (DoesTileHaveConveyorBelt(row, col, gameModel))
                    {
                        UpdateConveyorBelt(row, col, gameModel, visited);
                    }
                }
            }
        }

        public void UpdateConveyorBelt(int row, int col, GameModel gameModel, bool[,] visited)
        {
            if (visited[row, col] == true)
            {
                return;
            }

            visited[row, col] = true;
            if (gameModel.Tiles[row, col].Item == null)
            {
                return;
            }
            if (!DoesTileHaveConveyorBelt(row, col, gameModel))
            {
                return;
            }

            TileModel nextTile = NextConveyorBeltTile(row, col, gameModel);

            UpdateConveyorBelt(nextTile.Row, nextTile.Col, gameModel, visited);

            if (nextTile.Item == null)
            {
                nextTile.Item = gameModel.Tiles[row, col].Item;
                gameModel.Tiles[row, col].Item = null;
                visited[nextTile.Row, nextTile.Col] = true;
            }
        }

        public bool DoesTileHaveConveyorBelt(int row, int col, GameModel gameModel)
        {
            if (gameModel.Tiles[row, col].Building == null || gameModel.Tiles[row, col].Building.BuildingType != BuildingType.ConveyorBelt)
            {
                return false;
            }

            return true;
        }

        public TileModel NextConveyorBeltTile(int row, int col, GameModel gameModel)
        {
            if (gameModel.Tiles[row, col].Building.Direction == DirectionType.up)
            {
                return gameModel.Tiles[row, col + 1];
            }
            else if (gameModel.Tiles[row, col].Building.Direction == DirectionType.down)
            {
                return gameModel.Tiles[row, col - 1];
            }
            else if (gameModel.Tiles[row, col].Building.Direction == DirectionType.left)
            {
                return gameModel.Tiles[row - 1, col];
            }
            else
            {
                return gameModel.Tiles[row + 1, col];
            }
        }
    }
}