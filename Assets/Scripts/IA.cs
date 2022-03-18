using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    public Transform[] destinationPoints;
    public int  destinationIndex = 0;
    
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < 7)
        {
            agent.destination = target.position;
        }
        else
        {
           
            agent.destination = destinationPoints[destinationIndex].position;

            if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) < 0.5f)
            {
                if(destinationIndex < destinationPoints.Length -1)
                {
                    destinationIndex++;
                }
                else
                {
                    destinationIndex = 0;
                }
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Target")
        {
            Debug.Log("Attack!");
        }
    }
}