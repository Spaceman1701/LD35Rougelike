using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface DamageListener
{
    void OnDamageTaken(float damage); //Triggered before damage is dealt
}

