using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    public float MaxRotationSpeed = 10.0f;
    public float MinRotationSpeed = 5.0f;

    public float MaxSpeed = 10.0f;
    public float MinSpeed = 5.0f;

    private Vector3 MoveVector;
    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(MinRotationSpeed, MaxRotationSpeed) * (Random.value > 0.5f ? 1 : -1);
        float speed = Random.Range(MinSpeed, MaxSpeed);
        MoveVector = Random.insideUnitSphere * speed;
        MoveVector.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.position += MoveVector * Time.deltaTime;
    }
}
