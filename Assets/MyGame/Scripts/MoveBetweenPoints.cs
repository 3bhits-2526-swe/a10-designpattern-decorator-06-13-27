using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour, IMover
{
    [Header("Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.05f;

    private Transform currentTarget;

    private void Start()
    {
        currentTarget = pointB;
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, currentTarget.position) <= reachDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}