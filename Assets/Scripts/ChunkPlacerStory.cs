using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacerStory : MonoBehaviour
    {
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _firstChunk;
        private Chunk _lastChunk;
        [SerializeField] private Chunk _endChunk;

        [SerializeField] private TypeRoad[] typeRoads;
        [SerializeField] private Turning[] turningCross;

        private int _indexChunk = 0;

        private void Start () 
        {
            Chunk newFirstChunk = Instantiate(_firstChunk);
            _lastChunk = newFirstChunk;

            foreach (var chunk in _chunkPrefabs) 
            {           
/*                _indexChunk++;*/
                if (_lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    /*var endChunk = lastChunk.RandomTurning();
                    var turning = lastChunk.turningCross;
                    SetPlace(endChunk);*/
                    // _lastChunk.turningCross = turningCross[0];
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
                    /*var endChunk = _lastChunk.RandomTurning();
                    var turning1 = _lastChunk.turningCross;
                    SetPlace(endChunk);*/
                    _lastChunk.turningCross = turningCross[1];
                    var turning1 = _lastChunk.turningCross;
                    /*_lastChunk.GetComponent<TurningDron>().turning = turning1;*/

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
                    var endPoit = _lastChunk.endChunks[0];
                    SetPlace(endPoit);
                }                
            }
            
            var end = Instantiate(_endChunk, _lastChunk.endChunks[0].position, _lastChunk.endChunks[0].rotation);
        }

        private void SetPlaceStopCross(Transform transform, Transform transform1)
        {

           Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk], transform.position, transform.rotation);
            var offset = newChunk.transform.position - newChunk.beginChunk.transform.position;
            newChunk.transform.position += offset;
            _indexChunk ++;

            Chunk newChunk2 = Instantiate(_chunkPrefabs[_indexChunk], transform1.position, transform1.rotation);
            var offset1 = newChunk2.transform.position - newChunk2.beginChunk.transform.position;
            newChunk.transform.position += offset1;
            _indexChunk++;


        }

        private void SetPlaceStopAngleT(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk], transform.position, transform.rotation);
            var offset = newChunk.transform.position - newChunk.beginChunk.transform.position;
            newChunk.transform.position += offset;
            _indexChunk++;

        }
        private void SetPlace(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[_indexChunk], transform.position, transform.rotation);
            var offset = newChunk.transform.position - newChunk.beginChunk.transform.position;
            newChunk.transform.position += offset;
            _indexChunk++;
            _lastChunk = newChunk;
        }
    }
}

