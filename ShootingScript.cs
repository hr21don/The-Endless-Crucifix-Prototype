using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //public variable 
    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    private Transform bulletSpawned;

    // Update is called once per frame
    private void Update()
    {
        Shoot();

    }

    //shoot method
    private void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;

    }

    //collision method 
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);


    }
}
