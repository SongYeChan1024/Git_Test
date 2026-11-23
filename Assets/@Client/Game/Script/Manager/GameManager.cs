using System.Net.Sockets;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {

        private Player player = null;

        private EnemyManager enemyManager = null;

        private ItemManager itemManager = null;

        [SerializeField] private int score = 0;

        private UIManager uiManager;

        private void Awake()
        {
            player = GetComponentInChildren<Player>();
            enemyManager = GetComponentInChildren<EnemyManager>();
            itemManager = GetComponentInChildren<ItemManager>();
            uiManager = GetComponentInChildren<UIManager>();
        }

        private void Start()
        {
            player.Init(OnGameOver);
            enemyManager.Init(player, AddScore);
            itemManager.Init();
            uiManager.Init();
        }

        private void Cleargame()
        {
            uiManager.ShowGameClearUI();
            Time.timeScale = 0f;
        }

        private void OnGameOver()
        {
            uiManager.ShowGameOverUI();
            Time.timeScale = 0f;
        }

        private void AddScore(int score)
        {
            this.score += score;

            uiManager.UpdateScoreUI(this.score);

            if (this.score >= 100)
            {
                Cleargame();
            }
        }
        // 간단한 슈팅게임

        // Player, Enemy, Item

        // Player
        // WASD로 움직일 수 있어야 함
        // 마우스로 플레이어를 회전할 수 있게 해야 함
        // 마우스 왼쪽 버튼 누르면,
        // 총에서 총알이 나가야 함
        // 데미지 받는 기능도 필요함
        // 아이템을 먹을 수도 있어야 함

        // Enemy
        // 플레이어를 쫒아 와야 함
        // 일정 거리 안에 오면, Player를 공격해야 함
        // 데미지를 받을 수 있어야 함
        // 죽을 때, 게임 점수를 올려줘야 함

        // HealItem
        // 필드에 랜덤 생성
        // 플레이어와 닿으면, 플레이어에게 회복 효과를 부여 함

        // Game
        // 게임 클리어 (점수가 100점 이상 일 때)
        // 게임 종료 (플레이어가 죽었을 때)
        // 게임 시작 (시작 버튼을 눌렀을 때)
        // 게임에 관련된 모든 것 들을 관리

        // UI
        // 게임 시작, 게임 종료, 게임 클리어
        // UI를 띄워주는 역할을 할꺼임

    }
}
