using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public bool isNight = false;
    public int playTime = 0;
    public int unitTime = 1;
    public int afternoonTimeLimit = 100;
    public int nightTimeLimit = 200;
    List<Action> afternoonHandlers = new List<Action>();
    List<Action> nightHandlers = new List<Action>();

    private void Start()
    {
        this.handleAtAfternoon();
        StartCoroutine(increasePlayTime());
    }

    IEnumerator increasePlayTime()
    {
        while (true)
        {
            this.playTime += 1;
            if (this.playTime % this.nightTimeLimit <= this.afternoonTimeLimit)
            {
                if (this.isNight)
                {
                    this.handleAtAfternoon();
                    this.isNight = false;
                }
            }
            else
            {
                if (!this.isNight)
                {
                    this.handleAtNight();
                    this.isNight = true;
                }
            }
            yield return new WaitForSecondsRealtime(this.unitTime);
        }
    }

    private void handleAtNight()
    {
        foreach (Action handler in nightHandlers)
        {
            handler.Invoke();
        }
    }

    private void handleAtAfternoon()
    {
        foreach (Action handler in afternoonHandlers)
        {
            handler.Invoke();
        }
    }

    public void registrationNightHandler(Action handler)
    {
        this.nightHandlers.Add(handler);
    }

    public void registrationAfternoonHandler(Action handler)
    {
        this.afternoonHandlers.Add(handler);
    }
}
