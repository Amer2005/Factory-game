using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Buildings
{
    public class BuildingModel
    {
        public BuildingType BuildingType { get; set; }

        public DirectionType Direction { get; set; }

        public BuildingModel(BuildingType building, DirectionType direction)
        {
            BuildingType = building;
            Direction = direction;
        }
    }
}
