using UnityEngine;

public class KartLightControllor : MonoBehaviour
{
    public Rigidbody kart;

    public Light light;

    public float minIntensity = 1.5f;

    public float maxIntensity = 6;

    void Start()
    {
        light.intensity = minIntensity;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == kart)
        {
            if (light.intensity > minIntensity)
                light.intensity = minIntensity;
            else
                light.intensity = maxIntensity;
        }
    }
}
