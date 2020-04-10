using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public Rigidbody hookRB;
    public Rigidbody playerRB;

    public GameObject holster;
    public GameObject hookStartPos;
    public GameObject hook;
    public GameObject player;

    public bool shot;
    public bool hooked;

    public float hookTravelSpeed;
    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        hooked = false;
        Debug.Log("I have started");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && shot == false){
            shot = true;
            Debug.Log("Shoot");
        }
        if(shot){
            FireHook();
        }

        if(hooked){
            player.transform.position = Vector3.MoveTowards(player.transform.position, hook.transform.position, hookTravelSpeed);
        }
    }

    void FireHook(){
        RaycastHit hit;
        if(Physics.Raycast(hookStartPos.transform.position, transform.TransformDirection(Vector3.forward), out hit)){
            hook.transform.position = hit.point;
            hooked = true;
            shot = false;
        }
    }
}
