﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Transform playerPosition;
    public float attackDistance = 5f;
    public float retreatDistance = 8f;
    public float distanceToPlayer;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        Debug.Log($"destPoint = {destPoint}");
        distanceToPlayer = Vector3.Distance(this.transform.position, playerPosition.position);

        if(distanceToPlayer <= attackDistance){
            agent.destination = playerPosition.position;
        } 
        else{
            if(!agent.pathPending && agent.remainingDistance < 0.5f){
                GotoNextPoint();
            }
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        

        
    }
}



/*
if(playerIsClose(6m)){
    MoveToPlayer
}
if(playerIsFar(12m)){
    gotoNextPoint();
}*/