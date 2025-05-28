using UnityEngine;
using UnityEngine.AI;

public enum MonsterAIState
{
    Patrol,
    Chase,
}

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 5f;
    public float repathRate = 1.0f;
    public float patrolRange = 10f;
    public float patrolWaitTime = 2f;
    
    private NavMeshAgent agent;
    private bool isWaiting = false;
    
    private MonsterAIState currentState = MonsterAIState.Patrol;
    private float repathTimer;
    private float currentPatrolWaitTimer = 0f;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);

        switch (currentState)
        {
            case MonsterAIState.Patrol:
                MonsterPatrol(distance);
                break;
            case MonsterAIState.Chase:
                MonsterChase(distance);
                break;
        }
    }

    void MonsterPatrol(float _distanceToPlayer)
    {
        if (_distanceToPlayer < chaseRange)
        {
            currentState = MonsterAIState.Chase;
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= _distanceToPlayer)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                currentPatrolWaitTimer= patrolWaitTime;
            }
            
            currentPatrolWaitTimer-= Time.deltaTime;

            if (currentPatrolWaitTimer <= 0f)
            {
                isWaiting=false;
                UpdateNewPatrolDistance();
            }
        }
    }

    void MonsterChase(float _distanceToPlayer)
    {
        if (_distanceToPlayer > chaseRange)
        {
            agent.ResetPath();
            currentState = MonsterAIState.Patrol;
            UpdateNewPatrolDistance();
            return;
        }

        repathRate -= Time.deltaTime;

        if (repathRate <= 0f)
        {
            agent.SetDestination(player.position);
            repathTimer = repathRate;
        }

    }

    void UpdateNewPatrolDistance()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += transform.position;
        
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    
    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
    }
    #endif
}
