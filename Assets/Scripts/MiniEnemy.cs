using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MiniEnemy : MonoBehaviour
{

    private int numberspot;
    [SerializeField] 
    private GameObject [] playSpots;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField]
    private PlayerController playerController;
    private float agentSuperSpeed;
    [SerializeField] private Animator animator;
    private NavMeshAgent miniAgent;
    [SerializeField] 
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        numberspot=0;
        animator = GetComponent<Animator>();
        miniAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalk",true);
        agentSuperSpeed = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        float miniDistance = Vector3.Distance(player.transform.position, this.transform.position);
        if (miniDistance<=25)
        {
            miniAgent.SetDestination(player.transform.position);
            animator.SetBool("isWalk",false);
            animator.SetBool("isRun",true);
            miniAgent.speed=agentSuperSpeed;
        }

        if (miniDistance < 2f)
        {
            miniAgent.transform.LookAt(player.transform.position);
            nextspots();
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk",true);
            /*if (!playerController.isMove())
            {
                miniAgent.isStopped = true;
                animator.SetBool("isStop",true);
                
   
            }*/
        } else
        {
            animator.SetBool("isAttack", false);
            
            //meshAgent.isStopped = false;   
        }
        miniAgent.SetDestination(player.transform.position);
        
    }
    
    public void nextspots()
    {
        miniAgent.destination = playSpots[numberspot].transform.position;
        numberspot = (numberspot + 1) % playSpots.Length;
    }
    }

