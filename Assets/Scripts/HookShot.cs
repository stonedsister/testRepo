using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookShot : MonoBehaviour, IItem
{
    public float maxTravelDistance = 50;
    public float currentTravelDistance;
    public float hookTravelSpeed;
    public float playerTravelSpeed = 30f;

    public bool hooked;
    public bool shot;

    public GameObject holster;
    public GameObject hook;
    public GameObject hookStartPos;
    public GameObject player;
    public GameObject hookedObj;
    public GameObject firstPersonCharacter;
    public Rigidbody babyplayerRB;
    
    public Rigidbody hookRB;
    public Rigidbody playerRB;

    public Vector3 hookStartingSize;

    public Transform playerStartPos;

    void Start()
    {
        shot = false;
        hooked = false;
        Debug.Log($"hook parent = {hook.transform.parent}");
        playerStartPos = player.transform;
        hookStartingSize = hook.transform.localScale;
        // Use();
        // AltUse();
    }

    public void Use(){
        Debug.Log("Use()");

        if(Input.GetMouseButtonDown(0) && shot == false){
            shot = true;
        }

        if(shot){
            FireHook();

            /*
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentTravelDistance = Vector3.Distance(this.transform.position, hook.transform.position);
            */
            if(currentTravelDistance >= maxTravelDistance){
                ReturnHook();
            }
        }

        if(hooked){
            hook.transform.parent = hookedObj.transform;
            
            //player.transform.position = Vector3.MoveTowards(player.transform.position, hook.transform.position, playerTravelSpeed);
            player.GetComponent<Rigidbody>().useGravity = false;
            player.transform.Translate(hook.transform.position);
            player.transform.position = hook.transform.position;
            //player.transform.position = playerStartPos.position;
            
            Debug.Log($"Gravity = {player.GetComponent<Rigidbody>().useGravity}");
            hook.transform.parent = firstPersonCharacter.transform;
            ReturnHook();
            hook.transform.localScale = hookStartingSize;
        }

    }

    public void AltUse(){
        Debug.Log("AltUse()");
    }

    public void Pickup(Transform hand){

    }

    public void Drop(){
    
    }

    void FireHook(){
        RaycastHit hit;
            if(Physics.Raycast(hookStartPos.transform.position, transform.TransformDirection(Vector3.forward), out hit)){
                hook.transform.position = hit.point;
            }
            shot = false;
    }

    void ReturnHook(){
        hook.transform.position = hookStartPos.transform.position;
        shot = false;
        hooked = false;
    }

    void OnTriggerEnter(Collider other){
        babyplayerRB.isKinematic = true;
    }

    

    /*public void OnTriggerEnter(Collider other){
        Debug.Log("OnTrigger");
        if(other.gameObject.CompareTag("restart")){
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(other.gameObject.CompareTag("a")){
            Debug.Log("I hit a wall");
        }
    }
    
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("a")){
            Debug.Log("I hit a wall");
        }
    }*/


}
