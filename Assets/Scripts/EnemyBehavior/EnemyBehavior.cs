using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private UnitFactoryComponent _unitFactoryComponent;

    private float _enemyCooldown;
    private void Start()
    {
        _unitFactoryComponent = GetComponent<UnitFactoryComponent>();
    }

    private void Update()
    {
        _enemyCooldown += Time.deltaTime;
    }
}
