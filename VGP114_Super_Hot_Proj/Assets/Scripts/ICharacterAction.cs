using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAction
{
    void TakeDamage(float dmg);
    void Attack();
}
