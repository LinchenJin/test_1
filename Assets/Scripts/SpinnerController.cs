using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpinnerController : MonoBehaviour
{
    public float RotationSpeed;
    public TextMeshProUGUI T_RotationRate;
    public TextMeshProUGUI T_Spins;
    public TextMeshProUGUI T_SwipeCount;

    private Vector2 startPos;
    private Vector2 endPos;

    private int SwipeCount;
    private int SpinsCount;
    private float CurrentRotationRate;
    private Vector3 v3;
    
    void Start()
    {
        RotationSpeed = 0;
        SwipeCount = 3;
    }
    void Update()
    {
        if (SwipeCount > 0)
        {
            // ����������루����ӣ�
            if (Input.GetMouseButtonDown(0))
            {
                // ������ʱ������
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // �ɿ����ʱ������
                endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;
                //����������ת��Ϊ��ʼ�ٶ�
                RotationSpeed += swipeLength;
                SwipeCount--;
            }
        }
   
        if (SwipeCount >= 0)
        {
            // ����ת�ٶȸı�ת�̵ĽǶ�
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
           
            // ת�ټ���
            CurrentRotationRate = Mathf.FloorToInt( RotationSpeed /6);

            //Ȧ������
            v3 += new Vector3(0, 0, RotationSpeed * Time.deltaTime);
            SpinsCount = Mathf.FloorToInt(v3.z / 360);

            // ���ݼ���
            RotationSpeed *= 0.998f;
            if (RotationSpeed < 0.01f)
            {
                RotationSpeed = 0;
            }
            
        }
            
        T_SwipeCount.text = SwipeCount.ToString();
        T_RotationRate.text = CurrentRotationRate.ToString();
        T_Spins.text = SpinsCount.ToString();

    }


}
