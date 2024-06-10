using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, IDamagable
{
    private int _health;
    private List<object> cost;
    public IReadOnlyList<object> Cost => cost;
    public abstract void GetDamage(int damage);
    public abstract void Kill();
}
