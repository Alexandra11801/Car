using UnityEngine;

namespace Car.CarControl
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float drivingForce;
        [SerializeField] private float torque;
        private int drivingDirection;
        private int rotationDirection;

        private void FixedUpdate()
        {
            if (drivingDirection != 0)
            {
                rigidbody.AddForce(drivingForce * drivingDirection * transform.forward, ForceMode.Impulse);
            }
            if (rotationDirection != 0)
            {
                rigidbody.AddTorque(torque * rotationDirection * transform.up, ForceMode.Impulse);
            }
        }

        public void AddDrivingDirection(int direction)
        {
            drivingDirection += direction;
        }

        public void AddRotationDirection(int direction)
        {
            rotationDirection += direction;
        }
    }
}