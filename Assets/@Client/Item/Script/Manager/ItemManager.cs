using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab = null;

    // 아이템이 생성될 발판들 (비워두면 이름이 "Floor" 인 오브젝트를 찾아서 사용)
    [SerializeField] private Collider[] platforms = null;

    [SerializeField] private int maxItemCount = 3;
    [SerializeField] private float spawnInterval = 5f;

    // 발판 가장자리(벽 근처)를 피하기 위한 여백
    [SerializeField] private float edgeMargin = 2f;

    // 발판 표면에서 띄울 높이
    [SerializeField] private float heightOffset = 0.5f;

    private List<Item> itemList = null;

    private void Awake()
    {
        itemList = new List<Item>();

        if (platforms == null || platforms.Length == 0)
        {
            GameObject floor = GameObject.Find("Floor");
            if (floor != null)
            {
                platforms = new Collider[] { floor.GetComponent<Collider>() };
            }
        }
    }

    public void Init()
    {
        StartCoroutine(CoSpawnItems());
    }

    private IEnumerator CoSpawnItems()
    {
        while (true)
        {
            if (itemList.Count < maxItemCount)
            {
                SpawnItem();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnItem()
    {
        if (itemPrefab == null || platforms == null || platforms.Length == 0)
        {
            Debug.LogWarning("[ItemManager] itemPrefab 또는 platforms 가 비어 있습니다.");
            return;
        }

        if (TryGetRandomPointOnPlatform(out Vector3 spawnPosition) == false)
        {
            return;
        }

        GameObject go = Instantiate(itemPrefab, spawnPosition, Quaternion.identity, transform);
        Item itemComponent = go.GetComponent<Item>();
        if (itemComponent != null)
        {
            itemList.Add(itemComponent);
            itemComponent.Init(OnItemPicked);
        }
    }

    private bool TryGetRandomPointOnPlatform(out Vector3 point)
    {
        Collider platform = platforms[Random.Range(0, platforms.Length)];
        Bounds bounds = platform.bounds;

        float marginX = Mathf.Min(edgeMargin, bounds.extents.x);
        float marginZ = Mathf.Min(edgeMargin, bounds.extents.z);

        float x = Random.Range(bounds.min.x + marginX, bounds.max.x - marginX);
        float z = Random.Range(bounds.min.z + marginZ, bounds.max.z - marginZ);

        // 발판 위쪽에서 아래로 레이를 쏴서 실제 표면 높이를 구함
        Ray ray = new Ray(new Vector3(x, bounds.max.y + 10f, z), Vector3.down);
        if (platform.Raycast(ray, out RaycastHit hit, bounds.size.y + 20f))
        {
            point = hit.point + Vector3.up * heightOffset;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    private void OnItemPicked(Item item)
    {
        itemList.Remove(item);
    }
}
