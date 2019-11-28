using Oxide.Core.Libraries.Covalence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Oxide.Plugins
{
  [Info("bounty", "Creators Club", 0.1)]
  [Description("Reward players with virtual currency on kill")]
  public class Bounty : RustPlugin
  {
    Core.MySql.Libraries.MySql sqlLibrary;
    Connection sqlConnection;
    public string CurrencyAmountPerKill { get; set; }


    void Init()
    {
      sqlLibrary = Interface.Oxide.GetLibrary<Core.MySql.Libraries.MySql>();
      sqlConnection = sqlLibrary.OpenDb("localhost", 3306, "umod", "username", "password", this);

      CurrencyAmountPerKill = 50;
    }

    void OnEntityDeath(EntityDeathEvent Event)
    {
      if (!Event.Entity.IsPlayer || !Event.KillingDamage.DamageSource.IsPlayer) return;

      string killer = Event.KillingDamage.DamageSource.Owner.Id;
      string verifyQuery = $"SELECT victim FROM kills WHERE killer={killer} AND victim={victim}";

      sqlLibrary.Query(verifyQuery, sqlConnection, list =>
      {
          if (list == null)
          {
            // Reward Player
            sqlLibrary.Query(verifyQuery, sqlConnection, list =>
            {

            }
          }
          else
          {
            // Player already killed.
          }
      });
    }
  }
}