﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;

namespace Shooter.PhysicsObjects
{
    public class PhysicsParticleObject
    {
        // Because Farseer uses 1 unit = 1 meter we need to convert
        // between pixel coordinates and physics coordinates.
        // I've chosen to use the rule that 100 pixels is one meter.
        // We have to take care to convert between these two 
        // coordinate-sets wherever we mix them!

        public const float unitToPixel = 100.0f;
        public const float pixelToUnit = 1 / unitToPixel;

        public Body body;
        public Vector2 Position
        {
            get { return body.Position * unitToPixel; }
            set { body.Position = value * pixelToUnit; }
        }

        public Texture2D texture;

        public Color color;
        public Vector2 enginePosition;

        private Vector2 size;
        public Vector2 Size
        {
            get { return size * unitToPixel; }
            set { size = value * pixelToUnit; }
        }

        /// <param name="world">The farseer simulation this object should be part of</param>
        /// <param name="texture">The image that will be drawn at the place of the body</param>
        /// <param name="size">The size in pixels</param>
        /// <param name="mass">The mass in kilograms</param>
        public PhysicsParticleObject(World world, Texture2D texture,Color color, Vector2 enginePosition,  Vector2 size, float mass)
        {
            body = BodyFactory.CreateRectangle(world, size.X * pixelToUnit, size.Y * pixelToUnit, 1);
            body.BodyType = BodyType.Dynamic;

            this.Size = size;
            this.texture = texture;
            this.color = color;
            this.enginePosition = enginePosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
         
            spriteBatch.Draw(texture, enginePosition, null, color, 0, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), 1, SpriteEffects.None, 0);
        }
    }
}
