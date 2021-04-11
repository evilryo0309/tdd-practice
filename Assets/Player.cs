using System;
using UnityEngine;

public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; private set; }

    public event EventHandler<HealedEventArgs> Healed;
    public event EventHandler<DamagedEventArgs> Damaged;

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException("maximumHealth");
        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        int newHealth = Mathf.Min(CurrentHealth + amount, MaximumHealth);
        if (Healed != null)
            Healed(this, new HealedEventArgs(newHealth - CurrentHealth));
        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        int newHealth = Mathf.Max(CurrentHealth - amount, 0);
        if (Damaged != null)
            Damaged(this, new DamagedEventArgs(CurrentHealth - newHealth));
        CurrentHealth = newHealth;
    }

    public class HealedEventArgs : EventArgs
    {
        public HealedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }

    public class DamagedEventArgs:EventArgs
    {
        public DamagedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }
}
