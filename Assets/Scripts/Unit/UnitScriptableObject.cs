public abstract class UnitScriptableObject<TUnit> : ConfigurableScriptableObject<TUnit>
    where TUnit : Unit
{
    public override void Save()
    {
        if (string.IsNullOrEmpty(path) == true)
            path = SerializeHelper.CreatePath(dataElement._name);
        
        SerializeHelper.SerialiseAndSave(path, dataElement);
    }

    public virtual TUnit GetUnit()
    {
        return dataElement;
    }
}