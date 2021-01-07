using UnityEngine;

public class PhysicsBallSystem : MonoBehaviour
{
    public Rigidbody[] balls;

    public Rigidbody kart;

    void Start()
    {
        foreach (Rigidbody rb in balls)
            rb.isKinematic = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == kart)
            foreach (Rigidbody rb in balls)
                rb.isKinematic = false;
    }
}
