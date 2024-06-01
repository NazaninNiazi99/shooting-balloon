using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 20f;
    private float creationTime;
    public float lifetime = 5f; // Lifetime of the bullet in seconds


    void Start()
    {
        creationTime = Time.time; // Set the creation time when the bullet is instantiated
    }

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        if (Time.time - creationTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }
}