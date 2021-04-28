using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    [Action("New/RefuelTank")]
    [Help("")]
    public class RefuelTank : GOAction
    {

        /// <summary>Initialization Method of SetFloat</summary>
        /// <remarks>Initializes the Float value.</remarks>
        public override void OnStart()
        {
            TankData tankData = gameObject.GetComponent<TankData>();

            if (!tankData) { return; }

            tankData.FillTheTankFuel();
            Debug.Log("[Refuel] " + gameObject.name);
        }

        /// <summary>Method of Update of SetFloat.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
