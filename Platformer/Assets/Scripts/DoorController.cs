using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openHeight = 3f; // Высота, на которую поднимется дверь
    public float openSpeed = 2f; // Скорость открытия
    
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    public bool isOpen { get; private set; }
    private bool isMoving = false;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + Vector3.up * openHeight;
        isOpen = false;
    }

    public void OpenDoor()
    {
        if (!isOpen && !isMoving)
        {
            isMoving = true;
            isOpen = true;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            // Плавно перемещаем дверь вверх
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, openSpeed * Time.deltaTime);
            
            // Если дверь достигла целевой позиции, останавливаем движение
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}