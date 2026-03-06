using UnityEngine;

public class PulseDecorator : MonoBehaviour
{
    [Header("Pulse Settings")]
    [SerializeField] private Vector3 pulseAmount = new Vector3(0.2f, 0.2f, 0.2f); 
    [SerializeField] private float pulseSpeed = 2f;

    private IMover _wrappedMover;
    private Vector3 _initialScale;
    private float _pulseTime;

    private void Start()
    {
        _wrappedMover = GetComponent<IMover>();

        if (_wrappedMover == null)
            Debug.LogError("PulseDecorator requires a component implementing IMover on the same GameObject.");

        _initialScale = transform.localScale;
    }

    private void Update()
    {
        _wrappedMover?.Move();
        PulseObject();
    }

    private void PulseObject()
    {
        _pulseTime += Time.deltaTime * pulseSpeed;

        
        float scaleFactor = Mathf.Sin(_pulseTime) * 0.5f + 0.5f; 
        Vector3 scaleOffset = Vector3.Scale(pulseAmount, new Vector3(scaleFactor, scaleFactor, scaleFactor));

        transform.localScale = _initialScale + scaleOffset;
    }
}
