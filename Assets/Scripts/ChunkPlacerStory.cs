using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacerStory : MonoBehaviour
    {
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _firstChunk;       
        [SerializeField] private Chunk _endChunk;

        [SerializeField] private TypeRoad[] typeRoads;
        [SerializeField] private Turning[] turningCross;

        private Chunk _lastChunk;
        private int _indexChunk = 0;

        private void Start () 
        {
            Chunk newFirstChunk = Instantiate(_firstChunk);
            _lastChunk = newFirstChunk;

            foreach (var chunk in _chunkPrefabs) 
            {           
                if (_lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    var turning = turningCross[0];
                    _lastChunk.GetComponent<TurningDron>().turning = turningCross[0];
                    switch (turning)
                    {
                        case Turning.Left:
                           
                            SetPlaceStopCross(_lastChunk.endChunks[1], _lastChunk.endChunks[2]);
                            SetPlace(_lastChunk.endChunks[0]);
                            break;

                        case Turning.Right:
                           
                            SetPlaceStopCross(_lastChunk.endChunks[0], _lastChunk.endChunks[2]);
                            SetPlace(_lastChunk.endChunks[1]);

                            break;

                        case Turning.Forward:
                            
                            SetPlaceStopCross(_lastChunk.endChunks[0], _lastChunk.endChunks[1]);
                            SetPlace(_lastChunk.endChunks[2]);

                            break;

                    }
                }
                else if (_lastChunk.typeRoad == TypeRoad.Turning)
                {
                    var turning1 = turningCross[1];
                    _lastChunk.GetComponent<TurningDron>().turning = turning1;

                    switch (turning1)
                    {
                        case Turning.Left:
                            
                            SetPlaceStopAngleT(_lastChunk.endChunks[1]);
                            SetPlace(_lastChunk.endChunks[0]);

                            break;

                        case Turning.Right:
                            
                            SetPlaceStopAngleT(_lastChunk.endChunks[0]);
                            SetPlace(_lastChunk.endChunks[1]);

                            break;
                    }
                }
                else
                {
                    if (_indexChunk < _chunkPrefabs.Length)
                    {
                        var endPoit = _lastChunk.endChunks[0];
                        SetPlace(endPoit);
                    }
                    else
                    { 
                       var end = Instantiate(_endChunk, _lastChunk.endChunks[0].position, _lastChunk.endChunks[0].rotation);
                    }
                }                
            }         
        }


        #region  Instantiate and placing a chunk
        private void SetPlaceStopCross(Transform transform, Transform transform1)
        {

           Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

            Chunk newChunk2 = Instantiate(_chunkPrefabs[_indexChunk++], transform1.position, transform1.rotation);
            newChunk2.transform.position += Offset(newChunk2);
        }

        private void SetPlaceStopAngleT(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);

        }
        private void SetPlace(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk++], transform.position, transform.rotation);
            newChunk.transform.position += Offset(newChunk);
            _lastChunk = newChunk;
        }

        /// <summary>
        ///  Offset from the end of the previous chunk
        /// </summary>
        /// <param name="chunk"></param>
        /// <returns></returns>
        private Vector3 Offset(Chunk chunk)
        { 
            var offset = chunk.transform.position - chunk.beginChunk.transform.position;
            return offset;
        }
        #endregion
    }
}

