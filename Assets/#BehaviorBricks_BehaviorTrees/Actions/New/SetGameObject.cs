using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions {
    /// <summary>
    /// It is a basic action to associate a Boolean to a variable.
    /// </summary>
    [Action("New/SetGameObject")]
    [Help("Sets a value to a boolean variable")]
    public class SetGameObject : BasePrimitiveAction {


        ///<value>OutPut Boolean Parameter.</value>
        [OutParam("originalGameObject")]
        [Help("GameObject that will change")]
        public GameObject originalGameObject;


        ///<value>Input Boolean Parameter.</value>
        [InParam("newGameObject")]
        [Help("GameObject that will be attributed")]
        public GameObject newGameObject;

        /// <summary>Initialization Method of SetBool.</summary>
        /// <remarks>Initializes the Boolean value.</remarks>
        public override void OnStart() {
            if (!newGameObject) { newGameObject = null; }
            if (!originalGameObject) { return; }
            originalGameObject = newGameObject;
            
        }
        /// <summary>Method of Update of SetBool.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate() {
            return TaskStatus.COMPLETED;
        }
    }
}
