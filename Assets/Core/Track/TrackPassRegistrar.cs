using Car.CarControl;
using UnityEngine;

namespace Car.Track
{
    public class TrackPassRegistrar : MonoBehaviour
    {
        private TrackGenerator generator;
        private bool passedOnce;

        public TrackGenerator Generator
        {
            get => generator;
            set => generator = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CarMovement>() && !passedOnce)
            {
                generator.AddNewSegment();
                passedOnce = true;
            }
        }
    }
}