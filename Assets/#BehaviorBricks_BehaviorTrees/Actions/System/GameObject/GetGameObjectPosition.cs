using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    ///It is an action to get GameObject position.
    /// </summary>
    [Action("GameObject/GetGameObjectPosition")]
    [Help("Returns gameobject position")]
    public class GetGameObjectPosition : GOAction
    {

        ///<value>Input Object to be cloned Parameter.</value>
        [InParam("gameObject")]
        [Help("Object to get position")]
        public GameObject gameObject;

      
        ///<value>OutPut instantiated game object Parameter.</value>
        [OutParam("position")]
        [Help("gameobject Position")]
        public Vector3 position;


        /// <summary>Initialization Method of Instantiate.</summary>
        /// <remarks>Installed a GameObject in the position and type dice.</remarks>
        public override void OnStart()
        {
            position = gameObject.transform.position;
        }

        /// <summary>Method of Update of Instantiate.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
