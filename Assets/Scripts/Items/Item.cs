using UnityEngine;

[System.Serializable]
public class Item: MonoBehaviour
{
    public int id;
    public string itemName;
    public string description;
    public string icon;
    public bool isConsumable;
    public bool isSalable;
    public bool isMaterial;

    public Item(int id, string name, string description, string icon, bool isConsumable, bool isSalable)
    {
        this.id = id;
        this.itemName = name;
        this.description = description;
        this.icon = icon;
        this.isConsumable = isConsumable;
        this.isSalable = isSalable;
    }
}


public class WeaponItem: Item
{
    public int damage;
    public int additionalDamage;  // ���ڼ��������˺�
    public float distance;  // Զ�̹�������
    public float attackInternal;  // ������С���
    public bool isTurnInstant;  // ����ͬ���򹥻�ʱ���Ƿ�˲��ת��
    public bool hasChargingTime;  // �Ƿ�����������
    public float maxChargingTime;  // �������ʱ��
    public int attackNumber;  // ��󹥻�����

    public WeaponItem(int id, string name, string description, string icon, int damage, int additionalDamage, float distance, float attackInternal, bool isTurnInstant, bool hasChargingTime, float maxChargeTime, int attackNumber) : base(id, name, description, icon, false, false)
    {
        this.damage = damage;
        this.additionalDamage = additionalDamage;
        this.distance = distance;
        this.attackInternal = attackInternal;
        this.isTurnInstant = isTurnInstant;
        this.hasChargingTime = hasChargingTime;
        this.maxChargingTime = maxChargeTime;
        this.attackNumber = attackNumber;
    }

    public int GetChargingDamage(float intervalSeconds)
    {
        if (this.hasChargingTime)
        {
            return Mathf.RoundToInt(intervalSeconds > this.maxChargingTime ? this.additionalDamage : this.damage + intervalSeconds * this.additionalDamage / this.maxChargingTime);
        }
        else
        {
            return this.damage;
        }
    }
}

public class ComsumableItem: Item
{
    public int amount;

    public ComsumableItem(int id, string name, string description, string icon, int amount) : base(id, name, description, icon, true, true)
    {
        this.amount = amount;
    }

    public virtual void Use()
    {
        Debug.Log("Using Item: " + itemName);
    }
}

public class ImportantItem: Item
{
    public ImportantItem(int id, string name, string description, string icon) : base(id, name, description, icon, false, false)
    { }
}

public class MaterialItem: Item
{
    public int amount;

    public MaterialItem(int id, string name, string description, string icon, int amount) : base(id, name, description, icon, true, true)
    {
        this.amount = amount;
    }
}
