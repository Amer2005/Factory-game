using Assets.Scripts.Models;
using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controllers
{
    public class GameController
    {
        private GameModel gameModel;

        private int rows;
        private int cols;

        private TileService tileService;
        private ConveyorBeltService conveyorBeltService;
        private BuildingService buildingService;

        public GameController(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.tileService = new TileService();
            this.conveyorBeltService = new ConveyorBeltService();
            this.buildingService = new BuildingService();
        }

        public GameModel GetGameModel()
        {
            if(gameModel == null)
            {
                gameModel = new GameModel(rows, cols);
                gameModel.Tiles = tileService.GenerateTiles(rows, cols);
            }

            return gameModel;
        }

        public void UpdateConveyorBelts()
        {
            conveyorBeltService.UpdateConveyorBelts(GetGameModel());
        }

        public void BreakBuilding(int row, int col)
        {
            buildingService.RemoveBuilding(row, col, GetGameModel());
        }
    }
}
