using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    private Vector2 moveInput;
    private Vector3 moveDirection;

    void Update()
    {
        Vector2 filteredInput;

        // Filter out diagonal input
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            filteredInput = new Vector2(Mathf.Sign(moveInput.x), 0);
        }
        else
        {
            filteredInput = new Vector2(0, Mathf.Sign(moveInput.y));
        }

        moveDirection = new Vector3(filteredInput.x, 0f, filteredInput.y);

        // Apply movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }


    public void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
