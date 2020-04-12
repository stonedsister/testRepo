using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charLerpTest : MonoBehaviour, IItem
{
    private Transform emitter;
    private LineRenderer lr;
    Vector3 startPoint, endPoint;
    public Transform player;
    float grappleSpeed = .5f;
    bool grappleStop;
    int grappleLayer;
    
    void Start()
    {
        emitter = this.transform.GetChild(0);
        lr = this.GetComponent<LineRenderer>();
        grappleLayer = LayerMask.GetMask("Grapplable");
    }

    public void Use(){
        RaycastHit hit;
        if(Physics.Raycast(emitter.position, emitter.forward, out hit, 100f, grappleLayer)){
            Debug.DrawRay(emitter.position, emitter.forward * hit.distance, Color.green, 1f);
            lr.SetPosition(0, emitter.position);
            lr.SetPosition(1, hit.point);
            endPoint = hit.point - emitter.forward;
            StartCoroutine(MoveGrapple());
        }
        else{
            Debug.DrawRay(emitter.position, emitter.forward * 5, Color.red, 1f);
        }
    }

    public void AltUse(){
        StartCoroutine(MoveGrapple());
    }

    public void Pickup(Transform hand){
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.SetParent(hand);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
    }

    IEnumerator MoveGrapple(){
        startPoint = player.position;
        float grappleDistance = Vector3.Distance(startPoint, endPoint);
        float grappleStep = grappleDistance / grappleSpeed;

        for(int i = 0; i < grappleStep; i++){
            if(grappleStop == false){
                player.position = Vector3.Lerp(startPoint, endPoint, i / grappleStep);
                yield return null;
            }
            else{
                i = Mathf.CeilToInt(grappleStep);
            }
        }
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.zero);
    }
}