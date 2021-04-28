using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static int tankGoldNum = 0;
    private static int tankCenso = 0;
    private static bool ragnarockStarted = false;


    public static void AddTankGold() {
        tankGoldNum++;
    }

    public static void RemoveTankGold() {
        tankGoldNum--;
        if(tankGoldNum <= 0) {
            StartRagnarock();
        }
    }

    public static void StartRagnarock() {
        TankData[] tankPopulation = GameObject.Find("TankPopulation").GetComponentsInChildren<TankData>();
        tankCenso = tankPopulation.Length;
        ragnarockStarted = true;
        foreach (TankData tank in tankPopulation) {
            tank.StartRagnarok();
        }
    }

    void Update() {
        if(GameController.ragnarockStarted) {
            UpdateCenso();
        }

    }

    public static void UpdateCenso() {
        if (tankCenso != GameObject.Find("TankPopulation").gameObject.transform.childCount) {
            StartRagnarock();
        }
        
    }

    
}
