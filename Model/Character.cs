﻿using System.Runtime.CompilerServices;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Character
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        public Vector Position { get; set; }
        public Vector Direction { get; set; }
        public Vector Speed { get; set; }
        public Vector Velocity { get; set; }

        public Character(int health, int damage, Vector position, Vector speed, Vector velocity)
        {
            IsAlive = true;
            Health = health;
            Damage = damage;
            Position = position;
            Speed = speed;
            Velocity = velocity;
        }

        public virtual void Hit(Character another)
        {
            another.TakeDamage(Damage);
        }

        private void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Update(Vector mousePosition)
        {
            Speed = Speed.Rotate(mousePosition.Angle);
            Position += Speed;
            Speed += Velocity;

            if (Health <= 0)
                IsAlive = false;
        }
    }
}