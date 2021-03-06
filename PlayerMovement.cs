/*Using scenemanagement class*/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables     
    public float MovementSpeed;
    public new Transform camera;
    public CharacterController controller;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Hero hero;
    public float points;
    public float deadzone = -10f;
    public Transform playerspawnpoint = null;
    public Animator animator;
    public swipemanager swipecontrols;

    //start function
    private void Start()
    {

        currentHealth = maxHealth;
        healthBar.setmaxhealth(maxHealth);

    }

    // Update is called once per frame
    private void Update()
    {

        animator.SetBool("isgamestarted", true);
        animator.SetBool("isgrounded", true);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (playerPlane.Raycast(ray, out float hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        //    if(swipemanager.swipeUp)
        //     transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        //     Debug.Log(" Test case1 : swipeUp");
        //  if(swipemanager.swipeRight)
        //    transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        //      Debug.Log(" Test case2 : swiperight");
        //   if (swipemanager.swipeLeft)
        //       transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
        //      Debug.Log(" Test case3 : swipeleft");
        //  if (swipemanager.swipeDown)
        //     transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
        //      Debug.Log(" Test case4 : swipeldown");

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            addHealth(10);
        }

        damage(1);
        //      if (currentHealth <= 0)
        //   {
        //        SceneManager.LoadScene("GameOver");
        //     }
        if (transform.position.y < deadzone)
        {
            transform.position = playerspawnpoint.position;
        }
    }

    //damage mechanic
    private void damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

    //health mechanic  
    private void addHealth(int healamount)
    {
        currentHealth += healamount;
        healthBar.SetHealth(currentHealth);

    }

}
