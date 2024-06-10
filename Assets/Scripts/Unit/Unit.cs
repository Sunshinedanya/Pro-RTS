using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamagable
{
    private string _name;
    private int _health;
    private float _speed;
    private float _attackRange;
    private List<object> cost;
    
    public IReadOnlyList<object> Cost => cost;
    public abstract void GetDamage(int damage);
    public abstract void Kill();
}
