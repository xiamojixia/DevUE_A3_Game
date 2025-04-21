using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 小球
    public Vector3 offset = new Vector3(0f, 5f, -8f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // 根据小球朝向更新偏移
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 永远看向小球
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}