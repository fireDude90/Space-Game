﻿using System;
using System.Collections.Generic;
using System.Timers;

using SFML.Graphics;
using SFML.Window;

namespace SpaceGame {
    public class Starfield {
        private List<Tuple<int, int, int>> stars = new List<Tuple<int, int, int>>();
        private int offsetX = 0, offsetY = 0;
        private Texture texture1, texture2, texture3;

        private int count;
        private Color color;

        /// <summary>
        /// Initializes a new Starfield
        /// </summary>
        /// <param name="count">Amount of stars</param>
        /// <param name="color">Star color</param>
        /// <param name="refreshRate">Time between refreshes (in seconds)</param>
        public Starfield(int count, Color color, float refreshRate) {
            texture1 = new Texture(new Image(1, 1, color));
            texture2 = new Texture(new Image(2, 2, color));
            texture3 = new Texture(new Image(3, 3, color));

            Random random = new Random();

            this.count = count;
            this.color = color;

            for (int i = 0; i < count; i++) {
                stars.Add(Tuple.Create(random.Next(Game.WindowWidth), random.Next(Game.WindowHeight), random.Next(0, 3)));
            }
        }


        public void Draw(ref RenderWindow window) {
            foreach (Tuple<int, int, int> tuple in stars) {
                Sprite sprite = new Sprite();

                switch (tuple.Item3) {
                    case 0:
                        sprite = new Sprite(texture1);
                        break;

                    case 1:
                        sprite = new Sprite(texture2);
                        break;

                    case 2:
                        sprite = new Sprite(texture3);
                        break;
                }
                sprite.Position = new Vector2f(tuple.Item1 + offsetX, tuple.Item2 + offsetY);

                window.Draw(sprite);
            }
        }
    }
}