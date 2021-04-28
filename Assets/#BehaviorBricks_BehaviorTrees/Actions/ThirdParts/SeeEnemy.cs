
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("ThirdParts/SeeEnemy")]
    [Help("Checks if it see any enemy")]
    public class SeeEnemy : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
      
        [InParam("enemyTag")]
        [Help("Tag of enemy")]
        public string enemyTag;

        [InParam("eyesPosition")]
        [Help("Eyes Position")]
        public Transform eyesPosition;

        [InParam("lookRange")]
        [Help("Look Range")]
        public int lookRange;

        [InParam("lookSphereCastRadius")]
        [Help("look Sphere Cast Radius")]
        public int lookSphereCastRadius;

        [OutParam("enemy")]
        [Help("Enemy Game Object ")]
        public GameObject enemy;
        /// <summary>
        /// Checks whether a target is close depending on a given distance,
        /// calculates the magnitude between the gameobject and the target and then compares with the given distance.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance.</returns>


        public override bool Check()
        {
            return Look();
        }

        private bool Look()
        {
            RaycastHit hit;

            Debug.DrawRay(eyesPosition.position, eyesPosition.forward.normalized * lookRange, Color.red);

            if (Physics.SphereCast(eyesPosition.position, lookSphereCastRadius, eyesPosition.forward, out hit, lookRange)
                && hit.collider.CompareTag(enemyTag))
            {
                enemy = hit.transform.gameObject;
                Debug.Log("[SeeEnemy] | " + gameObject.name + " see " + enemy.name);
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}