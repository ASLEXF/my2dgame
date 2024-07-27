using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    int damage;
    int maxDamage;  // ���ڼ��������˺�
    float distance;  // Զ�̹�������
    float attackInternal = 0f;  // ������С���

    bool isTurnInstant;  // ����ͬ���򹥻�ʱ���Ƿ�˲��ת��
    bool hasChargeTime;  // �Ƿ�����������

    float maxChargeTime;  // �������ʱ��

    public int attackNumber;  // ��󹥻�����

    public WeaponBase()
    {

    }

    int GetDamage()
    {
        if (hasChargeTime)
        {
            // TODO����������ʱ������˺�
            return (int)this.damage;
        }
        else
            return this.damage;
    }
}
