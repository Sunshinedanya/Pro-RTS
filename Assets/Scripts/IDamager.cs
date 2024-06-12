public interface IDamager
{
    float damage { get; }
    float minAttackRange { get; }
    float maxAttackRange { get; }
    float attackCooldown { get; }
}
