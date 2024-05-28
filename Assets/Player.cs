using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float mouseSensitivity = 2.0f;
    private float xRotation = 0.0f;

    public GameObject bulletPrefab; // The bullet prefab to shoot
    public Transform firePoint; // The point from which the bullets will be fired
    public float bulletForce = 20f; // The force applied to the bullets

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);

        //Note: You will have to attach (link) the main camera to character
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Instantiate a bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // // Get the rigidbody of the bullet
        // Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // // Apply force to the bullet
        // rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
