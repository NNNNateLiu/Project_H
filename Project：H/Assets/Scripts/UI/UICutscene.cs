using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICutscene : MonoBehaviour
{
    public Transform teleportToTransform;
    public Transform targetSceneCameraTopRightBorder;
    public Transform targetSceneCameraBottomLeftBorder;
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportPlayerToPosition()
    {
        player.transform.position = teleportToTransform.position;
        Camera.main.GetComponent<CameraController>().topRightBorder = targetSceneCameraTopRightBorder;
        Camera.main.GetComponent<CameraController>().bottomLeftBorder = targetSceneCameraBottomLeftBorder;
    }
}
