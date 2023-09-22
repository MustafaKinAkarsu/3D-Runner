using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffDebuffManager
{
    public void Activate();
    public IEnumerator DisableAfterDuration(float duration);
}
