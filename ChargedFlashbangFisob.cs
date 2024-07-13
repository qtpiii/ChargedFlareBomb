using Fisobs.Core;
using Fisobs.Items;
using Fisobs.Properties;
using Fisobs.Sandbox;
using JetBrains.Annotations;
using System.Xml.XPath;
using UnityEngine;

namespace ChargedFlashbang
{
    sealed class ChargedFlashbangFisob : Fisob
    {
        public static readonly AbstractPhysicalObject.AbstractObjectType AbstractChargedFlashbang = new("ChargedFlashbang", true);
        public static readonly MultiplayerUnlocks.SandboxUnlockID ChargedFlashbang = new("ChargedFlashbang", true);

        public ChargedFlashbangFisob() : base(AbstractChargedFlashbang)
        {
            Icon = new SimpleIcon("Symbol_FlashBomb", new Color(1f, 0.8f, 0.3f));

            SandboxPerformanceCost = new(linear: 0.2f, 0f);

            RegisterUnlock(ChargedFlashbang, parent: MultiplayerUnlocks.SandboxUnlockID.FlareBomb, data: 0);
        }


        private static readonly ChargedFlashbangProperties properties = new();

        public override ItemProperties Properties(PhysicalObject forObject)
        {
            return properties;
        }

        public override AbstractPhysicalObject Parse(World world, EntitySaveData entitySaveData, SandboxUnlock unlock)
        {
            int origRoom = 0;
            int placedObjectIndex = 0;
            ChargedFlashbangAbstract result = new(world, null, entitySaveData.Pos, entitySaveData.ID, origRoom, placedObjectIndex, null);
            return result;
        }
    }
}
