public interface IHealer
{
    float heal { get; }
    float minHealRange { get; }
    float maxHealRange { get; }
    float healCooldown { get; }
}