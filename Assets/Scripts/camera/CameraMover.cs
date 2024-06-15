using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        Move();
        CameraResize();
    }

    private void Move()
    {
       transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed * Time.deltaTime;
    }

    private void CameraResize()
    {
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (_camera.orthographicSize <= 5)
            {
                _camera.orthographicSize = 5;
                return;
            }
            _camera.orthographicSize -= 1;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (_camera.orthographicSize >= 25)
            {
                _camera.orthographicSize = 25;
                return;
            }
            _camera.orthographicSize += 1;
        }
    }
}
