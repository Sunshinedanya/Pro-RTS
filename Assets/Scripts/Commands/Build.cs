using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    private Action _action;

    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _prefab;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        _model = Instantiate(_model);
        _model.transform.position = new(0,100,0);
    }

    private void Update()
    {
        _action();
    }

    public void StartBuilding()
    {
        _action += Prepare;
    }

    private void Prepare()
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        var hitted = Physics.Raycast(ray,out hit);

        if (hitted)
        {
            var position = hit.point;

            _model.transform.position = position;
            
            if (Input.GetMouseButtonDown(0))
            {
                BuildBuilding(position);
            }
        }
    }

    private void BuildBuilding(Vector3 position)
    {
        Instantiate(_prefab, position, Quaternion.identity);
        EndBuilding();
    }

    public void EndBuilding()
    {
        _model.transform.position = new(0, 100, 0);
        _action -= Prepare;
    }

    public void SetBuilding(GameObject model, GameObject prefab)
    {
        _model = model;
        _prefab = prefab;
    }
}
