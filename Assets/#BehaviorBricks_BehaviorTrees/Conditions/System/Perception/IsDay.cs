using Pada1.BBCore.Framework;
using Pada1.BBCore;
using BBSamples.PQSG;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a basic action to associate a Boolean to a variable.
    /// </summary>
    [Condition("Basic/IsDay")]
    [Help("Sets a value to a boolean variable")]
    public class IsDay : GOCondition
    {
    
        /// <summary>
        /// Checks if the target healthy depending on a given healthy,
        /// </summary>
        /// <returns>True if the healthy is higher  thatn the given healthy.</returns>
        public override bool Check()
        {
            GameObject mainLight = GameObject.FindGameObjectWithTag("MainLight");
            bool isDay = !mainLight.GetComponent<DoneDayNightCycle>().isNight;

            return isDay;
        }

    }
}
