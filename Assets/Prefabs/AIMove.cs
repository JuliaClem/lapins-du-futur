using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public NavMeshAgent bblapin1;
    public Transform Player;
    private bool isFollowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        if(isFollowing)
            bblapin1.SetDestination(Player.position);
    }
    
    void OnCollisionEnter(Collision other)
  {
      Debug.Log(other.gameObject.name);
      if(other.gameObject.name == "Lapin_parent")
        isFollowing = true;
  }
    
    void OnTriggerEnter(Collider other)
    { 
      if(other.gameObject.tag == "Rabbit Hole")
      Debug.Log("Collision detected");
      gameObject.active = false;
    }
  }

