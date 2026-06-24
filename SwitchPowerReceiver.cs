using UnityEngine;
using UnityEngine.Events;

public class SwitchPowerReceiver : MonoBehaviour, IElectricInteractable
{
    [Header("스위치 상태")]
    [SerializeField] private bool isActivated = false;

    [Header("한 번만 작동할지 여부")]
    [SerializeField] private bool activateOnlyOnce = true;

    [Header("전기 접촉 시 실행할 이벤트")]
    [SerializeField] private UnityEvent onActivated;

    [Header("디버그")]
    [SerializeField] private bool showDebugLog = true;

    public bool IsActivated => isActivated;

    public void OnElectricContact(ElectricInteractionDetector electricSource)
    {
        ActivateSwitch();
    }

    private void ActivateSwitch()
    {
        if (isActivated && activateOnlyOnce)
        {
            if (showDebugLog)
            {
                Debug.Log("[Switch Power] 이미 작동한 스위치입니다: " + gameObject.name);
            }

            return;
        }

        isActivated = true;

        if (showDebugLog)
        {
            Debug.Log("[Switch Power] 전기 신호로 스위치 작동: " + gameObject.name);
        }

        onActivated?.Invoke();
    }

    public void ResetSwitch()
    {
        isActivated = false;

        if (showDebugLog)
        {
            Debug.Log("[Switch Power] 스위치 초기화: " + gameObject.name);
        }
    }
}
