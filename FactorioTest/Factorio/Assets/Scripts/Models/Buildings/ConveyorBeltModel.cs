using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Buildings
{
    public class ConveyorBeltModel : BuildingModel
    {
        public ConveyorBeltModel(DirectionType direction) : base(BuildingType.ConveyorBelt, direction)
        {

        }
    }
}
