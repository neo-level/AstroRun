using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    private GameObject _dummy;

    private int[] randomTurn = {-90, 90};

    private sbyte _numberOfGeneratedPlatforms = 20;
    private sbyte _stairHeight = 5;
    private sbyte _platformHeight = -10;

    private byte _stairRotation = 180;

    // Start is called before the first frame update
    void Start()
    {
        _dummy = new GameObject("dummy");
        
        for (int i = 0; i < _numberOfGeneratedPlatforms; i++)
        {
            int platformNumber = Random.Range(0, platforms.Length);

            var platform = Instantiate(platforms[platformNumber], _dummy.transform.position, _dummy.transform.rotation);

            switch (platforms[platformNumber].tag)
            {
                case "stairsUp":
                    _dummy.transform.Translate(Vector3.up * _stairHeight);
                    break;
                
                case "stairsDown":
                    _dummy.transform.Translate(Vector3.down * _stairHeight);
                    
                    platform.transform.Rotate(Vector3.up * _stairRotation);
                    platform.transform.position = _dummy.transform.position;
                    break;
                
                case "PlatformTSection":
                    int turn = Random.Range(0, randomTurn.Length);
                    
                    _dummy.transform.Rotate(Vector3.up * randomTurn[turn]);
                    _dummy.transform.Translate(Vector3.forward * _platformHeight);
                    break;
            }

            _dummy.transform.Translate(Vector3.forward * _platformHeight);
        }
    }
}