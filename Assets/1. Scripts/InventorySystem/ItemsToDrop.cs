using com.goldsprite.GSTools.EssentialAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ItemsToDrop : MonoBehaviour
{
    public enum SpawnType
    {
        First,
        Random
    }

    [SerializeField] private SpawnType spawnType;
    [SerializeField] private List<Item> itemsToSpawn = new();
    [SerializeField] private GameObject consumableItemTemplate;

    public void Drop()
    {
        switch (spawnType)
        {
            case SpawnType.First:
                SpawnConsumableItem(itemsToSpawn[0]);
                break;
            case SpawnType.Random:
                SpawnConsumableItem(itemsToSpawn[Random.Range(0, itemsToSpawn.Count)]);
                break;
            default:
                return;
        }
    }

    private void SpawnConsumableItem(Item item)
    {
        var consumableItem = Instantiate(consumableItemTemplate);
        if (!consumableItem.TryGetComponent(out ConsumableItem consItem))
        {
            Debug.LogError($"GameObject {consumableItem.name} doesn't have CunsumableItem Component!");
            Destroy(consumableItem);
            return;
        }

        consumableItem.name = $"ConsumableItem {consItem.item.itemName}";
        consumableItem.transform.position = transform.position;
        consItem.item = item;

    }
}
