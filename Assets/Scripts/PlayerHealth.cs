using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour

{   [SerializeField] 
    private PlayerScore playerScore;
    [SerializeField] private int maxHeath;
    [SerializeField] private Gameover gameover;
    private int currentHeath;
    public PlayerController playerController;
    public EnemyToon EnemyToon;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
    }

    
    
    
    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        
        Debug.Log("player1");
       
        if (currentHeath>= 0)
        {
            playerScore.lifeManger();
            Debug.Log("player!");


        }
        else
        {
            gameover.gameOverPage();
            EnemyToon.GetComponent<EnemyToon>().enabled = false;
            playerController.GetComponent<PlayerController>().enabled = false;
        }
    }

}
