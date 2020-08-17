using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class GameModel
    {
        public TileModel[,] Tiles { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public GameModel(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
        }
    }
}
