/*using UI class*/
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public variables
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //setmaxhealth function 
    public void setmaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // sethealth function 
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
