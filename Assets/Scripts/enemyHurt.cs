using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHurt : MonoBehaviour
{
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] public int enemyTakeDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Object that collided with me: " + other.gameObject.name);
        //Debug.Log("enemy collision position: " + other.collider.transform.position);
        //Debug.Log("Player position: " + transform.position);
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            if (playerController.attacking)
            {
                Debug.Log(playerController.attacking);
                other.gameObject.GetComponent<EnemyDamage>().enemyTakeDamage(enemyTakeDamage);
            }

        }
    }
}