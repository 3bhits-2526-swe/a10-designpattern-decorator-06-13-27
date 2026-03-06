using UnityEngine;

public class RotateDecorator : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 0f, 90f);

    private IMover _wrappedMover;

    private void Start()
    {
        _wrappedMover = GetComponent<IMover>();

        if (_wrappedMover == null)
            Debug.LogError("RotateDecorator requires a component implementing IMover on the same GameObject.");
    }

    private void Update()
    {
        _wrappedMover?.Move();
        RotateObject();
    }

    private void RotateObject()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}