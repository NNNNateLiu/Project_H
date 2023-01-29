using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBox : MonoBehaviour
{
    public Transform teleportToTransform;
    private Animator cutsceneAnimator;
    public Transform targetSceneCameraTopRightBorder;
    public Transform targetSceneCameraBottomLeftBorder;

    private void Start()
    {
        cutsceneAnimator = GameObject.Find("Img_Cutscene").GetComponent<Animator>();
    }

    //当玩家走进的时候，传送到对应位置，播放转场动画
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("teleport");
            cutsceneAnimator.SetTrigger("CutsceneTrigger");
            cutsceneAnimator.GetComponent<UICutscene>().teleportToTransform = teleportToTransform;
            cutsceneAnimator.GetComponent<UICutscene>().targetSceneCameraTopRightBorder
                = targetSceneCameraTopRightBorder;
            cutsceneAnimator.GetComponent<UICutscene>().targetSceneCameraBottomLeftBorder
                = targetSceneCameraBottomLeftBorder;
        }
    }
}
