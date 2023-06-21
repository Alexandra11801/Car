using UnityEngine;

namespace Car.Track
{
    public class TrackGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject trackSegmentPrefab;
        [SerializeField] private float trackSegmentLength;
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Vector3 obstaclePosition;
        [SerializeField] private Quaternion obstacleRotation;
        [SerializeField] private float obstacleOffset;
        [SerializeField] private int initTrackSegmentsNumber;
        private int segmentsCount;

        private void Start()
        {
            for (int i = 0; i < initTrackSegmentsNumber; i++)
            {
                AddNewSegment();
            }
        }

        public void AddNewSegment()
        {
            var trackSegment = Instantiate(trackSegmentPrefab, 
                trackSegmentLength * segmentsCount * Vector3.forward, Quaternion.identity, transform);
            trackSegment.GetComponentInChildren<TrackPassRegistrar>().Generator = this;
            var obstacleSide = Random.Range(-1, 2);
            if (obstacleSide != 0)
            {
                var obstacle = Instantiate(obstaclePrefab, Vector3.zero, obstacleRotation, trackSegment.transform);
                obstacle.transform.localPosition = obstaclePosition + obstacleOffset * obstacleSide * Vector3.right;
            }
            segmentsCount++;
        }
    }
}