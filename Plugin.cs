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

                //IL.Player.SwallowObject += ArtiCraftChargedFlare;

                //On.Player.SwallowObject += Player_SwallowObject;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //i tried lol

        //private void ArtiCraftChargedFlare(ILContext il)
        //{
        //    ILCursor cursor = new(il);
        //    cursor.GotoNext(
        //        x => x.MatchLdarg(0),
        //        x => x.MatchLdfld<UpdatableAndDeletable>("room"),
        //        x => x.MatchLdfld<Room>("game"),
        //        x => x.MatchCallvirt<RainWorldGame>("GetNewID"),
        //        x => x.MatchNewobj<AbstractPhysicalObject>(),
        //        x => x.MatchStloc(0),
        //        x => x.MatchLdarg(0),
        //        x => x.MatchLdcI4(1),
        //        x => x.MatchCall<Player>("SubtractFood")
        //        );
        //    cursor.Index += 8;
        //    cursor.Emit(OpCodes.Br_S, );
        //}

        //private void Player_SwallowObject(On.Player.orig_SwallowObject orig, Player self, int grasp)
        //{
        //    orig(self, grasp);
        //    if (ModManager.MSC && self.SlugCatClass == MoreSlugcatsEnums.SlugcatStatsName.Artificer && self.FoodInStomach > 0)
        //    {
        //        if (self.abstractPhysicalObject.type == AbstractPhysicalObject.AbstractObjectType.Lantern)
        //        {
        //            self.abstractPhysicalObject = new AbstractPhysicalObject(self.room.world, ChargedFlareBombFisob.AbstractChargedFlareBomb, null, self.room.GetWorldCoordinate(self.mainBodyChunk.pos), self.room.game.GetNewID());
        //            self.SubtractFood(1);
        //        }
        //    }
        //}

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
