using UnityEngine;

/// <summary>
/// Component used to destroy itself, in this case for the bullets.
/// </summary>
public class BulletScript : MonoBehaviour
{

    // Use this for initialization
    /// <summary>
    /// Initialize the component to be destroy the GameObject in 2 seconds.
    /// </summary>
    void Start()
	{

		Destroy(gameObject, 2);
	} // Start


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tank")
        {
            Debug.Log("Aqui!"); //Nao é chamado -_-
            TankData td = collision.gameObject.GetComponent<TankData>();

            td.TakeDamage(30);
        }
    }
}