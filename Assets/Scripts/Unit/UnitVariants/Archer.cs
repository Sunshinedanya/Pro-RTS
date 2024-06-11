public class Archer : Unit, IDamager
{
    public float damage { get; set; }
    public float minAttackRange { get; set; }
    public float maxAttackRange { get; set; }
    public float attackCooldown { get; set; }

    public override void GetDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Kill()
    {
        throw new System.NotImplementedException();
    }
}
