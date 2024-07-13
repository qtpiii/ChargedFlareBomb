using Fisobs.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargedFlashbang
{
    public class ChargedFlashbangProperties : ItemProperties
    {
        public override void Throwable(Player player, ref bool throwable) => throwable = true;

        public override void Grabability(Player player, ref Player.ObjectGrabability grabability)
        {
            grabability = Player.ObjectGrabability.OneHand;
        }

        public override void LethalWeapon(Scavenger scav, ref bool isLethal) => isLethal = true;

        public override void ScavWeaponPickupScore(Scavenger scav, ref int score) => score = 4;

        public override void ScavCollectScore(Scavenger scav, ref int score) => score = 4;

        public override void ScavWeaponUseScore(Scavenger scav, ref int score) => score = 2;

    }
}
