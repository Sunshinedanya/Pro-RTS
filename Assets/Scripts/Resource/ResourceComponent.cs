using System;
using UnityEngine;
using UnityEngine.Events;

public class ResourceComponent : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private UnityEvent<ResourceType> OnDestroyResource;
    [SerializeField] private UnityEvent OnDestroy;

    public void DestroyResource()
    {
        OnDestroyResource.Invoke(_resourceType);
        Destroy(gameObject);
    }

    private void Start()
    {
       var inventory = FindFirstObjectByType<Inventory>();
        if (inventory == null)
            throw new ArgumentException("No inventory on Scene");

        OnDestroyResource.AddListener(inventory.AddResource);
    }
}
