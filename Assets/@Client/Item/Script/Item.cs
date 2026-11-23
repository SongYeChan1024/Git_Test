using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 플레이어가 닿으면 체력을 회복시켜 주는 아이템
    [SerializeField] private float healAmount = 20f;

    // 회전 연출 속도 (초당 각도)
    [SerializeField] private float rotateSpeed = 90f;

    private Action<Item> onItemPicked = null;

    // 플레이어 콜라이더가 여러 개면 같은 프레임에 OnTriggerEnter 가 여러 번 불리므로 중복 회복 방지
    private bool isPicked = false;

    public void Init(Action<Item> onItemPicked)
    {
        this.onItemPicked = onItemPicked;
    }

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player 의 콜라이더는 루트에 있지만, 자식 콜라이더에 닿아도 찾을 수 있도록 부모까지 검색
        Player player = other.GetComponentInParent<Player>();
        if (player == null || isPicked)
        {
            return;
        }

        isPicked = true;

        player.Heal(healAmount);

        onItemPicked?.Invoke(this);

        Destroy(gameObject);
    }
}
