using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public DoorTrigger[] isButtonActive;

    [SerializeField]
    private bool isOpen;

    public Transform OpenPosition;
    public Transform ClosePosition;

    private Vector3 openPosition;
    private Vector3 closePosition;

    public float DoorMoveTime;

    private void Start()
    {
        openPosition = new Vector3(OpenPosition.position.x, OpenPosition.position.y, OpenPosition.position.z);
        closePosition = new Vector3(ClosePosition.position.x, ClosePosition.position.y, ClosePosition.position.z);
    }
    
    // Update is called once per frame
    void Update()
    {
        isDoorOpen();

        if (isOpen)
            StartCoroutine(OpenDoorMechanism(DoorMoveTime));
        if (!isOpen && transform.position != closePosition)
            StartCoroutine(CloseDoorMechanism(DoorMoveTime));
    }

    void isDoorOpen()
    {
        if (AreTriggersActive())
            isOpen = true;
        else
            isOpen = false;
    }

    bool AreTriggersActive()
    {
        foreach (DoorTrigger button in isButtonActive)
        {
            if (button.isActiveButton)
                return true;
        }
        return false;
    }

    #region DoorMechanism
    IEnumerator OpenDoorMechanism(float TimeToMove)
    {
        float timer = 0;
        Vector3 startPosition = transform.position;

        while (timer < TimeToMove)
        {
            transform.position = Vector3.Lerp(startPosition, openPosition, timer / TimeToMove);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CloseDoorMechanism(float TimeToMove)
    {
        float timer = 0;
        Vector3 startPosition = transform.position;

        while (timer < TimeToMove)
        {
            transform.position = Vector3.Lerp(startPosition, closePosition, timer / TimeToMove);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion DoorMechanism
}
