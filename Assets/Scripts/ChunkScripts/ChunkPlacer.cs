using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : SingletonBase<ChunkPlacer>
    {
        private Transform _dronPosition;
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _firstChunk;

        private Quaternion _rotationChunk;

        private Vector3 _popravka;

        private List<Chunk>  _spawnedChunks = new List<Chunk>();


        private void Start () 
        {
            _dronPosition = Dron.Instance.transform;
            Chunk newFirstChunk = Instantiate(_firstChunk);
            _spawnedChunks.Add(newFirstChunk);
            for (int i = 0; i < 7; i++)
            {
                SpawnChunk();
            }

        }


       /* private void Update () 
        {
            if (_dronPosition.position.x > _spawnedChunks[_spawnedChunks.Count - 1].endChunks[0].position.x - 25)
            {
                SpawnChunk();
            }
        }*/

        public void SpawnChunk()
        { 
            Chunk newChunk =  Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)]);
                      

            var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];

            if (lastChunk.typeRoad == TypeRoad.Crossroad)
            {
                var endChunk = lastChunk.RandomTurning();
                var turning = lastChunk.turningCross;
                lastChunk.GetComponent<TurningDron>().turning = turning;
                switch (turning)
                {
                    case Turning.Left:
                        _rotationChunk = Quaternion.Euler(0, -90, 0);

                        newChunk.transform.position = endChunk.position - newChunk.beginChunk.localPosition + new Vector3(-2, 0, 2);
                        newChunk.transform.rotation = _rotationChunk;
                        _popravka = new Vector3(-2, 0, 2);
                        break;

                    case Turning.Right:
                        _rotationChunk = Quaternion.Euler(0, 90, 0);
                        
                        newChunk.transform.position = endChunk.position - newChunk.beginChunk.localPosition + new Vector3(-2, 0, -2);
                        newChunk.transform.rotation = _rotationChunk;
                        _popravka = new Vector3(-2, 0, -2);

                        break;

                    case Turning.Forward:
                        SetPlace(newChunk, lastChunk);
/*                        newChunk.transform.rotation = _rotationChunk;
                        newChunk.transform.position = lastChunk.endChunks[0].position - newChunk.beginChunk.localPosition;*/
                        break;

                }
                /*                if (turning == Turning.Left)
                                {
                                    _rotationChunk = Quaternion.Euler(0, -90, 0);

                                }
                                if (turning == Turning.Right)
                                {
                                    _rotationChunk = Quaternion.Euler(0, 90, 0);
                                }
                                if (turning == Turning.Forward)
                                {
                                    _rotationChunk = Quaternion.Euler(0, 0, 0);
                                }*/
/*                Debug.Log(endChunk.position);
                newChunk.transform.position = endChunk.position - newChunk.beginChunk.localPosition  + new Vector3(-2,0,-2);
                newChunk.transform.rotation = _rotationChunk;*/
            }
            else
            {
                SetPlace(newChunk, lastChunk);
                /*newChunk.transform.rotation = _rotationChunk;
                newChunk.transform.position = lastChunk.endChunks[0].position - newChunk.beginChunk.localPosition;*/
            }

            _spawnedChunks.Add(newChunk);

            if (_spawnedChunks.Count >= 10)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }

        private void RandomTurning(Chunk chunk)
        {
          
        }

        private void SetPlace(Chunk chunk, Chunk lastChunk)
        {
            chunk.transform.rotation = _rotationChunk;
            chunk.transform.position = lastChunk.endChunks[0].position - chunk.beginChunk.localPosition + _popravka;
        }

        private void SetTurning()
        { 
        
        }

    }

}
