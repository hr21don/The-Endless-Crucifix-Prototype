using UnityEngine;

public class BlendTree : MonoBehaviour
{

    public float smoothBlend = 0.1f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move(float x, float y)
    {
        anim.SetFloat("Blend", y, smoothBlend, Time.deltaTime);
    }
}
