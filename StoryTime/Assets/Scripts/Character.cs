using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private GameObject m_leftHandBone;

    [SerializeField]
    private GameObject m_rightHandBone;

    public Animator Animator
    {
        get { return m_animator; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
