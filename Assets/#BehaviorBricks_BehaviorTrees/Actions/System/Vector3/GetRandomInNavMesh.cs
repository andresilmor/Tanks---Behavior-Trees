using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to obtain a random position of an area.
    /// </summary>
    [Action("Vector3/GetRandomInNavMesh")]
    [Help("Gets a random position from a given navmesh")]
    public class GetRandomInNavMesh : GOAction
    {
        /// <summary>The Name property represents the GameObject Input Parameter that must have a BoxCollider or SphereColider.</summary>
        /// <value>The Name property gets/sets the value of the GameObject field, area.</value>
        [InParam("radius")]
        [Help("GameObject that must have inside sphere from which the position is extracted")]
        public float radius;

        /// <summary>The Name property represents the GameObject Input Parameter that must have a BoxCollider or SphereColider.</summary>
        /// <value>The Name property gets/sets the value of the GameObject field, area.</value>
        [InParam("tankPosition")]
        [Help("GameObject that must have inside sphere from which the position is extracted")]
        public Transform tankPosition;


        /// <summary>The Name property represents the Output Position randomly parameter taken from the area Parameter.</summary>
        /// <value>The Name property gets/sets the value of the Vector3 field, randomPosition.</value>
        [OutParam("randomPosition")]
        [Help("Position randomly taken from the area")]
        public Vector3 randomPosition { get; set; }

        /// <summary>Initialization Method of GetRandomInArea</summary>
        /// <remarks>Verify if there is an area, showing an error if it does not exist.Check that the area is a box or sphere to differentiate the
        /// calculations when obtaining the random position of those areas. Once differentiated, you get the limits of the area to calculate a
        /// random position.</remarks>
        public override void OnStart()
        {
            RandomNavmeshLocation(radius, tankPosition);
        }


        public Vector3 RandomNavmeshLocation(float radius, Transform centerPosition)
        {
            bool flag = true;
            Vector3 finalPosition = Vector3.zero;

            while (flag)
            {
                Vector3 randomDirection = Random.insideUnitSphere * radius;
                randomDirection += centerPosition.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
                {
                    finalPosition = hit.position;
                    flag = false;
                }
            }
            return finalPosition;

        }

        /// <summary>Abort method of GetRandomInArea.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
