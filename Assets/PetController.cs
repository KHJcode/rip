using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform player;
    public float initialFollowDistance = 2f;
    public float initialStopDistance = 1f;
    public float distanceIncrement = 1f;
    public float moveSpeed = 3f;
    public LayerMask groundLayer; // 바닥 레이어

    private Animator animator;
    private float followDistance;
    private float stopDistance;
    private int previousPetCount = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        followDistance = initialFollowDistance;
        stopDistance = initialStopDistance;
    }

    private void Update()
    {
        int currentPetCount = GameObject.FindGameObjectsWithTag("Pet").Length;

        if (currentPetCount > previousPetCount)
        {
            IncreaseDistance();
        }

        previousPetCount = currentPetCount;

        // 바닥으로부터 펫의 위치를 가져옴
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        Vector3 targetPosition = player.position + (player.forward * -followDistance);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // y 축 회전 방지

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
            }
        }
    }

    private void IncreaseDistance()
    {
        followDistance += distanceIncrement;
        stopDistance += distanceIncrement;
    }
}
