using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    class Bullet{
        public float time ;
        public Vector3 initialPosition ;
        public Vector3 initialVelocity ;
        public TrailRenderer trail ;
    }
    
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject barrel;
    public Transform bulletParent;
    private Transform cameraTransform;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactFlash;
    public Transform raycastOrigin ;
    public Transform raycastDest ;
    public TrailRenderer bulletTrail;
    public int fireRate = 15 ;
    Ray ray ;
    RaycastHit hitInfo;
    float accumulatedTime = 0.0f;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;
    List<Bullet> bullets = new List<Bullet>(); 
    float maxLifetime =  3.0f;
    public bool isFiring ;
    // Start is called before the first frame update
    Vector3 GetPosition (Bullet bullet ){
        Vector3 gravity = Vector3.down * bulletDrop ;
        return (bullet.initialPosition) + (bullet.initialVelocity*bullet.time) + (0.5f * gravity * bullet.time * bullet.time) ;
    }
    Bullet CreateBullet(Vector3 position , Vector3 velocity){
        Bullet bullet = new Bullet();
        bullet.initialPosition = position ;
        bullet.initialVelocity = velocity ;
        bullet.time = 0.0f ;
        bullet.trail = Instantiate(bulletTrail, position, Quaternion.identity);
        bullet.trail.AddPosition(ray.origin);
        return bullet ;
    }
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    public void StartFire(){
        isFiring = true ;
        accumulatedTime = 0.0f;
        FireBullet();
    }
    public void UpdateFire(float deltaTime){
        accumulatedTime += deltaTime ;
        float fireInterval = 1.0f / fireRate;
        while(accumulatedTime >= 0.0f ){
            FireBullet();
            accumulatedTime -= fireInterval ;
        }
    }

    public void UpdateBullets(float deltaTime){
        SimulateBullets(deltaTime);
        DestroyBullets();
    }
    void SimulateBullets(float deltaTime){
        bullets.ForEach(bullet =>{
            Vector3 p0 = GetPosition(bullet);
            bullet.time += deltaTime ;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0 , p1 , bullet);
        });
    }
    void DestroyBullets(){
        bullets.RemoveAll(bullet => bullet.time >= maxLifetime );
    }
    void RaycastSegment(Vector3 start , Vector3 end , Bullet bullet ){
        Vector3 direction = end - start ;
        float distance = direction.magnitude ;
        ray.origin = start;
        ray.direction = direction;
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo , distance))
        {
            impactFlash.transform.position = hitInfo.point;
            impactFlash.transform.forward = hitInfo.normal;
            impactFlash.Emit(1);
            
            bullet.trail.transform.position = hitInfo.point;
            bullet.time = maxLifetime ;
            Debug.Log("target hit");
        } else{
            bullet.trail.transform.position = end;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        FireBullet();
    }

    private void FireBullet()
    {   
        Vector3 velocity = (raycastDest.position - raycastOrigin.position).normalized * bulletSpeed ;
        var bullet = CreateBullet(raycastOrigin.position , velocity);
        bullets.Add(bullet);
        // ray.origin = raycastOrigin.position;
        // ray.direction = raycastDest.position - raycastOrigin.position;
        // var trail = Instantiate(bulletTrail, ray.origin, Quaternion.identity);
        // trail.AddPosition(ray.origin);
        // if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        // {
        //     // if(Physics.Raycast(barrel.transform.position , barrel.transform.forward , out hitInfo ,Mathf.Infinity)) {
        //     // Debug.DrawLine( ray.origin , hitInfo.point , Color.red , 20.0f );
        //     impactFlash.transform.position = hitInfo.point;
        //     impactFlash.transform.forward = hitInfo.normal;
        //     impactFlash.Emit(1);
        //     trail.transform.position = hitInfo.point;
        //     Debug.Log("target hit");
        // }
        // RaycastHit hit;
        // // GameObject bullet = GameObject.Instantiate(bulletPrefab , barrel.transform.position , Quaternion.identity , bulletParent.transform );
        // Debug.Log("shooting");
        // muzzleFlash.Play();
        // GetComponentInChildren<AudioSource>().Play();
        // // BulletController bulletController = bullet.GetComponent<BulletController>();
        // //     // if(Physics.Raycast(cameraTransform.position , cameraTransform.forward , out hit ,Mathf.Infinity)){
        // //     if(Physics.Raycast(barrel.transform.position , barrel.transform.forward , out hit ,Mathf.Infinity)){    
        // //         Debug.DrawLine(barrel.transform.position , hit.point , Color.red , 2.0f );
        // //         bulletController.target = hit.point;
        // //         ParticleSystem impactflash = GameObject.Instantiate(impactFlash, hit.point , Quaternion.FromToRotation(-hit.normal , hit.normal ));
        // //         // impactFlash.transform.forward = hit.normal;
        // //         impactFlash.Play();

        // //         // bulletController.hit =true ;
        // //     }
        // //     else{
        // //         bulletController.target = cameraTransform.position + cameraTransform.forward *1000.0f;
        // //         // bulletController.hit =true ;
        // //     }
    }

    public void StopShoot(){
        isFiring = false ;
    }
}
