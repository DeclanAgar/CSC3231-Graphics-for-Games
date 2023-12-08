using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem rain;
    [SerializeField]
    private ParticleSystem snow;

    [SerializeField]
    private Vector3 offset;

    private float yRotation;
    private float yOffset;

    private void Start()
    {
        yOffset = 180;

        rain.Stop();
        snow.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // If above 250 and below 450 on the y axis, play rain
        if (transform.position.y > 250 && transform.position.y < 450)
        {
            rain.Play();
            rain.gameObject.transform.position = transform.position + offset;
            yRotation = transform.rotation.eulerAngles.y;
            rain.transform.eulerAngles = new Vector3(0, yRotation - yOffset, 0);

            snow.Stop();

        // If above 450 on y axis, play snow
        } else if (transform.position.y >= 450) {
            rain.Stop();
            snow.Play();
            snow.gameObject.transform.position = transform.position + offset;
            yRotation = transform.rotation.eulerAngles.y;
            snow.transform.eulerAngles = new Vector3(0, yRotation - yOffset, 0);
        }
        else
        {
            rain.Stop();
            snow.Stop();
        }
        
    }
}
