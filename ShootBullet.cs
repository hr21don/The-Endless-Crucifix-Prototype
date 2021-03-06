using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //public variables 
    public float speed;
    public float maxDistance;
    public float damage;
    public GameObject triggeringHero;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 20)
        {
            Destroy(gameObject);
        }
    }
    //collision method
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            ;
        }

        {
            triggeringHero = other.gameObject;
            triggeringHero.GetComponent<Hero>().health -= damage;

        }
    }


}
