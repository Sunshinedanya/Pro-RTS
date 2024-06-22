using UnityEngine;
using UnityEngine.UI;

public class Hinter : MonoBehaviour
{
    [SerializeField] private Text _hint;

    [SerializeField] private string _hintText;
    public void Enter()
    {
        _hint.text = _hintText;
    }

    public void Exit()
    {
        _hint.text = "";
    }
}
