using System.Collections.Generic;
using System.Drawing;
using UnityEngine.Events;

public class ContestantsList
{
    private List<Contestant> _enemyList = new List<Contestant>();
    private List<Color> colors = new List<Color>() 
    {
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.LightBlue,
        Color.Purple
    };

    public UnityEvent<Contestant> OnEnemyAdd;
    public UnityEvent<Contestant> OnEnemyRemove;

    public bool TryAdd(Contestant enemy)
    {
        if(_enemyList.Contains(enemy))
            return false;

        _enemyList.Add(enemy);

        OnEnemyAdd?.Invoke(enemy);
        return true;
    }

    public bool TryRemove(Contestant enemy)
    {
        _enemyList.Remove(enemy);
        
        OnEnemyRemove?.Invoke(enemy);
        return true;
    }
}
