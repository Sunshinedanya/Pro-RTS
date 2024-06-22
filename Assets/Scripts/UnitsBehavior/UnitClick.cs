using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera _mainCamera;

    [SerializeField] private LayerMask _clickable;
    [SerializeField] private LayerMask _ground;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
           if(Physics.Raycast(ray,out hit, Mathf.Infinity, _clickable))
           {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    ClickableSelection.Instance.DragSelect(hit.collider.gameObject);
                    return;
                }
                ClickableSelection.Instance.ClickSelect(hit.collider.gameObject);
           } 
           else
           {
                ClickableSelection.Instance.Deselect();
           }
        }
    }
}
