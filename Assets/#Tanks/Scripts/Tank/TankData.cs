using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankData : MonoBehaviour {

    public float fuel = 100f;
    public float healthy;
    public int bulletsCapacity;
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.

    //Combustível
    [SerializeField] float depositDurationSeconds = 60f;
    float consumePerTime;
    NavMeshAgent navMeshAgent;
    bool depositEmpty = false;
    float timer = 0;

    [SerializeField] ParticleSystem leftDustTrail;
    [SerializeField] ParticleSystem rightDustTrail;

    float fuelValue;
    float healthyValue;
    [SerializeField] int bulletValue;

    private bool ragnarockStarted = false;

    // Use this for initialization
    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        fuelValue = fuel;
        healthyValue = healthy;
        bulletValue = bulletsCapacity;
        if(gameObject.name.Contains("TankGold")) {
            GameController.AddTankGold();

        }
        consumePerTime = fuelValue / depositDurationSeconds;

    }

    public void StartRagnarok() {
        ragnarockStarted = true;
        gameObject.tag = "Tank";

    }

    public bool RagnarockStarted() {
        return ragnarockStarted;

    }


    //Consumir Combustivel
    private void ConsumeFuel()
    {
        if (!depositEmpty)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                fuel -= consumePerTime;
                timer = 0;
                if (fuel <= 0)
                    depositEmpty = true;

            }

        }
        if (fuel <= 0)
        {
            depositEmpty = true;
            navMeshAgent.isStopped = true;

        }

    }

    void Update () {
        if (navMeshAgent && !navMeshAgent.isStopped) {
            ConsumeFuel();
            ControlDustTrail(true);

        } else if (navMeshAgent.isStopped) {
            ControlDustTrail(false);

        }
        if (fuel <= 0) fuel = 0;
        if (healthy <= 0) healthy = 0;

	}

    private void ControlDustTrail(bool value) {
        if (leftDustTrail && rightDustTrail) {
            leftDustTrail.gameObject.SetActive(value);
            rightDustTrail.gameObject.SetActive(value);

        }
            
    }

    public void FillTheTankFuel()
    {
        fuel = fuelValue;

    }

    public void RestoreHealthy()
    {
        healthy = healthyValue;

    }

    public void RechargeWeapon()
    {
        bulletValue = bulletsCapacity;
        // Change the clip to the charging clip and start it playing.
        m_ShootingAudio.clip = m_ChargingClip;
        m_ShootingAudio.Play();

    }

    public void BulletFired()
    {
        if (bulletValue > 0) bulletValue--;
        else return;
        
        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
       
    }

    public bool IsRunOutOfbullets()
    {
        if (bulletValue > 0) return false;
        else return true;
    }

    public void TakeDamage(float damage)
    {
        healthy -= damage;
        if (healthy < 0) healthy = 0;
    }

    public bool IsDead()
    {
        if (healthy <= 0) return true;
        else return false;
    }


    public float GetMaxFuel() {
        return fuelValue;

    }

    public float GetActualFuel() {
        return fuel;

    }

    public int GetActualBullets() {
        return bulletValue;

    }

    public void AddFuel(float value) {
        fuel += value;

    }

}
