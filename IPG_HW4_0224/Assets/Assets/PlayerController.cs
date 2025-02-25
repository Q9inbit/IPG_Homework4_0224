using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 5f;

    void Start()
    {
        agent.speed = moveSpeed;
    }

    void Update()
    {
        HandleMovement();
        UpdateAnimation();
    }

    void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        agent.speed = moveSpeed;
    }

    void UpdateAnimation()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
