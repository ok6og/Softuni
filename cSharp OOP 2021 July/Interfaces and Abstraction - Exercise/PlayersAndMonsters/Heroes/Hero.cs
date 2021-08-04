﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Heroes
{
    public class Hero
    {
        public string Username { get; private set; }
        public int Level { get; private set; }

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
