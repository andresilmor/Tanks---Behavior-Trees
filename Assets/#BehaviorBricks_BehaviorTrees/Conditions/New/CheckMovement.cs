using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;
using UnityEngine.AI;


namespace BBUnity.Conditions {
    /// <summary>
    /// It is a basic condition to check if Booleans have the same value.
    /// </summary>
    [Condition("New/CheckMovement")]
    [Help("Checks whether two booleans have the same value")]
    public class CheckMovement : GOCondition {

        ///<value>Input Second Boolean Parameter.</value>
        [InParam("value")]
        [Help("Value to be compared")]
        public bool value;

        /// <summary>
        /// Checks whether two booleans have the same value.
        /// </summary>
        /// <returns>the value of compare first boolean with the second boolean.</returns>
		public override bool Check() {
            NavMeshAgent navMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (!navMesh) { return false; }
            return navMesh.isStopped == value;
        }
    }
}
