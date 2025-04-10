using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Room : MonoBehaviour
{
    
    public int Enemy_Count;
    public GameObject FightRoom;
    public bool doorsOpen;
    public bool encounter;
    public GameObject[] doors;
    public GameObject nullCheck;
    
    private void Start()
    {
        encounter = false;
        doorsOpen = true;
        Enemy_Count = 2;
        
        Invoke("open", 240f);

        

        
    }

   

    private void Update()
    {
        
        

        


        if (GameObject.FindGameObjectWithTag("EnemyCount") != null)
        {
            count();
            if (Enemy_Count <= 0)
            {
                open();
            }
        }
        else
        {
            Debug.Log("");
        }
       








        if (doorsOpen == false)
        {
            
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(true);
            }
        }else if (doorsOpen == true)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
            ;
        }


       

        Debug.Log(Enemy_Count);
    }
   

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Encounter();

        }

        if (collision.CompareTag("EnemyCount"))
        {
          
            
        }
       
    }


 

    void Encounter()
    {
        if (encounter == false)
        {
            Instantiate(FightRoom, transform.position, Quaternion.identity);
            
            encounter = true;
            doorsOpen = false;
            



        }
        

        
    }
    void count()
    {
        Enemy_Count = GameObject.FindGameObjectWithTag("EnemyCount").GetComponent<Counter_Enemy>().enemyCount;
    }

    void open()
    {
        doorsOpen = true;
        Destroy(GameObject.FindGameObjectWithTag("EnemyCount"));
    }
    
}
