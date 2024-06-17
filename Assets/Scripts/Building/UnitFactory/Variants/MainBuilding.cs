using UnityEngine;

public class MainBuilding : BuildingCompopnent<Building>
{
    [SerializeField] private float radius;
    private void Start()
    {
        print("start");
        ClearSpace(radius);
    }

    private void ClearSpace(float radius)
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            print(collider);
            if (collider.gameObject.layer == 7)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}

