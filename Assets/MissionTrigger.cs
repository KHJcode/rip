using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    private bool isInMissionArea = false;

    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInMissionArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInMissionArea = false;
        }
    }

    private void Update()
{
    if (isInMissionArea)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FishingGame fishingGame = player.GetComponent<FishingGame>();
            if (fishingGame != null)
            {
                fishingGame.StartGame();
            }
        }
    }
}


    private void OnGUI()
    {
        if (isInMissionArea)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 20), "F키를 눌러 미션을 수행하세요");
        }
    }
}