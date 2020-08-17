using Assets.Scripts.Enums;
using Assets.Scripts.Models.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Factories
{
    public class BuildingFactory
    {
        public BuildingModel CreateBuilding(BuildingType buildingType, DirectionType direction)
        {
            switch (buildingType)
            {
                case BuildingType.ConveyorBelt:
                    return new ConveyorBeltModel(direction);
                default:
                    throw new Exception("Building not found");
            }
        }
    }
}
