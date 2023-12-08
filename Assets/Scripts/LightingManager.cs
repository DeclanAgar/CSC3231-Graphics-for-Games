using UnityEngine;

public class LightingManager : MonoBehaviour
{
    // Directional light references of sun and moon
    [SerializeField]
    private Light sun;
    [SerializeField]
    private Light moon;

    // Enabling editing of timeOfDay in Unity Editor for testing
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private float angleOfLight;

    private void Update()
    {
        timeOfDay += Time.deltaTime;
        timeOfDay %= 24; //Modulus to ensure always between 0-24
        UpdateLighting(timeOfDay / 24f); // Divide by 24 to mimic earth hours
    }

    private void UpdateLighting(float timePercent)
    {
        angleOfLight = timePercent * 360f;

        // Set sun and moon to be opposites of one another
        sun.transform.localRotation = Quaternion.Euler(new Vector3(angleOfLight -90f, 0, 0));
        moon.transform.localRotation = Quaternion.Euler(new Vector3(-angleOfLight + 90f, 0, 0));

        // If night time, fade in fog, else fade out
        if (angleOfLight < 80f || angleOfLight > 270f)
        {
            if (RenderSettings.fogDensity < 0.01f)
            {
                RenderSettings.fogDensity += 0.00005f;
            }
        }
        else
        {
            if (RenderSettings.fogDensity > 0f)
            {
                RenderSettings.fogDensity -= 0.00005f;
            }

        }
    }
}