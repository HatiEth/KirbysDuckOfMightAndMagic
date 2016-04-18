using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Collections;

public class GlowEffect : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private float delay_beginning;
    [SerializeField]
    private float delay_end;
    [SerializeField]
    private float Threshold;
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private float altBeginning;
    [SerializeField]
    private float altEnd;

    private Image img;
    private float beginning, end;
    private bool toBeginning = true;
    private Transform _transform;
    private Rigidbody2D _rb;

    private float currentLerptime = 0f;
    private float delayTimer = 0f;
    private bool delaying = false;

    void Awake()
    {
        beginning = altBeginning;
        end = altEnd;
        img = GetComponent<Image>();
    }

    void Update()
    {
        currentLerptime += Time.deltaTime;
        if (currentLerptime > duration)
            currentLerptime = duration;

        float t = currentLerptime / duration;
        t = curve.Evaluate(t);

        if (toBeginning) {
            img.color = new Color(1f, 1f, 1f, Mathf.Lerp(end, beginning, t));

        }
        else {
            img.color = new Color(1f, 1f, 1f, Mathf.Lerp(beginning, end, t));
        }

        if ((1f - t) < Threshold) {
            delaying = true;
        }

        if (delaying) {
            delayTimer += Time.deltaTime;

            if (toBeginning) {
                if (delayTimer > delay_beginning) {
                    ResetTimer();
                }
            }
            else {
                if (delayTimer > delay_end) {
                    ResetTimer();
                }
            }
        }
    }

    void ResetTimer()
    {
        toBeginning = !toBeginning;
        currentLerptime = 0f;
        delaying = false;
        delayTimer = 0f;
    }
}