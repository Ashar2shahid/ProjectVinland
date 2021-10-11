using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject barrel;
    public Transform bulletParent;
    private Transform cameraTransform;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactFlash;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(){
        RaycastHit hit ;
        GameObject bullet = GameObject.Instantiate(bulletPrefab , barrel.transform.position , Quaternion.identity , bulletParent.transform );
        Debug.Log("shooting");
        muzzleFlash.Play();
        GetComponentInChildren<AudioSource>().Play();
        BulletController bulletController = bullet.GetComponent<BulletController>();
            if(Physics.Raycast(cameraTransform.position , cameraTransform.forward , out hit ,Mathf.Infinity)){
                bulletController.target = hit.point;
                ParticleSystem impactflash = GameObject.Instantiate(impactFlash, hit.point , Quaternion.FromToRotation(-hit.normal , hit.normal ));
                // impactFlash.transform.forward = hit.normal;
                impactFlash.Play();
                
                // bulletController.hit =true ;
            }
            else{
                bulletController.target = cameraTransform.position + cameraTransform.forward *1000.0f;
                // bulletController.hit =true ;
            }
     }
}
