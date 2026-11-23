using UnityEngine;

public class Gun : MonoBehaviour
{
    // 총을 발사하는 로직을 가지고 있어야 함
    // shootPosition을 찾아서 
    // bullet 을 shootPosition 에 소환

    private ShootPosition shootPosition = null;

    private AudioSource source = null;

    [SerializeField] private GameObject bullet = null;

    private void Awake()
    {
        shootPosition = GetComponentInChildren<ShootPosition>();
        source = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        // bullet 을 shootPosition 에 소환
        Instantiate(bullet, shootPosition.transform.position, shootPosition.transform.rotation);
        source.Play();
    }
}
