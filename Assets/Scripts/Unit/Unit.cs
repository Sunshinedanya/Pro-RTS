using System.Collections.Generic;

[System.Serializable]
public abstract class Unit : IDamagable
{
    public string _name;
    public int _health;
    public float _speed;
    public float _detectionRange;

    public abstract void GetDamage(int damage);
    public abstract void Kill();
}
