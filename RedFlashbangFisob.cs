using Fisobs.Core;
using Fisobs.Items;
using Fisobs.Properties;
using Fisobs.Sandbox;
using JetBrains.Annotations;
using UnityEngine;

namespace RedFlashbang
{
    sealed class RedFlashbangFisob : Fisob
    {
        public static readonly AbstractPhysicalObject.AbstractObjectType AbstractRedFlashbang = new("Red Flashbang", true);
        public static readonly MultiplayerUnlocks.SandboxUnlockID mRedFlashbang = new("Red Flashbang", true);

        public RedFlashbangFisob() : base(AbstractRedFlashbang)
        {
            Icon = new SimpleIcon("Symbol_FlashBomb", new Color(1f, 0f, 0.1f));

            SandboxPerformanceCost = new(linear: 0.2f, 0f);

            RegisterUnlock(mRedFlashbang, parent: MultiplayerUnlocks.SandboxUnlockID.FlareBomb, data: 0);
        }
        public override AbstractPhysicalObject Parse(World world, EntitySaveData entitySaveData, SandboxUnlock unlock)
        {
            string[] p = entitySaveData.CustomData.Split(';');

            if (p.Length < 2)
            {
                p = new string[2];
            }

            var result = new RedFlashbangAbstract(world, entitySaveData.Pos, entitySaveData.ID)
            {
                scaleX = float.TryParse(p[0], out var x) ? x : 1,
                scaleY = float.TryParse(p[1], out var y) ? y : 1,
            };

            return result;

        }

        private static readonly RedFlashbangProperties properties = new();

        public override ItemProperties Properties(PhysicalObject forObject)
        {
            return properties;
        }

    }
}
