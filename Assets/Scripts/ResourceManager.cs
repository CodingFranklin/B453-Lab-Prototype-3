using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    public Dictionary<ResourceType, Resource> resources 
        = new Dictionary<ResourceType, Resource>();
    
    [SerializeField] private GameObject gem;

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
    [SerializeField] TextMeshProUGUI gemText;
    
    [Header("Collect Time Multiplier")]
    [SerializeField] private float collectTimeMultiplier = 1f;
    [SerializeField] private float minCollectTimeMultiplier = 0.2f;
    
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
        gem.transform.localScale = new Vector3(resources[ResourceType.Gem].amount, resources[ResourceType.Gem].amount, 1f);
    }

    private void InitializeResources()
    {
        resources[ResourceType.Wood] = new Resource(ResourceType.Wood, woodCollectTime, 0, true);
        resources[ResourceType.Stone] = new Resource(ResourceType.Stone, stoneCollectTime);
        resources[ResourceType.Iron] = new Resource(ResourceType.Iron, ironCollectTime);
        resources[ResourceType.Gold] = new Resource(ResourceType.Gold, goldCollectTime);
        resources[ResourceType.Gem] = new Resource(ResourceType.Gem, 0);
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
        gemText.text = resources[ResourceType.Gem].amount.ToString();
    }
    
    public void UnlockResource(ResourceType type)
    {
        Resource res = GetResource(type);
        if (res.unlocked) return;

        res.unlocked = true;
        Debug.Log(type + " unlocked!");
    }
    
    public float GetCollectTimeMultiplier()
    {
        return collectTimeMultiplier;
    }

    public void ApplyCollectSpeedUpgrade(float percentReduction)
    {
        float factor = 1f - percentReduction;
        collectTimeMultiplier *= factor;

        if (collectTimeMultiplier < minCollectTimeMultiplier)
            collectTimeMultiplier = minCollectTimeMultiplier;

        Debug.Log("New collect multiplier: " + collectTimeMultiplier);
    }
}
