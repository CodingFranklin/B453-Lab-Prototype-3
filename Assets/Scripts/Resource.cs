[System.Serializable]

public enum ResourceType
{
    Wood,
    Stone,
    Iron,
    Gold,
    Gem
}

public class Resource
{
    public ResourceType type {get; private set;}
    public int collectTime {get; private set;}
    public int amount { get; set;}
    public bool unlocked = false;
    
    public Resource(ResourceType type, int collectTime, int amount = 0, bool unlocked = false)
    {
        this.type = type;
        this.amount = amount;
        this.collectTime = collectTime;
        this.unlocked = unlocked;
    }
}