using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransitions : Transition
{
    [SerializeField] private float _timeToTransit;

    private float _currentTimeToTransit;

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentTimeToTransit = _timeToTransit;
    }

    private void Update()
    {
        if (NeedTransit)
            return;

        _currentTimeToTransit -= Time.deltaTime;

        if (_currentTimeToTransit <= 0)
            NeedTransit = true;
    }
}
