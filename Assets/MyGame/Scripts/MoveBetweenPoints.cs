using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachDistance = 0.05f;

    [Header("Unschoenes Zusatzverhalten")]
    [SerializeField] private bool changeColorOnBounce = true;

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentTarget = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, currentTarget.position) <= reachDistance)
        {
            if (changeColorOnBounce && spriteRenderer != null)
            {
                spriteRenderer.color = Random.ColorHSV();
            }

            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        ChangeColor();
    }

    private void ChangeColor()
    {
        if (Vector3.Distance(transform.position, currentTarget.position) <= reachDistance)
        {
            if (changeColorOnBounce && spriteRenderer != null)
            {
                spriteRenderer.color = Random.ColorHSV();
            }

            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}