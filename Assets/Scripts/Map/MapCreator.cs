using System;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;
    private GameObject _plane;

    [SerializeField] private Color _color;

    [SerializeField] private float _treeChance;
    [SerializeField] private float _rockChance;

    [SerializeField] private int _treeCount;
    [SerializeField] private int _rockCount;

    public void GenerateMap(float sideSize)
    {
        DestroyImmediate(_plane);

        if (_treePrefab == null)
            throw new ArgumentException();

        if (_rockPrefab == null)
            throw new ArgumentException();

        _treeCount = 0;
        _rockCount = 0;

        GeneratePlane(sideSize);

        var randomMultiplier = UnityEngine.Random.Range(-100f, 100f);

        for (float i = 0; i < sideSize / 10; i += 0.1f)
        {
            for (float j = 0; j < sideSize / 10; j += 0.1f)
            {
                var noise = Mathf.PerlinNoise(i + randomMultiplier, j + randomMultiplier);
                
                if(noise >= 0.4)
                {
                    SpawnResource(i * 10, j * 10, noise, UnityEngine.Random.Range(-3f, 3f));
                }
            }
        }
    }
    private void SpawnResource(float x, float z, float noise, float multiplier)
    {
        noise += multiplier;

        var position = new Vector3(x + multiplier, 0, z + multiplier);

        if (noise > _treeChance)
        {
            _treeCount++;
            Instantiate(_treePrefab, position, Quaternion.identity, _plane.transform);
        }
        else if (noise < _rockChance)
        {
            _rockCount++;
            Instantiate(_rockPrefab, position, Quaternion.identity, _plane.transform);
        }
    }

    private void GeneratePlane(float sideSize)
    {
        _plane = new GameObject("MapPlane");

        var meshFilter = _plane.AddComponent<MeshFilter>();
        var meshRenderer = _plane.AddComponent<MeshRenderer>();

        var mesh = new Mesh();

        mesh.vertices = new Vector3[]
        {
            new(0,0,0),
            new(0,0,sideSize),
            new(sideSize,0,0),
            new(sideSize,0,sideSize)
        };

        mesh.uv = new Vector2[]
        {
            new(0,0),
            new(0,1),
            new(1,0),
            new(1,1)
        };

        mesh.triangles = new int[]
        {
            0,1,2,
            3,2,1,
        };

        meshFilter.mesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        _plane.AddComponent<MeshCollider>();

        meshRenderer.material.color = _color;
    }
}
