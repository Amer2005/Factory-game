using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Models.Tiles
{
    public class GrassTileModel : TileModel
    {
        public GrassTileModel(int row, int col) : base(row, col, TileType.Grass)
        {

        }
    }
}
