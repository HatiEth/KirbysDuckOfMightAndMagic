using UnityEngine;
using System.Collections;

public class EndSchild : MonoBehaviour, ICanBeShot {

    [SerializeField]
    private string playerTag = "player";

    private bool triggered = false;
    private new AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // CALL THIS ON IgotHit
    public void Laugh()
    {
        DialogHandler.instance.StartDialog(Dialogs.breadDialog);
    }

    public void HitMe(IProjectile projectile)
    {
        Laugh();
    }
}
