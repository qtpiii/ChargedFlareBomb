using RWCustom;
using Noise;
using UnityEngine;

namespace RedFlashbang
{
    public class RedFlashbang : FlareBomb
    {
        public RedFlashbang(AbstractPhysicalObject abstractPhysicalObject, World world) : base(abstractPhysicalObject, world)
        {
            this.color = new Color(1f, 0f, 0.1f);
        }

        public override void Update(bool eu)
        {
            base.Update(eu);
            
            if (this.burning > 1f)
            {
                this.room.AddObject(new Explosion(this.room, this, this.firstChunk.pos, 7, 250f, 6.2f, 2f, 280f, 0.25f, this.thrownBy, 0.7f, 160f, 1f));
                this.room.PlaySound(SoundID.Bomb_Explode, this.firstChunk.pos);
                this.room.InGameNoise(new InGameNoise(this.firstChunk.pos, 9000f, this, 1f));
                this.Destroy();
            }
        }

    }
}
