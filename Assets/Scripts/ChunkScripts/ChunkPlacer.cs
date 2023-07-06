using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : SingletonBase<ChunkPlacer>
    {
        private Transform _dronPosition;
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _chunkCrossPref;
        [SerializeField] private Chunk _firstChunk;
        [SerializeField] private int _chunkRoad;

        [SerializeField] private Transform _orentir;

        private int _chunkNumSpawn;

        private Vector3 _rotationChunk;

        private Vector3 _popravka;
        private Vector3 angle;

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
            if (_chunkRoad >= _chunkNumSpawn)
            {
                
                _chunkNumSpawn++;

                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];

                if (lastChunk.typeRoad == TypeRoad.Crossroad)
                {
                    var endChunk = lastChunk.RandomTurning();
                    Debug.Log(endChunk);
                    var turning = lastChunk.turningCross;
                    Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], endChunk.transform.position, endChunk.rotation);
                    _spawnedChunks.Add(newChunk);
                    lastChunk.GetComponent<TurningDron>().turning = turning;
                    /*switch (turning)
                    {
                        case Turning.Left:
                            var angle1 = new Vector3(0, 0, 0);
                            _rotationChunk += angle1;

                            angle = new Vector3(0, -90, 0);

                            newChunk.transform.position = endChunk.transform.position;
                           // newChunk.transform.eulerAngles += endChunk.transform.localEulerAngles;
                            var dist = Vector3.Distance(newChunk.beginChunk.transform.position, endChunk.transform.position);
                          *//*  if (dist > 1)
                            {
                                newChunk.transform.eulerAngles = endChunk.transform.localEulerAngles + angle;
                                Debug.Log(dist > 1);
                            }*//*
                                
                            // newChunk.transform.eulerAngles = endChunk.transform.localEulerAngles + angle;
                            //SetPlace(newChunk, endChunk);
                            *//* var distLostChunk = Vector3.Distance(new Vector3(endChunk.transform.position.x, 0, 0), lastChunk.beginChunk.transform.position);
                             var distNewChunk = Vector3.Distance(new Vector3(endChunk.transform.position.x, 0, 0), newChunk.beginChunk.transform.position);
                             if (distLostChunk < distNewChunk)
                             {
                                 newChunk.transform.eulerAngles = new Vector3(0, -90, 0);
                             }
                             else if (distLostChunk == distNewChunk)
                             {
                                 newChunk.transform.eulerAngles = new Vector3(0, 0, 0);
                             }
                             else if (distLostChunk > distNewChunk)
                                 newChunk.transform.eulerAngles = new Vector3(0, 180, 0);
                             Debug.Log(distLostChunk );
                             Debug.Log(distNewChunk) ;*//*

                            break;

                        case Turning.Right:
                            var angle2 = new Vector3(0, 90, 0);
                            _rotationChunk = angle2;

                            angle = new Vector3(0, 90, 0);

                            var offset = newChunk.transform.position - newChunk.beginChunk.position;

                            newChunk.transform.position = endChunk.localPosition;

                           // newChunk.transform.eulerAngles += endChunk.transform.localEulerAngles;
                            var dist1 = Vector3.Distance(newChunk.beginChunk.transform.position, endChunk.transform.position);
                          *//*  if (dist1 > 1)
                            {
                                Debug.Log(dist1 > 1);
                                newChunk.transform.eulerAngles = endChunk.transform.localEulerAngles + angle;
                            }*//*
                               
                            // newChunk.transform.eulerAngles = endChunk.transform.localEulerAngles + angle;
                            *//* var distLostChunkRight = Vector3.Distance(new Vector3(endChunk.transform.position.x, 0, 0), lastChunk.beginChunk.transform.position);
                             var distNewChunkRight = Vector3.Distance(new Vector3(endChunk.transform.position.x, 0, 0), newChunk.beginChunk.transform.position);

                             Debug.Log(distLostChunkRight);
                             Debug.Log(distNewChunkRight);
                             if (distLostChunkRight > distNewChunkRight)
                             {
                                 newChunk.transform.eulerAngles = new Vector3(0, 180, 0);
                             }
                             else if (distLostChunkRight == distNewChunkRight)
                             {
                                 newChunk.transform.eulerAngles = new Vector3(0, 0, 0);
                             }
                             else if (distLostChunkRight < distNewChunkRight)
                                 newChunk.transform.eulerAngles = new Vector3(0, 90, 0);*//*

                            //SetPlace(newChunk, endChunk);


                            break;

                        case Turning.Forward:
                            newChunk.transform.rotation = lastChunk.endChunks[0].root.transform.rotation;
                            newChunk.transform.position = lastChunk.endChunks[0].position - newChunk.beginChunk.position;

                            break;

                    }*/
                }
                else
                {
                    var endPoit = lastChunk.endChunks[0];
                    Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)], endPoit.position, endPoit.rotation);

                    /* newChunk.transform.rotation = endPoit.root.transform.rotation;
                     newChunk.transform.position = endPoit.position - newChunk.beginChunk.position;*/
                    //SetPlace(newChunk, endPoit);
                    _spawnedChunks.Add(newChunk);
                }
            }

            if (_chunkRoad == _chunkNumSpawn)
            {
                _chunkNumSpawn = 0;
                Chunk newChunk = Instantiate(_chunkCrossPref);
                var lastChunk = _spawnedChunks[_spawnedChunks.Count - 1];
                var endPoit = lastChunk.endChunks[0];
                newChunk.transform.rotation = endPoit.root.transform.rotation;
                newChunk.transform.position = endPoit.position - newChunk.beginChunk.position;
                _spawnedChunks.Add(newChunk);
            }
               

            if (_spawnedChunks.Count >= 10)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
        }

      
        private void SetPlace(Chunk newChunk, Transform endPoit)
        {
            Debug.Log(_rotationChunk);
          
            newChunk.transform.rotation = endPoit.root.transform.rotation;
            newChunk.transform.position = endPoit.position - newChunk.beginChunk.position;
            
        }

    }

}
