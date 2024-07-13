using RWCustom;
using Noise;
using UnityEngine;
using Smoke;

namespace ChargedFlashbang
{
    public class ChargedFlashbang : FlareBomb
    {
        public ChargedFlashbang(AbstractConsumable abstractConsumable, World world) : base(abstractConsumable, world)
        {
            this.color = new Color(1f, 0.3f, 0.1f);
            this.bounce = 0.4f;
        }

        public override void Update(bool eu)
        {
            base.Update(eu);
            
            if (this.burning > 1f)
            {
                this.room.AddObject(new SootMark(this.room, this.firstChunk.pos, 80f, true));
                this.room.AddObject(new Explosion(this.room, this, this.firstChunk.pos, 7, 250f, 6.2f, 2f, 280f, 0.25f, this.thrownBy, 0.7f, 160f, 1f));
                this.room.AddObject(new Explosion.ExplosionLight(this.firstChunk.pos, 280f, 1f, 7, this.color));
                this.room.AddObject(new Explosion.ExplosionLight(this.firstChunk.pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                this.room.AddObject(new ExplosionSpikes(this.room, this.firstChunk.pos, 14, 30f, 9f, 7f, 170f, this.color));
                this.room.AddObject(new ShockWave(this.firstChunk.pos, 330f, 0.045f, 5, false));

                for (int i = 0; i < 25; i++)
                {
                    Vector2 a = Custom.RNV();
                    if (this.room.GetTile(this.firstChunk.pos + a * 20f).Solid)
                    {
                        if (!this.room.GetTile(this.firstChunk.pos - a * 20f).Solid)
                        {
                            a *= -1f;
                        }
                        else
                        {
                            a = Custom.RNV();
                        }
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        this.room.AddObject(new Spark(this.firstChunk.pos + a * Mathf.Lerp(30f, 60f, UnityEngine.Random.value), a * Mathf.Lerp(7f, 38f, UnityEngine.Random.value) + Custom.RNV() * 20f * UnityEngine.Random.value, Color.Lerp(this.color, new Color(1f, 1f, 1f), UnityEngine.Random.value), null, 11, 28));
                    }
                    this.room.AddObject(new Explosion.FlashingSmoke(this.firstChunk.pos + a * 40f * UnityEngine.Random.value, a * Mathf.Lerp(4f, 20f, Mathf.Pow(UnityEngine.Random.value, 2f)), 1f + 0.05f * UnityEngine.Random.value, new Color(1f, 1f, 1f), this.color, UnityEngine.Random.Range(3, 11)));
                }

                if (this.smoke != null)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        this.smoke.EmitWithMyLifeTime(this.firstChunk.pos + Custom.RNV(), Custom.RNV() * UnityEngine.Random.value * 17f);
                    }
                }
                for (int l = 0; l < 6; l++)
                {
                    this.room.AddObject(new ScavengerBomb.BombFragment(this.firstChunk.pos, Custom.DegToVec(((float)l + UnityEngine.Random.value) / 6f * 360f) * Mathf.Lerp(18f, 38f, UnityEngine.Random.value)));
                }
                this.room.ScreenMovement(new Vector2?(this.firstChunk.pos), default(Vector2), 1.3f);
                for (int m = 0; m < this.abstractPhysicalObject.stuckObjects.Count; m++)
                {
                    this.abstractPhysicalObject.stuckObjects[m].Deactivate();
                }

                this.room.PlaySound(SoundID.Bomb_Explode, this.firstChunk.pos);
                this.room.InGameNoise(new InGameNoise(this.firstChunk.pos, 9000f, this, 1f));

                bool flag = this.firstChunk != null;
                for (int n = 0; n < 5; n++)
                {
                    if (this.room.GetTile(this.firstChunk.pos + Custom.fourDirectionsAndZero[n].ToVector2() * 20f).Solid)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    if (this.smoke == null)
                    {
                        this.smoke = new BombSmoke(this.room, this.firstChunk.pos, null, this.color);
                        this.room.AddObject(this.smoke);
                    }
                    if (this.firstChunk != null)
                    {
                        this.smoke.chunk = this.firstChunk;
                    }
                    else
                    {
                        this.smoke.chunk = null;
                        this.smoke.fadeIn = 1f;
                    }
                    this.smoke.pos = this.firstChunk.pos;
                    this.smoke.stationary = true;
                    this.smoke.DisconnectSmoke();
                }
                else if (this.smoke != null)
                {
                    this.smoke.Destroy();
                }
                this.Destroy();
            }
        }

        public BombSmoke smoke;

    }
}
