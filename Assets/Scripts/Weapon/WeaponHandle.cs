using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandle : MonoBehaviour
{
    [Header("Weapon Handle")]
    public WeaponItem initialWeapon;

    [Header("Hand")]
    public Transform rightHand;

    private void Start()
    {
        SetWeapon(initialWeapon);
    }

    public void SetWeapon(WeaponItem item)
    {
        for (int i = rightHand.childCount - 1; i >= 0; i--)
        {
            if (rightHand.GetChild(i).TryGetComponent(out Weapon weapon))
            {
                Destroy(weapon.gameObject);
            }
        }

        Inventory.Instance.AddItem(item);
        var wObj = Instantiate(item.weapon);

        wObj.transform.SetParent(rightHand);
        wObj.transform.localPosition = item.weapon.transform.position + item.positionOffset;
        wObj.transform.localRotation = Quaternion.Euler(transform.forward + item.rotationOffset);
        wObj.name = item.weapon.name;
        wObj.ItemInfo(item);
    }
}
