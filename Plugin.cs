using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using Fisobs.Core;
using BepInEx.Logging;
using static Pom.Pom;

namespace ChargedFlareBomb
{
    [BepInPlugin(MOD_ID, "Charged Flare Bombs", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "qtpi.charged-flare-bombs";

        public void OnEnable()
        {
            try
            {
                RegisterFisobs();
                RegisterPOM();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RegisterFisobs()
        {
            Content.Register(new ChargedFlareBombFisob());
        }

        public void RegisterPOM()
        {
            RegisterManagedObject<ChargedFlareBombObject, ChargedFlareBombData, ManagedRepresentation>("Charged Flare Bomb", null);
        }
    }
}
