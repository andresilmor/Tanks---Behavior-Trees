using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("New/NeedFuel")]
    [Help("Sets a value to a boolean variable")]
    public class NeedFuel : GOCondition
    {

        [InParam("minFuelPercentage")]
        [Help("Write the min percentage to go refuel")]
        public float minFuelPercentage = 10;

        public override bool Check()
        {
            
            TankData tankData = gameObject.GetComponent<TankData>();

            if (!tankData) { return false; }


            return tankData.GetActualFuel() <= minFuelPercentage * tankData.GetMaxFuel() / 100 ? true : false;
        }

    }
}