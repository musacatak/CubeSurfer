using UnityEngine;
using DG.Tweening;
public class PlayerAnimatorController : MonoBehaviour
{
    [Header("References")]
    Animator anim;
    bool isDeathTriggered = false;

    MovementController moveControl;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Jump()
    {
        anim.SetBool("Falling", true);

    }

    public void Landed()
    {
        anim.SetBool("Falling", false);
    }

    public void Dance()
    {
        anim.ResetTrigger("Dance");
        anim.SetTrigger("Dance");
    }

    public void StopPlayer()
    {
        moveControl.verticalSpeed = 0;
        moveControl.horizontalSpeed = 0;
    }
}
