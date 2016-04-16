using UnityEngine;
using System.Collections;

public class Talking : MonoBehaviour {

    [SerializeField]
    private string m_stringText = "default";

    private Transform m_transThis;
    private Transform m_transOffset;

    void Awake()
    {
        m_transThis = GetComponent<Transform>();
        m_transOffset = m_transThis.FindChild("TalkingOffset");
    }

    void Update()
    {

    }
}
