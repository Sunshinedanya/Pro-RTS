using UnityEngine;

public class Quitter : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        print("Quit");
#endif
        Application.Quit();
    }
}
