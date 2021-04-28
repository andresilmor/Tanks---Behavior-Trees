using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is a basic action to associate a Boolean to a variable.
    /// </summary>
    [Action("New/ControlMovement")]
    [Help("Sets a value to a boolean variable to control isStoped")]
    public class ControlMovement : GOAction
    {

        ///<value>Input Boolean Parameter.</value>
        [InParam("value")]
        [Help("Value")]
        public bool value;

        private UnityEngine.AI.NavMeshAgent navAgent;
        /// <summary>Initialization Method of SetBool.</summary>
        /// <remarks>Initializes the Boolean value.</remarks>
        public override void OnStart()
        {
            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (!navAgent || navAgent.isStopped == value) { return; }
            navAgent.isStopped = value;
        }
        /// <summary>Method of Update of SetBool.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
