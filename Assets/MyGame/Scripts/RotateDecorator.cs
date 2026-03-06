using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 0f, 90f); // degrees per second

    void Update()
    {
        RotateObject();
    }

    public void RotateObject()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}