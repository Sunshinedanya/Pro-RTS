public interface IDamager
{
    float damage { get; set; }
    float minAttackRange { get; set; }
    float maxAttackRange { get; set; }
    float attackCooldown { get; set; }
}
