using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Vector3 cameraPos;
    [SerializeField] BoxCollider2D worldSize;
    // offset : 중심점 위치

    Camera camera;
    Transform target;
    float minX;
    float maxX;
    float minY;
    float maxY;

    private void Start() {
        target = FindObjectOfType<PlayerController>().transform;
        camera = GetComponent<Camera>();

        float halfScreen = camera.orthographicSize * camera.aspect;
        Debug.Log( halfScreen );
        minX = ((worldSize.offset.x) - (worldSize.size.x*0.5f)) + halfScreen;
        Debug.Log(minX);
        maxX = ((worldSize.size.x*0.5f) + (worldSize.offset.x)) - halfScreen;
        Debug.Log(maxX);

        float halfScreenY = camera.orthographicSize;
        minY = (worldSize.offset.y - worldSize.size.y * 0.5f) + halfScreenY;
        maxY = (worldSize.offset.y + worldSize.size.y * 0.5f) - halfScreenY;
    }
    private void Update() {
        Vector3 targetPos = target.position;
        Vector3 newCameraPos = targetPos + cameraPos;

        if(newCameraPos.x < minX)
        {
            newCameraPos.x = minX;
        }
        if(newCameraPos.x > maxX)
        {
            newCameraPos.x = maxX;
        }

        if(newCameraPos.y < minY)
        {
            newCameraPos.y = minY;
        }
        if(newCameraPos.y > maxY)
        {
            newCameraPos.y = maxY;
        }

        transform.position = Vector3.Lerp(transform.position, newCameraPos, 0.05f);
    }
}
