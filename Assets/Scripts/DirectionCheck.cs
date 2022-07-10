using UnityEngine;

namespace Stijn.Sandbox
{
    public class DirectionCheck : MonoBehaviour
    {
        private Vector3 _inputVector;

        private void Update()
        {
            _inputVector.x = Input.GetAxis("Horizontal");
            _inputVector.z = Input.GetAxis("Vertical");
            _inputVector.Normalize();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 0, 0.5f);
            Gizmos.DrawWireSphere(this.transform.position, 1f);

            // Forward of character
            DrawArrow(this.transform.position, this.transform.forward, Color.red);

            // Direction of camera
            Vector3 dc = Camera.main.transform.forward;
            //dc = Vector3.Cross(dc, Vector3.up);
            dc = Vector3.Scale(dc, new Vector3(1, 0, 1)); // We remove the y-value
            dc.Normalize();
            DrawArrow(this.transform.position, dc, Color.blue);

            // Input vector
            Vector3 v = _inputVector;
            v = Quaternion.LookRotation(dc) * v; // We rotate the input vector according to dc
            DrawArrow(this.transform.position - Vector3.up * 0.1f, v * 2f, Color.green);
        }

        private void DrawArrow(Vector3 origin, Vector3 direction, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawRay(origin, direction);
        }
    }
}
