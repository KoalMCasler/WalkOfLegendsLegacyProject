﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkOfLegends
{
    internal abstract class Item
    {

        public Map map;
        public Player player;
        public UI ui;
        public char Char;
        public string name;
        public int posX;
        public int posY;
        public bool delete;

        public Item(Map map, Player player, UI ui)
        {
            this.map = map;
            this.player = player;
            this.ui = ui;
        }

        public abstract void DoYourJob();

        public abstract void Update();

        public abstract void Draw();

    }
}
