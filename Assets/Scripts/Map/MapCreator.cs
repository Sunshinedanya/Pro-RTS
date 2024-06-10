using System;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;
    private GameObject _plane;

    [SerializeField] private Color _color;

    // bigger chance == bigger chance
    [SerializeField] private float _treeChance;
    [SerializeField] private float _rockChance;

    private readonly int multiplier = 10;

    public void GenerateMap(float sideSize)
    {
        if (_treePrefab == null)
            throw new ArgumentException();

        if (_rockPrefab == null)
            throw new ArgumentException();

        GeneratePlane(sideSize);

        for (float i = 0; i < sideSize / multiplier; i += 0.1f)
        {
            for (float j = 0; j < sideSize / multiplier; j += 0.1f)
            {
                var noise = Mathf.PerlinNoise(i, j);

                if (noise >= 0.4)
                {
                    SpawnResource(i * multiplier, j * multiplier, noise);
                }
            }
        }
    }
    private void SpawnResource(float x, float z, float noise)
    {
        var position = new Vector3(x, 0, z);

        if (noise <= _treeChance)
        {
            Instantiate(_treePrefab, position, Quaternion.identity);
        }
        else if (noise <=_rockChance)
        {
            Instantiate(_rockPrefab, position, Quaternion.identity);
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
