
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("ThirdParts/isGameObjectClosestFromGameObject")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class isClosestFromGameObject : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        [InParam("targetGameObject")]
        [Help("  Target to check the distance")]
        public GameObject targetGameObject;

        ///<value>Input maximun distance Parameter to consider that the target is close.</value>
        [InParam("distance")]
        [Help("distance")]
        public float distance;

        /// <summary>
        /// Checks whether a target is close depending on a given distance,
        /// calculates the magnitude between the gameobject and the target and then compares with the given distance.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance.</returns>
        public override bool Check()
        {
            return ((targetGameObject.transform.position - gameObject.transform.position).sqrMagnitude <= distance);
        }
    }
}