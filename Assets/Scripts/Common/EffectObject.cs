using UnityEngine;
using System.Collections;

public class EffectObject : MonoBehaviour
{
    [SerializeField] private TypeEffect _type;
    [SerializeField] private int _countInit = 1;

    public TypeEffect Type { get { return _type; } }
    public int CountInit { get { return _countInit; } }

    public void ActionEffect(Vector3 pos , Vector3 rot)
    {
        gameObject.transform.position = pos;
        gameObject.transform.rotation = Quaternion.Euler(rot);
        gameObject.SetActive(true);
    }

    public bool getAction()
    {
        return gameObject.activeSelf;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
