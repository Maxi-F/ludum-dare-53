using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PickableInterface
{
    void Illuminate();

    void UnIlluminate();

    void Disappear();

    string Name();
}
