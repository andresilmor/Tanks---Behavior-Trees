
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("ThirdParts/IsTankDead")]
    [Help("Checks whether the tank is dead")]
    public class IsTankDead : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        [InParam("tank")]
        [Help("Target to check the fuel")]
        public TankData tank;


        /// <summary>
        /// Checks whether a target is close depending on a given distance,
        /// calculates the magnitude between the gameobject and the target and then compares with the given distance.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance.</returns>
        public override bool Check()
        {
            return tank.IsDead();
        }
    }
}