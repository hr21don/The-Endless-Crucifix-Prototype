using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    private void Awake()
    {

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //  AimTowardMouse();
        /*
                // Reading the Input
                float horizontal = Input.GetAxis("Horizontal");
                   float vertical = Input.GetAxis("Vertical");

                   Vector3 movement = new Vector3(horizontal, 0f, vertical);

                   // Moving
                   if (movement.magnitude > 0)
                   {
                       movement.Normalize();
                       movement *= _speed * Time.deltaTime;
                       transform.Translate(movement, Space.World);
                   }

                   // Animating
                   float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
                   float velocityX = Vector3.Dot(movement.normalized, transform.right);

                   _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
                   _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);*/
        _animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        _animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

    }

    /* void AimTowardMouse()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out var hitI, Mathf.Infinity, layerMask))
         {
             var direction = hitI.point - transform.position;
             direction.y = 0f;
             direction.Normalize();
             transform.forward = direction;

         }
     }*/
}

