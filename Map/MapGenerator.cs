using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;
    private GameObject _plane;

    [SerializeField] private Color _color;

    [SerializeField] private float _treeChance;
    [SerializeField] private float _rockChance;

    public void GenerateMap(float sideSize)
    {
        DestroyImmediate(_plane);

        if (_treePrefab == null || _rockPrefab == null)
        {
            throw new ArgumentException();
        }

        int planeSize = Mathf.RoundToInt(Mathf.Sqrt(sideSize));
        sideSize = planeSize;

        float playerBaseX = UnityEngine.Random.Range(-sideSize / 2, sideSize / 2);
        float playerBaseZ = UnityEngine.Random.Range(-sideSize / 2, sideSize / 2);

        GeneratePlane(sideSize);

        var readySize = GenerateNavMesh(_plane.transform, sideSize);

        var randomMultiplier = UnityEngine.Random.Range(-100f, 100f);

        for (float i = 0; i < sideSize / 10; i += 0.1f)
        {
            for (float j = 0; j < sideSize / 10; j += 0.1f)
            {
                if (Mathf.Pow(playerBaseX / 10 + i, 2) + Mathf.Pow(playerBaseZ / 10 + j, 2) < 10)
                    continue;

                var noise = Mathf.PerlinNoise(i + randomMultiplier, j + randomMultiplier);

                if (noise >= 0.4)
                {
                    SpawnResources(i * 10, j * 10, noise, UnityEngine.Random.Range(-3f, 3f));
                }
            }
        }

        AfterNavMeshGenerated(readySize);
    }
    private void SpawnResources(float x, float z, float noise, float multiplier)
    {
        noise += multiplier;

        var position = new Vector3(x + multiplier, 0, z + multiplier);

        if (noise > _treeChance)
        {
            Instantiate(_treePrefab, position, Quaternion.identity, _plane.transform);
        }
        else if (noise < _rockChance)
        {
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
            new(0, 0, 0),
            new(0, 0, sideSize),
            new(sideSize, 0, 0),
            new(sideSize, 0, sideSize)
        };

        mesh.uv = new Vector2[]
        {
            new(0, 0),
            new(0, 1),
            new(1, 0),
            new(1, 1)
        };

        mesh.triangles = new int[]
        {
            0, 1, 2,
            3, 2, 1
        };

        meshFilter.mesh = mesh;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        _plane.AddComponent<MeshCollider>();

        meshRenderer.material.color = _color;
    }

    private float GenerateNavMesh(Transform plane, float sideSize)
    {
        NavMesh.RemoveAllNavMeshData();
        var settings = NavMesh.CreateSettings();
        var buildSources = new List<NavMeshBuildSource>();
        var floor = new NavMeshBuildSource
        {
            transform = Matrix4x4.TRS(Vector3.zero, plane.rotation, Vector3.one),
            shape = NavMeshBuildSourceShape.Box,
            size = new Vector3(sideSize, 0, sideSize)
        };
        buildSources.Add(floor);

        NavMeshData built = NavMeshBuilder.BuildNavMeshData(
            settings, buildSources, new Bounds(Vector3.zero, new Vector3(sideSize, 0, sideSize)),
            new Vector3(0, 0, 0), plane.rotation);
        NavMesh.AddNavMeshData(built);

        return sideSize;
    }

    private void AfterNavMeshGenerated(float sideSize)
    {
        _plane.transform.position = new Vector3(-sideSize / 2, 0, -sideSize / 2);
    }
}
