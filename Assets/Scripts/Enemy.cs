using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3[] PatrolPoints;
    private CircleCollider2D circleCollider;
    private GameObject player;
    private RaycastHit2D hit;
    private float speed = 1f;
    private bool isPatroling = true;
    private bool isMoving = true;
    private bool isClockWise = true;
    private int layerMask = 8;
    private int countPoint = 0;
    private int maxPoint = 0;
    private Vector3 directionToDestination;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        PatrolPoints[PatrolPoints.Length - 1] = transform.position;
        maxPoint = PatrolPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
        Vector3 directionToPlayer = player.transform.position - transform.position;
        hit = Physics2D.Raycast(this.transform.position, directionToPlayer, distanceToTarget);
        Debug.DrawRay(transform.position, directionToPlayer, Color.yellow);

        if (isMoving == true)
            transform.Translate(directionToDestination * speed * Time.deltaTime);

        if (isPatroling == true)
        {
            speed = 1f;
            if (PatrolPoints.Length != 0)
            {
                if (Vector3.Distance(transform.position, PatrolPoints[countPoint]) < 0.25f)
                    countPoint++;
                if (countPoint >= maxPoint)
                    countPoint = 0;
                directionToDestination = PatrolPoints[countPoint] - transform.position;
            }
        }

        if (hit.rigidbody != null)
        {
            if (hit.rigidbody.gameObject.tag == "Player")
            {
                isPatroling = false;
                directionToDestination = player.transform.position - transform.position;
            }
            else
                isPatroling = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(PatrolPoints[countPoint], 0.2f);
    }
}
