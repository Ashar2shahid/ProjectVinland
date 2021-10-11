using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletDecal;

    private float speed =100.0f;
    private float timeToDestroy = 5f;

    public Vector3 target { get ; set;}
    public bool hit { get ; set;}
    // Start is called before the first frame update
    private void OnEnable() {
        Destroy(gameObject , timeToDestroy );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , target , speed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position , target ) < .01f ){
            Destroy(gameObject);
        }        
    }
    private void OnCollisionEnter(Collision other) {
        ContactPoint contact =  other.GetContact(0);
        GameObject.Instantiate( bulletDecal , contact.point , Quaternion.LookRotation(contact.normal) );
        Destroy(gameObject);    
    }
}
