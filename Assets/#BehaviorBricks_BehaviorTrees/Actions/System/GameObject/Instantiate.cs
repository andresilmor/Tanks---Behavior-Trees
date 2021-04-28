using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    ///It is an action to clone a GameObject.
    /// </summary>
    [Action("GameObject/Instantiate")]
    [Help("Clones the object original and returns the clone")]
    public class Instantiate : GOAction
    {

        ///<value>Input Object to be cloned Parameter.</value>
        [InParam("original")]
        [Help("Object to be cloned")]
        public GameObject original;

        [InParam("useWaypointPosition")]
        [Help("Check if its used a gameObject to provide position")]
        public bool isUsedWaypointAsSpawn;

        ///<value>Input position for the clone Parameter.</value>
        [InParam("position")]
        [Help("position for the clone")]
        public Vector3 spawnPosition;

        [InParam("waypointPosition")]
        [Help("Waypoint position for the clone")]
        public GameObject spawnWaypoint;

        [InParam("minSpawns")]
        [Help("Waypoint position for the clone")]
        public int minSpawns;

        [InParam("maxSpawns")]
        [Help("Waypoint position for the clone")]
        public int maxSpawns;

        ///<value>OutPut instantiated game object Parameter.</value>
        [OutParam("instantiated")]
        [Help("Returned game object")]
        public GameObject instantiated;


        /// <summary>Initialization Method of Instantiate.</summary>
        /// <remarks>Installed a GameObject in the position and type dice.</remarks>
        public override void OnStart()
        {
            if(!original)
                original = gameObject;

            if (isUsedWaypointAsSpawn && spawnWaypoint)
            {
                spawnPosition = spawnWaypoint.transform.position;

            } else if (isUsedWaypointAsSpawn && !spawnWaypoint) {
                spawnPosition = original.transform.position;
            }


            //Foi adicionado o TankGoldTeam como parente apenas para a Hierarquia ficar mais limpa
            for(int count = 1; count <= Random.Range(minSpawns, maxSpawns + 1); count++) {
                original = GameObject.Instantiate(original, spawnPosition, original.transform.rotation, GameObject.Find("TankPopulation").transform) as GameObject;
            }
                
        }

        /// <summary>Method of Update of Instantiate.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
