using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class ChunkPlacer : SingletonBase<ChunkPlacer>
    {
        private Transform _dronPosition;
        [SerializeField] private Chunk[] _chunkPrefabs;
        [SerializeField] private Chunk _firstChunk;

        private Vector3 _rotationChunk;

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
                        //_rotationChunk = Quaternion.Euler(0, -90, 0);
                        var angle1 = new Vector3(0, -90, 0);
                        _rotationChunk += angle1;
                        if (_rotationChunk.y == 180)
                        {
                            _popravka = new Vector3(-4, 0, 0);
                        }
                        else if (_rotationChunk.y == -180)
                        {
                            _popravka = new Vector3(-4, 0, 0);
                        }
                        else if (_rotationChunk.y == -90)
                        {
                            _popravka = new Vector3(-2, 0, 2);
                        }
                        else if (_rotationChunk.y == 90)
                        {
                            _popravka = new Vector3(-2, 0, -2);
                        }
                        else
                            _popravka = new Vector3(4, 0, 0);
                        newChunk.transform.eulerAngles = _rotationChunk;
                        SetPlace(newChunk, endChunk);
                        //newChunk.transform.position = endChunk.position - newChunk.beginChunk.localPosition + new Vector3(-2, 0, 2);
                        // newChunk.transform.rotation = _rotationChunk;
                        //newChunk.transform.eulerAngles += _rotationChunk;

                        break;

                    case Turning.Right:
                        var angle2 = new Vector3(0, 90, 0);
                        _rotationChunk += angle2;
                        if (_rotationChunk.y == 270)
                        {
                            _popravka = new Vector3(-2, 0, 2);
                        }
                        else if (_rotationChunk.y == 180)
                        {
                            _popravka = new Vector3(-4, 0, 0);
                        }
                        else if (_rotationChunk.y == -180)
                        {
                            _popravka = new Vector3(-4, 0, 0);
                        }
                        else if (_rotationChunk.y == -90)
                        {
                            _popravka = new Vector3(0, 0, -4);
                        }
                        else if (_rotationChunk.y == 90)
                        {
                            _popravka = new Vector3(-2, 0, -2);
                        }
                        else
                            _popravka = new Vector3(-2, 0, -2);
                        newChunk.transform.eulerAngles = _rotationChunk;
                        SetPlace(newChunk, endChunk);
                        //newChunk.transform.position = endChunk.position - newChunk.beginChunk.localPosition + new Vector3(-2, 0, -2);
                      
                        

                        break;

                    case Turning.Forward:
                        SetPlace(newChunk, lastChunk.endChunks[0]);
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
                var endPoit = lastChunk.endChunks[0];
                SetPlace(newChunk, endPoit);
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

        private void SetPlace(Chunk newChunk, Transform endPoit)
        {
            Debug.Log(_rotationChunk);
            //newChunk.transform.eulerAngles = _rotationChunk;
            if (_rotationChunk != new Vector3(0, 0, 0))
            {
                newChunk.transform.eulerAngles = _rotationChunk;
                newChunk.transform.position = endPoit.position - newChunk.beginChunk.localPosition + _popravka;
                
            }
            else
            {
                newChunk.transform.eulerAngles = _rotationChunk;
                newChunk.transform.position = endPoit.position - newChunk.beginChunk.localPosition;
                
            }
           
                

        }

        private void SetTurning()
        { 
        
        }

    }

}
