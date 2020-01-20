using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TypeEffect
{
    Eff_Coin,
    Eff_Block_Impact,
    Eff_Boss_Explosion,
    Eff_Win,
    Eff_Hit_Enemies,
    Eff_HypeMode,
    Eff_Jump,
    Eff_Perfect_X1,
    Eff_Perfect_X2,
    Eff_Perfect_X3,
    Eff_Perfect_X4,
    Eff_StarExplosion,
    Eff_WarningEnemy,
    Eff_WarningBall,
    Eff_CollisionCoin,
    Eff_BlockBoom_Explosion,
    Eff_Oil
}

public class EffectController : Singleton<EffectController>
{
    public List<EffectObject> _effects = new List<EffectObject>();
    private Dictionary<TypeEffect,List<EffectObject>> _mapper = new Dictionary<TypeEffect, List<EffectObject>>();

    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    private void Init()
    {
        foreach (EffectObject item in _effects)
        {
            if (_mapper.ContainsKey(item.Type) == false)
            {
                _mapper.Add(item.Type, new List<EffectObject>());
                _mapper[item.Type].Add(item);
            }
            for (int i = 0; i < item.CountInit-1; i++)
            {
                EffectObject effectObject = Instantiate(item, transform) as EffectObject;
                _mapper[item.Type].Add(effectObject);
            }
        }
    }

    public GameObject PlayEffect(TypeEffect type, Vector3 pos, Vector3 rot, float time = 1f)
    {
        bool isPool = false;
        for (int j = 0; j < _mapper[type].Count; j++)
        {
            EffectObject efobj2 = _mapper[type][j];
            if (efobj2.getAction() == false)
            {
                efobj2.ActionEffect(pos, rot);
                isPool = true;
                if (time != 0)
                {
                    StartCoroutine(WatingHideEffect(efobj2, time));
                }
                return efobj2.gameObject;
            }
        }
        if (isPool == false)
        {
            Debug.LogWarning("PLEASE ADD MORE POOL: " + type.ToString());
            EffectObject effectObject = Instantiate(_mapper[type][0], transform) as EffectObject;
            effectObject.Hide();
            effectObject.ActionEffect(pos, rot);
            if (time != 0)
            {
                StartCoroutine(WatingHideEffect(effectObject, time));
            }
            _mapper[type].Add(effectObject);
            return effectObject.gameObject;
        }
        Debug.LogError("Not find this effect");
        return null;
    }

    public void HideEffectOne(TypeEffect type)
    {
        for (int i = 0; i < _mapper[type].Count; i++)
        {
            if (_mapper[type][i].getAction())
                _mapper[type][i].Hide();
        }
    }

    public void HideEffectAll()
    {
        for (int i = 0; i < _effects.Count; i++)
        {
            for (int j = 0; j < _mapper[_effects[i].Type].Count; j++)
            {
                _mapper[_effects[i].Type][j].Hide();
            }
        }
    }

    IEnumerator WatingHideEffect(EffectObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.Hide();
    }
}