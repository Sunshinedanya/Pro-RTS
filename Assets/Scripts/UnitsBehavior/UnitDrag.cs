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
            start = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
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
        if(Input.mousePosition.x < start.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = start.x;
        }
        else
        {
            selectionBox.xMin = start.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < start.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = start.y;
        }
        else
        {
            selectionBox.yMin = start.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        foreach (var unit in ClickableSelection.Instance.Clickables)
        {
            if(selectionBox.Contains(_mainCamera.WorldToScreenPoint(unit.transform.position)))
                ClickableSelection.Instance.DragSelect(unit);
        }
    }
}
