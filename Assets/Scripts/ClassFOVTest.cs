using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassFOVTest : MonoBehaviour
{
    public GameObject player;
    float angle;
    public Transform rayEmitter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookForPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LookForPlayer(){
        while(true){

            
            // angle = Vector3.Angle(this.transform.forward, player.transform.position);
            angle = Vector3.Angle(rayEmitter.transform.forward, player.transform.position);
            RaycastHit hit;
            // Vector3 rayDirection = rayEmitter.transform.position + player.transform.position;
            Vector3 rayDirection = player.transform.position;
            if(angle < 60f){
                
                
                if(Physics.Raycast(rayEmitter.transform.position, rayDirection, out hit, Mathf.Infinity)){
                    
                    if(hit.collider.gameObject.CompareTag("Player")){
                        Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.red, 100f);
                        GetComponent<Renderer>().material.color = Color.red;
                    } else{
                        Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.black, 100f);
                    }
                }else{
                    Debug.Log("A");
                    // if(true){
                        // Debug.Log($"Physics.raycast = {Physics.Raycast(rayEmitter.transform.position, rayDirection, out hit, Mathf.Infinity)}");        
                        // Debug.Log($"Angle = {angle}");
                        Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.magenta, 1100f);
                        GetComponent<Renderer>().material.color = Color.magenta;
                    // } else{
                    //     Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.black, 100f);
                    // }
                    // GetComponent<Renderer>().material.color = Color.cyan;
                    // Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.green, 1f);
                }
            } else{
                Debug.DrawRay(rayEmitter.transform.position, player.transform.position, Color.yellow, 100f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    // raycast from the ai to the player
    // a way to find the angles
    // a reference to the ai
    // a raycast to point forward
    // float angle = Vector3.Angle(targetDir, transform.forward);
}
