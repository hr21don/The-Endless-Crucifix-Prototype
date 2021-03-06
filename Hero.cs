using UnityEngine;

public class Hero : MonoBehaviour
{
    //public variables
    public float health;
    public float points;
    public float pointsgiven;
    public GameObject player;
    public float waitTime;

    //private variables 
    private float currentTime;
    private bool shot;

    //calling the PlayerMovement Script
    public PlayerMovement PlayerMovement;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        if (currentTime == 0)
        {

            Shoot();
        }
        if (shot && currentTime < waitTime)
        {
            currentTime += 1 * Time.deltaTime;
        }
        if (currentTime >= waitTime)
        {
            currentTime = 0;
        }

    }

    // Die Function
    private void Die()
    {
        print("ShyBandit" + gameObject.name + "Has died!");
        Destroy(gameObject);
        player.GetComponent<PlayerMovement>().points += pointsgiven;
    }

    //Shoot function
    private void Shoot()
    {
        shot = true;
    }

}
