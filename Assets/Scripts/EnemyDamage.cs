using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    private int currentamount;
    [SerializeField] 
    private PlayerScore playerScore;
    [SerializeField]
    public int enemyDamage;
    [SerializeField] private int enemyMaxHeath;

    [SerializeField] private int amount;
    // Start is called before the first frame update
    void Start()
    {
        enemyDamage = enemyMaxHeath;
        currentamount =1;
        amount = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemyTakeDamage(int damage)
    {
        enemyDamage -= damage;
        currentamount++;
        
        Debug.Log("!");
       
        if (enemyDamage >= 0)
        {
            playerScore.scoreManger();
            Debug.Log("2");


        }
        else
        {


            //Destroy(gameObject);
            
                playerScore.scoreManger();
                gameObject.SetActive(false);
            

             GameObject Enemy = Pool.instsnce.GetPooleObj(); 
             if (Enemy != null && currentamount<=amount)
            {
                Debug.Log(currentamount);
                Enemy.transform.position = new Vector3(-325, 71.14f, 28.9f);
                Enemy.SetActive(true);
            }
        }
    }
}
