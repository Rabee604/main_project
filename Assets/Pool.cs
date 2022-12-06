using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instsnce;
    private List<GameObject> poolObjects = new List<GameObject>();
    private int amount = 5;
    [SerializeField] 
    private GameObject FootmanPolyartVariant; 

    public void Awake()
    {
        if (instsnce == null)
        {
            instsnce = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject gameObject = Instantiate(FootmanPolyartVariant);
            gameObject.SetActive(false);
            poolObjects.Add(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooleObj()
    {  
        for (int i = 0; i <poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
