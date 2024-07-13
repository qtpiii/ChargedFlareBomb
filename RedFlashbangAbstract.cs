using Fisobs.Core;
using UnityEngine;

namespace RedFlashbang
{
    sealed class RedFlashbangAbstract : AbstractPhysicalObject
    {
        public RedFlashbangAbstract(World world, WorldCoordinate pos, EntityID ID) : base(world, RedFlashbangFisob.AbstractRedFlashbang, null, pos, ID)
        {
            scaleX = 1.0f;
            scaleY = 1.0f;
        }

        public override void Realize()
        {
            base.Realize();
            if(realizedObject == null)
            {
                realizedObject = new RedFlashbang(this, world);
            }
        }

        public float scaleX;
        public float scaleY;

        public override string ToString()
        {
            return this.SaveToString($"{scaleX};{scaleY}");
        }
    }

}
