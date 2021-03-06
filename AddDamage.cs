/*Using UI class*/
using UnityEngine;

public class AddDamage : MonoBehaviour
{
    //public variables 
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {

        currentHealth = maxHealth;
        healthBar.setmaxhealth(maxHealth);

    }
    //update method
    private void Update()
    {
        //  damage(1);
    }

    //damage method
    private void damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }

}
