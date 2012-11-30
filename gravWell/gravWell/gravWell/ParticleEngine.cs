using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Shooter.PhysicsObjects;

namespace Farseer331_Setup
{
    public class ParticleEngine
    {

        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<PhysicsParticleObject> particles;
        private List<Texture2D> textures;
        World pWorld;
      //  public PhysicsParticleObject particle;


        public ParticleEngine(List<Texture2D> textures, Vector2 location, World world)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<PhysicsParticleObject>();
            random = new Random();
            pWorld = world;
        }

       private void GenerateNewParticle()
        {
        
          
            Texture2D texture = textures[random.Next(textures.Count)];
            PhysicsParticleObject particle = new PhysicsParticleObject(pWorld, texture,Color.Red,EmitterLocation, new Vector2(1f,1f), 100f);
            particle.body.AngularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            particles.Add(particle);
           

        }


        public void Update(GameTime gameTime)
        {
            int total = 1;

            for (int i = 0; i < total; i++)
            {
                GenerateNewParticle();
            }

          /*  for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }*/
           pWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            
        }


    }
}
