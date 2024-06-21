using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var hitted = Physics.Raycast(ray, out hit);

            if (hitted)
            {
                GoTo(hit.point);
            }
        }
    }

    public void GoTo(Vector3 position)
    {
        var units = UnitSelection.Instance.unitsSelected;

        foreach (var unit in units)
        {
            unit.GetComponent<NavMeshAgent>().SetDestination(position);
        }
    }
}
