using System;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private GameObject _plane;

    [SerializeField] private Color _color;

    [SerializeField] private float _treeChance;
    [SerializeField] private float _rockChance;

    [SerializeField] private UnityEvent _AfterMapGenerated;

    [SerializeField] private GameSessionScriptableObject _gameSession;
    [SerializeField] private GameObject _enemyBase;

    private void Start()
    {
        GenerateMap(_gameSession.dataElement.mapSize);
    }

    public void GenerateMap(float sideSize)
    {
        if (_treePrefab == null)
            throw new ArgumentException();

        if (_rockPrefab == null)
            throw new ArgumentException();

        GeneratePlane(sideSize);

        var navMesh = _plane.AddComponent<NavMeshSurface>();
        navMesh.BuildNavMesh();
    

        var randomMultiplier = Random.Range(-100f, 100f);

        for (float i = 0; i < sideSize / 10; i += 0.1f)
        {
            for (float j = 0; j < sideSize / 10; j += 0.1f)
            {
                var noise = Mathf.PerlinNoise(i + randomMultiplier, j + randomMultiplier);

                if (noise >= 0.4)
                {
                    SpawnResource(i * 10, j * 10, noise, Random.Range(-3f, 3f));
                }
            }
        }

        SpawnBases();

        _AfterMapGenerated.Invoke();
    }
    private void SpawnResource(float x, float z, float noise, float multiplier)
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
        var terrain = _plane.GetComponent<Terrain>();
        if(terrain == null)
            throw new ArgumentNullException(nameof(terrain));

        terrain.terrainData.size = new Vector3(sideSize,0,sideSize);

        _plane = Instantiate(_plane);
    }
    private void SpawnBases()
    {
        var radius = _gameSession.dataElement.mapSize/2;

        for (int i = 0; i < _gameSession.dataElement.enemyAmount; i++)
        {
            // Угол для каждого объекта
            float angle = i * Mathf.PI * 2f / _gameSession.dataElement.enemyAmount;

            // Позиция объекта на окружности
            Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);

            // Создание объекта на новой позиции
            Instantiate(_enemyBase, new Vector3(radius, 0, radius) + newPosition, Quaternion.identity);
        }
    }
}
