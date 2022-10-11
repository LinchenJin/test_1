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
            // 求出滑屏距离（新添加）
            if (Input.GetMouseButtonDown(0))
            {
                // 点击鼠标时的坐标
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // 松开鼠标时的坐标
                endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;
                //将滑屏距离转换为初始速度
                RotationSpeed += swipeLength;
                SwipeCount--;
            }
        }
   
        if (SwipeCount >= 0)
        {
            // 按旋转速度改变转盘的角度
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
           
            // 转速计算
            CurrentRotationRate = Mathf.FloorToInt( RotationSpeed /6);

            //圈数计算
            v3 += new Vector3(0, 0, RotationSpeed * Time.deltaTime);
            SpinsCount = Mathf.FloorToInt(v3.z / 360);

            // 陀螺减速
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
