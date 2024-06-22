using UnityEngine;

public class MainBuilding : BuildingCompopnent<Building>
{
    public float radius;
    private void Start()
    {
        ClearSpace();
    }

    private void ClearSpace()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var collider in colliders)
        {
            if(collider.gameObject.tag == "Resource")
                Destroy(collider.gameObject);
        }
    }
}

