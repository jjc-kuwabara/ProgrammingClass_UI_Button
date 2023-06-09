using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_hpNow = m_hpMax;
        m_hpgauge = HPGauge.CreateHPGauge(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        m_moveDirection = new Vector3(x, y, 0);

        if (m_moveDirection.magnitude > 1.0f)
        {
            m_moveDirection = m_moveDirection.normalized;
        }

        m_moveDistance = m_moveDirection * m_speed * Time.deltaTime;

        this.transform.position += m_moveDistance;
    }

    public void TakeDamage(int damage){
        m_hpNow += damage;

        if(m_hpNow >= m_hpMax){
            m_hpNow = m_hpMax;
        }
        if(m_hpNow <= m_hpMin){
            m_hpNow = m_hpMin;
            Destroy(this.gameObject);
        }

        float hpRate = (float)m_hpNow / m_hpMax;
        m_hpgauge.Refresh(hpRate);
    }    

    public float m_speed;
    [SerializeField]
    Vector3 m_moveDirection;
    [SerializeField]
    Vector3 m_moveDistance;

    [SerializeField]
    int m_hpMax;
    [SerializeField]
    int m_hpMin;
    [SerializeField]
    int m_hpNow;

    HPGauge m_hpgauge;    
}
