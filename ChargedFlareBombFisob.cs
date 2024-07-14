using Fisobs.Core;
using Fisobs.Items;
using Fisobs.Properties;
using Fisobs.Sandbox;
using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;

namespace ChargedFlareBomb
{
    sealed class ChargedFlareBombFisob : Fisob
    {
        public static readonly AbstractPhysicalObject.AbstractObjectType AbstractChargedFlareBomb = new("ChargedFlareBomb", true);
        public static readonly MultiplayerUnlocks.SandboxUnlockID ChargedFlareBomb = new("ChargedFlareBomb", true);

        public ChargedFlareBombFisob() : base(AbstractChargedFlareBomb)
        {
            Icon = new SimpleIcon("Symbol_FlashBomb", new Color(1f, 0.7f, 0.4f));

            SandboxPerformanceCost = new(linear: 0.2f, 0f);

            RegisterUnlock(ChargedFlareBomb, parent: MultiplayerUnlocks.SandboxUnlockID.FlareBomb, data: 0);
        }


        private static readonly ChargedFlareBombProperties properties = new();

        public override ItemProperties Properties(PhysicalObject forObject)
        {
            return properties;
        }

        public override AbstractPhysicalObject Parse(World world, EntitySaveData entitySaveData, SandboxUnlock unlock)
        {
            int origRoom = 0;
            int placedObjectIndex = 0;
            ChargedFlareBombAbstract result = new(world, null, entitySaveData.Pos, entitySaveData.ID, origRoom, placedObjectIndex, null);
            return result;
        }
    }
}
