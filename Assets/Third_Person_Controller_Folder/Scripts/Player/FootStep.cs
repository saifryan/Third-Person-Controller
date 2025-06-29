using System.Collections;
using System.Linq;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] Transform LeftFoot;
    [SerializeField] Transform RightFoot;

    void Start()
    {
        LeftFoot = GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "LeftFoot");
        RightFoot = GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "RightFoot");
    }

    // ----- Foot Step Sound Play -----
    public void LeftFootStopSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.FootStep);
        PoolingManager.Instance.GetFootStepParticle().transform.position = LeftFoot.position;
    }

    public void RightFootStopSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.FootStep);
        PoolingManager.Instance.GetFootStepParticle().transform.position = RightFoot.position;
    }

    // ----- Jump Sound Play -----
    public void JumpStartSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.JumpStart);
    }

    public void JumpEndSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.JumpLand);
        PoolingManager.Instance.GetFootStepParticle().transform.position = LeftFoot.position;
        PoolingManager.Instance.GetFootStepParticle().transform.position = RightFoot.position;
    }
}