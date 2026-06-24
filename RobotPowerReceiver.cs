using UnityEngine;

public class RobotPowerReceiver : MonoBehaviour, IElectricInteractable
{
    [Header("로봇 전기 상태")]
    [SerializeField] private bool isPowered = false;

    [Header("디버그")]
    [SerializeField] private bool showDebugLog = true;

    public bool IsPowered => isPowered;

    public void OnElectricContact(ElectricInteractionDetector electricSource)
    {
        PowerOnRobot(electricSource);
    }

    private void PowerOnRobot(ElectricInteractionDetector electricSource)
    {
        if (isPowered)
        {
            if (showDebugLog)
            {
                Debug.Log("[Robot Power] 이미 전기가 들어온 로봇입니다: " + gameObject.name);
            }

            return;
        }

        isPowered = true;

        if (showDebugLog)
        {
            Debug.Log("[Robot Power] 로봇에 전기 접촉. 로봇 제어 모드 진입 준비: " + gameObject.name);
        }

        // 나중에 여기에 로봇 탑승 / 조종 시작 코드를 연결하면 됨.
        // 예: StartRobotControl(electricSource);
    }
}
