using Assets.Scripts.Enums;
using Assets.Scripts.Models.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Factories
{
    public class TileFactory
    {
        public TileModel CreateTile(int row, int col, TileType tileType)
        {
            switch(tileType)
            {
                case TileType.Grass:
                    return new GrassTileModel(row, col);
                default:
                    throw new Exception($"GroundType {tileType} not yet created in TileFactory");
            }
        }
    }
}
