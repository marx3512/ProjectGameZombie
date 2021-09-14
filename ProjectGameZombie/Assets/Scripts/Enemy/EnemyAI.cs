using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    private Vector3 walkPoint;
    private bool walkPointSet;
    [SerializeField] private float walkPointRange;

    //States
    [SerializeField] private float sightRange;
    private bool playerInSightRange;

    private void Update() {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if(!playerInSightRange) Patrolling();
        else ChasePlayer();
    }

    void Patrolling(){
        if( !walkPointSet) SearchWalkPoint();
        else if(walkPointSet) navMeshAgent.SetDestination(walkPoint);

        if(Vector3.Distance(transform.position, walkPoint) < 5f) walkPointSet = false;
    }

    void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, 
        transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    void ChasePlayer(){
        navMeshAgent.SetDestination(targetPlayer.position);
    }
    
}
