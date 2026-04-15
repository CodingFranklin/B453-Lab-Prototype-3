using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public Dictionary<ResourceType, Resource> resources 
        = new Dictionary<ResourceType, Resource>();

    [Header("Resources Collect Time")]
    public int woodCollectTime = 1;
    public int stoneCollectTime = 3;
    public int ironCollectTime = 5;
    public int goldCollectTime = 10;
    
    [Header("Resources Text")]
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] TextMeshProUGUI ironText;
    [SerializeField] TextMeshProUGUI goldText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        InitializeResources();
    }

    private void Update()
    {
        UpdateResourcesText();
    }

    private void InitializeResources()
    {
        resources[ResourceType.Wood] = new Resource(ResourceType.Wood, woodCollectTime);
        resources[ResourceType.Stone] = new Resource(ResourceType.Stone, stoneCollectTime);
        resources[ResourceType.Iron] = new Resource(ResourceType.Iron, ironCollectTime);
        resources[ResourceType.Gold] = new Resource(ResourceType.Gold, goldCollectTime);
    }

    /**
     * Add amount of resource to the given resource type, the value is default set to 1
     */
    public void AddResource(ResourceType type, int value = 1)
    {
        resources[type].amount += value;
        
        Debug.Log($"{type} : {resources[type].amount}");
    }

    public Resource GetResource(ResourceType type)
    {
        return resources[type];
    }
    
    public int GetResourceAmount(ResourceType type)
    {
        return resources[type].amount;
    }

    private void UpdateResourcesText()
    {
        woodText.text = resources[ResourceType.Wood].amount.ToString();
        stoneText.text = resources[ResourceType.Stone].amount.ToString();
        ironText.text = resources[ResourceType.Iron].amount.ToString();
        goldText.text = resources[ResourceType.Gold].amount.ToString();
    }
}
