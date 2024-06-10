using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;

    private readonly int multiplier = 10;
    private GameObject _plane; 

    public void GenerateMap(float sideSize)
    {
        if (_treePrefab == null)
            throw new ArgumentException();

        if(_rockPrefab == null)
            throw new ArgumentException();

        _plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        _plane.transform.localScale = new Vector3(sideSize, 1, sideSize);

        _plane = Instantiate(_plane);

        for (float i = 0; i < sideSize/multiplier; i += 0.1f)
        {
            print(i);
            for (float j = 0; j < sideSize/multiplier; j += 0.1f)
            {
                print(j);
                var noise = Mathf.PerlinNoise(i, j);
                
                print(noise);
                
                if (noise >= 0.6)
                {
                    SpawnResource(i * multiplier, j* multiplier, noise);
                }
            }
        }

        
    }

    private void SpawnResource(float x, float z, float noise)
    {
        var position = new Vector3(x, 0, z);

        if(noise<= 0.8)
        {
            Instantiate(_treePrefab, position, Quaternion.identity);
        }
        else
        {
            Instantiate(_rockPrefab, position, Quaternion.identity);
        }
    }
}
