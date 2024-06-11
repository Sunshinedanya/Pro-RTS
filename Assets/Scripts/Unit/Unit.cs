using System.Collections.Generic;

[System.Serializable]
public abstract class Unit : IDamagable
{
    private string _name;
    private int _health;
    private float _speed;
    private float _detectionRange;
    private List<object> cost;
    
    public IReadOnlyList<object> Cost => cost;
    public abstract void GetDamage(int damage);
    public abstract void Kill();
}
