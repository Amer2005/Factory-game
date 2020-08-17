using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class BuildingService
    {
        public void RemoveBuilding(int row, int col, GameModel gameModel)
        {
            gameModel.Tiles[row, col].Building = null;
        }
    }
}
