using UnityEngine;

namespace Hacaton
{
    public enum TypeRoad
    {
        Straight,
        Crossroad,
        Turning
    }
    public class Chunk : MonoBehaviour
    {
        [SerializeField] public Transform beginChunk;
        [SerializeField] public Transform[] endChunks;
        [SerializeField] public TypeRoad typeRoad;
        [HideInInspector] public Turning turningCross;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out var dron))
                ChunkPlacer.Instance.SpawnChunk();

        }

        public Transform RandomTurning()
        {
            var rnd = Random.Range(0, endChunks.Length);
            var endPoint = endChunks[rnd];
;
            turningCross = SetTurning(rnd);

            return endPoint;
        }

        private Turning SetTurning(int endPoint)
        {
            switch (endPoint)
            { 
                case 0:
                    turningCross = Turning.Left;
                    return turningCross;
                case 1:
                    turningCross = Turning.Right;
                    return turningCross;
                case 2:
                   
                    turningCross = Turning.Forward;
                    return turningCross;
            }
            return turningCross;
        }
    }
}

