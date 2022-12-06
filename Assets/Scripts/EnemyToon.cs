using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyToon : MonoBehaviour
{
     [SerializeField] private PlayerScore playerScore;
    [SerializeField] private Animator animator;
    private NavMeshAgent meshAgent;
    private int number;
    private int numberspot;
    [SerializeField]
    private int damage;
    [SerializeField] private float agentSuperSpeed;
    [SerializeField] GameObject[] patrolPoints;
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] 
    private GameObject player;
    [SerializeField] 
    private GameObject [] playSpots;
    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        numberspot = 0;

        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // we make the position of the agent in point 0
        meshAgent.destination = patrolPoints[number].transform.position;
        animator.SetBool("isWalk",true);
        agentSuperSpeed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        float dregonDistance = Vector3.Distance(player.transform.position, this.transform.position);
        if (dregonDistance<=25)
        {
            meshAgent.SetDestination(player.transform.position);
            animator.SetBool("isWalk",false);
            animator.SetBool("isRun",true);
        }

        if (dregonDistance < 2f)
        {
            meshAgent.transform.LookAt(player.transform.position);
            nextspots();
            animator.SetBool("isAttack", true);
        } if (!playerController.isMove())
        {
            meshAgent.isStopped = true;
        } else
         {
            animator.SetBool("isAttack", false);
        
            meshAgent.isStopped = false;   
         }
         if (!meshAgent.pathPending && meshAgent.remainingDistance<1)  {
            nextpoint();
            meshAgent.speed = 5;
            animator.SetBool("isWalk",true);
            animator.SetBool("isAttack", false);
         }
    }

    public void nextpoint()
    {
        meshAgent.destination = patrolPoints[number].transform.position;
        number = (number + 1) % patrolPoints.Length;
    }
    
    public void nextspots()
    {
        /*for (int i = 0; i < playSpots.Length; i++)
        {
            meshAgent.SetDestination(playSpots[i].transform.position);
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk", true);
            Debug.Log(i);
        }*/
        meshAgent.destination = playSpots[numberspot].transform.position;
        animator.SetTrigger("Attack");
        animator.SetBool("isRun",false);
        animator.SetBool("isRun",false);
        numberspot = (numberspot + 1) % playSpots.Length;
        Debug.Log(numberspot);
    }

    

    public void run()
    {
        meshAgent.speed = agentSuperSpeed;

    }

    
}
