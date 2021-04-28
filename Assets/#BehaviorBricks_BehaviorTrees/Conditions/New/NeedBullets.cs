using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("New/NeedBullets")]
    [Help("")]
    public class NeedBullets : GOCondition
    {

        public override bool Check()
        {

            TankData tankData = gameObject.GetComponent<TankData>();

            if (!tankData) { return false; }

            return tankData.IsRunOutOfbullets();
        }

    }
}