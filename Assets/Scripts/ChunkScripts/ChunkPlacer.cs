using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : SingletonBase<ChunkPlacer>
    {
        private Transform _dronPosition;
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk[] _chunkCrossPref;
        [SerializeField] private Chunk _firstChunk;
        [SerializeField] private int _chunkRoad;
        [SerializeField] private Chunk[] _roadTurn;

        [SerializeField] private Transform _orentir;

        private int _chunkNumSpawn;

        private List<Chunk>  _spawnedChunks = new List<Chunk>();
        private List<Chunk> _spawnedStopChunks = new List<Chunk>();


        private void Start () 
        {
            _dronPosition = Dron.Instance.transform;
            Chunk newFirstChunk = Instantiate(_firstChunk);
            _spawnedChunks.Add(newFirstChunk);
            for (int i = 0; i < 8; i++)
            {
                SpawnChunk();
            }

        }


         private void Update () 
         {

            if (_spawnedStopChunks.Count >= 12)
            {
                Destroy(_spawnedStopChunks[0].gameObject);
                _spawnedStopChunks.RemoveAt(0);
            }
            /*if (_dronPosition.position.x > _spawnedChunks[_spawnedChunks.Count - 1].endChunks[0].position.x - 25)
            {
                SpawnChunk();
            }*/
        }

        public void SpawnChunk()
        {
            if (_chunkRoad >= _chunkNumSpawn)
            {
                _chunkNumSpawn++;

                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];

                if (lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    var endChunk = lastChunk.RandomTurning();
                    var turning = lastChunk.turningCross;
                    SetPlace(endChunk);

                    lastChunk.GetComponent<TurningDron>().turning = turning;
                    switch (turning)
                    {
                        case Turning.Left:

                            SetPlaceStopCross(lastChunk.endChunks[1], lastChunk.endChunks[2]);
                            break;

                        case Turning.Right:

                            SetPlaceStopCross(lastChunk.endChunks[0], lastChunk.endChunks[2]);

                            break;

                        case Turning.Forward:
                            SetPlaceStopCross(lastChunk.endChunks[0], lastChunk.endChunks[1]);
                            break;

                    }
                }
                else if (lastChunk.typeRoad == TypeRoad.Turning)
                {
                    var endChunk = lastChunk.RandomTurning();
                    var turning1 = lastChunk.turningCross;
                    SetPlace(endChunk);

                    lastChunk.GetComponent<TurningDron>().turning = turning1;

                    switch (turning1)
                    {
                        case Turning.Left:
                            SetPlaceStopAngleT(lastChunk.endChunks[1]);

                            break;

                        case Turning.Right:

                            SetPlaceStopAngleT(lastChunk.endChunks[0]);
                            break;
                    }
                }
                else
                {
                    var endPoit = lastChunk.endChunks[0];
                    SetPlace(endPoit);

                }
            }

            if (_chunkRoad == _chunkNumSpawn)
            {
                _chunkNumSpawn = 0;
                Chunk newChunk = Instantiate(_chunkCrossPref[Random.Range(0, _chunkCrossPref.Length)]);
                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];
                var endPoit = lastChunk.endChunks[0];

                newChunk.transform.rotation = endPoit.root.transform.rotation;
                newChunk.transform.position = endPoit.position - newChunk.beginChunk.position;
                _spawnedChunks.Add(newChunk);
            }

            if (_spawnedChunks.Count >= 16)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);

            }           
        }

        private void SetPlaceStopCross(Transform transform,Transform transform1)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], transform.position, transform.rotation);
            var offset = newChunk.transform.position - newChunk.beginChunk.transform.position;
            newChunk.transform.position += offset;

/*            Chunk newChunkEnd1 = Instantiate(_roadTurn[Random.Range(0, _roadTurn.Length)], newChunk.endChunks[0].transform.position, newChunk.endChunks[0].transform.rotation);
            var offset2 = newChunkEnd1.transform.position - newChunkEnd1.beginChunk.transform.position;
            newChunkEnd1.transform.position += offset2;*/

            Chunk newChunk1 = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], transform1.position, transform1.rotation);
            var offset3 = newChunk1.transform.position - newChunk1.beginChunk.transform.position;
            newChunk1.transform.position += offset3;

            Chunk newChunkEnd21 = Instantiate(_roadTurn[Random.Range(0, _roadTurn.Length)], newChunk1.endChunks[0].transform.position, newChunk1.endChunks[0].transform.rotation);
            var offset4 = newChunkEnd21.transform.position - newChunkEnd21.beginChunk.transform.position;
            newChunkEnd21.transform.position += offset4;
            _spawnedStopChunks.Add(newChunk);
            _spawnedStopChunks.Add(newChunk1);
            _spawnedStopChunks.Add(newChunkEnd21);

        }

        private  void SetPlaceStopAngleT(Transform transform)
        {
            Chunk newChunk1 = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], transform.position, transform.rotation);
            var offset3 = newChunk1.transform.position - newChunk1.beginChunk.transform.position;
            newChunk1.transform.position += offset3;

            Chunk newChunkEnd21 = Instantiate(_roadTurn[Random.Range(0, _roadTurn.Length)], newChunk1.endChunks[0].transform.position, newChunk1.endChunks[0].transform.rotation);
            var offset4 = newChunkEnd21.transform.position - newChunkEnd21.beginChunk.transform.position;
            newChunkEnd21.transform.position += offset4;
            _spawnedStopChunks.Add(newChunk1);
            _spawnedStopChunks.Add(newChunkEnd21);

        }

        private void SetPlace(Transform transform)
        {
            Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], transform.position, transform.rotation);
            var offset = newChunk.transform.position - newChunk.beginChunk.transform.position;
            newChunk.transform.position += offset;
            _spawnedChunks.Add(newChunk);
        }

    }

}
