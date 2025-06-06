using UnityEngine;

public class EyeballFloat : MonoBehaviour
{
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;

    private float startY;

    void Start()
    {
        startY = transform.localPosition.y;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        Vector3 localPos = transform.localPosition;
        localPos.y = newY;
        transform.localPosition = localPos;
    }
}
