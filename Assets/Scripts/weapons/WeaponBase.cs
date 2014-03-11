using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    private bool isResponsive = false;

    public void SetResponsive(bool isResponsive)
    {
        this.isResponsive = isResponsive;
    }

    public bool IsResponsive()
    {
        return isResponsive;
    }
}
