using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public HookShot grappleCheck;

    // Update is called once per frame
    void Start(){
    }
    
    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "hookable"){
            Debug.Log("I've been hooked 0");
            grappleCheck.hooked = true;
            grappleCheck.hookedObj = other.gameObject;
            
        }
    }
}
