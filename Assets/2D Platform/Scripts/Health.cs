using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] public float MaxCapacity { get; private set; }

    public event UnityAction Changed;

    public float Current { get; private set; }

    private void OnValidate()
    {
        if (MaxCapacity <= 0)
        {
            MaxCapacity = 5;
        }

        if (Current > MaxCapacity || Current <= 0)
        {
            Current = MaxCapacity;
        }
    }

    protected void Change(float health)
    {
        Current += health;
        Changed?.Invoke();
    }
}
