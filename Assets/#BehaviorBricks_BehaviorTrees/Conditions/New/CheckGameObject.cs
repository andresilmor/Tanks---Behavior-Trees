using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

namespace BBCore.Conditions
{
    [Condition("New/CheckGameObject")]
    [Help("Checks if gameobject variable is valid")]
    public class CheckGameObject : ConditionBase 
    {
        [InParam("gameObject")]
        [Help("")]
        public GameObject gameObject;

		public override bool Check()
        {
            if (!gameObject || !gameObject.activeInHierarchy) { return false; }
            return true;
        }
    }
}
