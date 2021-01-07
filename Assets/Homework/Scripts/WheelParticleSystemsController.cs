using System.Collections;
using UnityEngine;

public class WheelParticleSystemsController : MonoBehaviour
{
    public ParticleSystem[] particleSystems;

    public float playTime = 5;

    void Start()
    {
        foreach (ParticleSystem ps in particleSystems)
            ps.Stop();
    }

    void Update()
    {
        
    }

    public void TurnOnWheelParticleSystems()
    {
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Play();

            StartCoroutine("TurnOffWheelParticleSystems");
        }
    }

    private IEnumerator TurnOffWheelParticleSystems()
    {
        yield return new WaitForSeconds(playTime);

        foreach (ParticleSystem ps in particleSystems)
            ps.Stop();
    }
}
