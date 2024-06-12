using UnityEngine;

//честно хуйня какаято
[System.Serializable]
public class Archer : Unit, IDamager
{
    [SerializeField] private float _damage;
    [SerializeField] private float _minAttackRange ;
    [SerializeField] private float _maxAttackRange ;
    [SerializeField] private float _attackCooldown ;

    public float damage => _damage;
    public float minAttackRange => _minAttackRange;
    public float maxAttackRange => _maxAttackRange;
    public float attackCooldown => _attackCooldown;

    public override void GetDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Kill()
    {
        throw new System.NotImplementedException();
    }
}
