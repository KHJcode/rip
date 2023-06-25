using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public Environment environment;
    private Light light;

    private void Awake()
    {
        this.environment.registrationAfternoonHandler(this.changeLightToAfternoonVersion);
        this.environment.registrationNightHandler(this.changeLightToNightVersion);
    }

    void Start()
    {
        this.light = GetComponent<Light>();
    }

    private void changeLightToNightVersion()
    {
        this.light.intensity = 0.17f;
        this.light.color = HexToColor("#F0E1FF");
        this.light.shadows = LightShadows.None;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = HexToColor("#403165");
    }

    private void changeLightToAfternoonVersion()
    {
        this.light.intensity = 0.65f;
        this.light.color = HexToColor("#FFF4D6");
        this.light.shadows = LightShadows.Soft;
        this.light.shadowStrength = 1f;
        this.light.shadowBias = 0.05f;
        this.light.shadowNormalBias = 0.4f;
        this.light.shadowNearPlane = 0.1f;
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.backgroundColor = HexToColor("#314D79");
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}
