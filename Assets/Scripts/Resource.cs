[System.Serializable]

public enum ResourceType
{
    Wood,
    Stone,
    Iron,
    Gold
}

public class Resource
{
    public ResourceType type {get; private set;}
    public int collectTime {get; private set;}
    public int amount { get; set;}
    
    public Resource(ResourceType type, int collectTime, int amount = 0)
    {
        this.type = type;
        this.amount = amount;
        this.collectTime = collectTime;
    }
}