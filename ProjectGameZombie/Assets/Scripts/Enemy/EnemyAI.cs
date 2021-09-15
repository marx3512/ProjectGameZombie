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

    //Wait
    float cont = 0;

    //Field of View
    public FieldView fieldView;

    private void Start() {
        fieldView = GetComponent<FieldView>();
    }

    private void Update() {
        if(!fieldView.canSeeplayer) Patrolling();
        else ChasePlayer();
        
    }

    void Patrolling(){
        if( !walkPointSet) SearchWalkPoint();
        else if(walkPointSet) navMeshAgent.SetDestination(walkPoint);

        if(Vector3.Distance(transform.position, walkPoint) < 2f){
            cont += Time.deltaTime;
            if(cont >= 6){
                walkPointSet = false;
                cont = 0;
            }
        } 
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
