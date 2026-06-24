using UnityEngine;

public class DoorPowerReceiver : MonoBehaviour, IElectricInteractable
{
    [Header("문 상태")]
    [SerializeField] private bool isOpen = false;

    [Header("문 이동 설정")]
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Vector3 openOffset = new Vector3(0f, 3f, 0f);
    [SerializeField] private float openSpeed = 3f;

    [Header("디버그")]
    [SerializeField] private bool showDebugLog = true;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    public bool IsOpen => isOpen;

    private void Awake()
    {
        if (doorTransform == null)
        {
            doorTransform = transform;
        }

        closedPosition = doorTransform.position;
        openPosition = closedPosition + openOffset;
    }

    private void Update()
    {
        if (!isOpen)
        {
            return;
        }

        doorTransform.position = Vector3.MoveTowards(
            doorTransform.position,
            openPosition,
            openSpeed * Time.deltaTime
        );
    }

    public void OnElectricContact(ElectricInteractionDetector electricSource)
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (isOpen)
        {
            if (showDebugLog)
            {
                Debug.Log("[Door Power] 이미 열린 문입니다: " + gameObject.name);
            }

            return;
        }

        isOpen = true;

        if (showDebugLog)
        {
            Debug.Log("[Door Power] 전기 신호로 문 열림: " + gameObject.name);
        }
    }
}
