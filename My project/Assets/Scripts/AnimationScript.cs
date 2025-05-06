using UnityEngine;

public class EyeballFloat : MonoBehaviour
{
    public float floatHeight = 0.5f;   // Max vertical offset
    public float floatSpeed = 1f;      // Speed of movement

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
