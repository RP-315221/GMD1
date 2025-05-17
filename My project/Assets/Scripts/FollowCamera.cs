using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-1.7f, 3.4f, 3.2f);

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(35, 65, 0); // fixed angle
        }
    }
}

