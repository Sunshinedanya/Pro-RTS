using UnityEngine;

[System.Serializable]
public class Contestant
{
    private string _name;
    private Color _color;

    public void SetColor(Color color)
    {
        _color = color;
    }
}