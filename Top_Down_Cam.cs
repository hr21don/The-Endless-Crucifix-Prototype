using UnityEngine;
namespace IndiePixel.Cameras
{
    public class Top_Down_Cam : MonoBehaviour
    {
        public Transform m_Target;
        public float m_height = 10f;
        public float m_distance = 20f;
        public float m_angle = 40f;
        public float m_SmoothSpeed = 0.5f;
        private Vector3 refvelocity;

        // Start is called before the first frame update
        private void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        private void Update()
        {
            HandleCamera();
        }
        protected virtual void HandleCamera()
        {
            if (!m_Target)
            {
                return;
            }
            Vector3 worldPosition = (Vector3.forward * -m_distance) + (Vector3.up * m_height);
            Vector3 rotatedvector = Quaternion.AngleAxis(m_angle, Vector3.up) * worldPosition;
            Vector3 flatTargetPosition = m_Target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalposition = flatTargetPosition + rotatedvector;
            transform.position = Vector3.SmoothDamp(transform.position, finalposition, ref refvelocity, m_SmoothSpeed);
            transform.LookAt(flatTargetPosition);

        }

    }
}
