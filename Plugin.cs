using System;
using BepInEx;
using UnityEngine;
using Fisobs.Core;
using static Pom.Pom;
using MoreSlugcats;
using MonoMod.Cil;
using System.Reflection.Emit;
using Mono.Cecil;

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

                On.Player.SwallowObject += Player_SwallowObject;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Player_SwallowObject(On.Player.orig_SwallowObject orig, Player self, int grasp)
        {
            orig(self, grasp);
            if (ModManager.MSC && self.SlugCatClass == MoreSlugcatsEnums.SlugcatStatsName.Artificer && self.FoodInStomach > 0)
            {
                if (self.objectInStomach.type == AbstractPhysicalObject.AbstractObjectType.Lantern)
                {
                    self.objectInStomach = new ChargedFlareBombAbstract(self.room.world, null, self.room.GetWorldCoordinate(self.mainBodyChunk.pos), self.room.game.GetNewID(), 0, 0, null);
                    self.SubtractFood(1);
                }
            }
        }

        public void RegisterFisobs()
        {
            Content.Register(new ChargedFlareBombFisob());
        }

        public void RegisterPOM()
        {
            RegisterManagedObject<ChargedFlareBombObject, ChargedFlareBombData, ManagedRepresentation>("ChargedFlareBomb", null);
        }
    }
}
