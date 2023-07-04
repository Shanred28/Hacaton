using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : MonoBehaviour
    {
        private Transform _dronPosition;
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _firstChunk;

        private List<Chunk>  _spawnedChunks = new List<Chunk>();


        private void Start () 
        {
            _dronPosition = Dron.Instance.transform;
            _spawnedChunks.Add(_firstChunk);
        }

        private void Update () 
        {
            if (_dronPosition.position.x > _spawnedChunks[_spawnedChunks.Count - 1].endChunk.position.x - 25)
            {
                SpawnChunk();
            }
        }

        private void SpawnChunk()
        { 
            Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)]);
            newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].endChunk.position - newChunk.beginChunk.localPosition;
            _spawnedChunks.Add(newChunk);

            if (_spawnedChunks.Count >= 10)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }

    }

}
