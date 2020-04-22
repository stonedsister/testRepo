using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour{

    //[Tooltip("Add the player here")]
    public Transform goal;
    private NavMeshAgent agent;
    public float followDistance = 10f;
       
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        agent.destination = goal.position;
        float dist = Vector3.Distance(this.transform.position, goal.position);
        if(dist > followDistance){
            agent.destination = goal.position;
        } else{
            agent.destination = this.transform.position;
        }
    }
}