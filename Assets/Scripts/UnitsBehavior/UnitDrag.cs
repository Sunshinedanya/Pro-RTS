using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    private Camera _mainCamera;

    [SerializeField] private RectTransform _boxVisual;

    private Rect selectionBox;

    private Vector2 start;
    private Vector2 end;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        DrawVisual();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("asd");
            start = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition;
            DrawVisual();
        }

        if (Input.GetMouseButtonUp(0))
        {
            start = Vector2.zero;
            end = Vector2.zero;

            DrawVisual();
        }
    }

    private void DrawVisual()
    {
        var boxStart = start;
        var boxEnd = end;

        var boxCentered = (boxStart + boxEnd) / 2;

        _boxVisual.position = boxCentered;

        var boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        _boxVisual.sizeDelta = boxSize;
    }

    private void DrawSelection()
    {
        
    }

    private void SelectUnits()
    {

    }
}
