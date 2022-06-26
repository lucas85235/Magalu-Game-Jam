using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class WeaponHandle : MonoBehaviour
{
    [Header("Weapon Handle")]
    public WeaponItem initialWeapon;

    [Header("Hand")]
    public Transform rightHand;

    private void Start()
    {
        // forech sobre a lista de items e verificar se existe algum do tipo arma
        // se tiver um equipar
        // se for mais de um liberar opção de equipar

        Inventory.Instance.AddItem(initialWeapon);
        var wObj = Instantiate(initialWeapon.weapon);

        wObj.transform.SetParent(rightHand);
        wObj.transform.localPosition = initialWeapon.weapon.transform.position + initialWeapon.positionOffset;
        wObj.transform.localRotation = Quaternion.Euler(transform.forward + initialWeapon.rotationOffset);
        wObj.name = initialWeapon.weapon.name;
    }

    public void SetWeapon()
    {
        for (int i = rightHand.childCount; i > 0; i--)
        {
            if (rightHand.GetChild(i).TryGetComponent(out Weapon weapon))
            {
                Destroy(weapon.gameObject);
            }
        }

        Inventory.Instance.AddItem(initialWeapon);
        var wObj = Instantiate(initialWeapon.weapon);

        wObj.transform.SetParent(rightHand);
        wObj.transform.localPosition = initialWeapon.weapon.transform.position + initialWeapon.positionOffset;
        wObj.transform.localRotation = Quaternion.Euler(transform.forward + initialWeapon.rotationOffset);
        wObj.name = initialWeapon.weapon.name;
    }
}
