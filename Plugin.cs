using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using Fisobs.Core;
using BepInEx.Logging;

namespace RedFlashbang
{
    [BepInPlugin(MOD_ID, "Red Flashbang", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "qtpi.red-flashbang";

        public void OnEnable()
        {
            try
            {
                RegisterFisobs();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RegisterFisobs()
        {
            Content.Register(new RedFlashbangFisob());
        }
    }
}
