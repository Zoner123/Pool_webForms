﻿using System;
using System.Diagnostics;

namespace WindowsFormsApplication1
        public Cue cue;
        public HelpingLine hLine;

        private List<Ball> ResetGame()
        {
            return new List<Ball>()
            {
                //stredni radek
                new ColoredBall(Color.Yellow, false) {DefX = 850, DefY = 325},
                new ColoredBall(Color.Blue, false) {DefX = 900, DefY = 325 },
                new ColoredBall(Color.Red, false) {DefX = 950, DefY = 325 },
                new ColoredBall(Color.Purple, false) {DefX = 1000, DefY = 325 },
                //prvni horni
                new ColoredBall(Color.Orange, false) {DefX = 900, DefY = 375 },
                new ColoredBall(Color.Green, false) {DefX = 950, DefY = 375 },
                new ColoredBall(Color.DarkRed, false) {DefX = 1000, DefY = 375 },
                //druhy horni
                new ColoredBall(Color.Black, false)  {DefX = 950, DefY = 425 },
                new ColoredBall(Color.Yellow, true) {DefX = 1000, DefY = 425 },
                //treti horni
                new ColoredBall(Color.Blue, true) {DefX = 1000, DefY = 475 },
                //prvni dolni
                new ColoredBall(Color.Red, true) {DefX = 900, DefY = 275 },
                new ColoredBall(Color.Purple, true) {DefX = 950, DefY = 275 },
                new ColoredBall(Color.Orange, true) {DefX = 1000, DefY = 275 },
                //druhy dolni
                new ColoredBall(Color.Green, true) {DefX = 950, DefY = 225 },
                new ColoredBall(Color.DarkRed, true) {DefX = 1000, DefY = 225 },
                //treti dole
                new ColoredBall(Color.Black, true) {DefX = 1000, DefY = 175 },

                new Hole () {DefX = 60, DefY = 58 },
                new Hole () {DefX = 650, DefY = 50 },
                new Hole () {DefX = 1238, DefY = 57 },

                new Hole () {DefX = 60, DefY = 621 },
                new Hole () {DefX = 650, DefY = 625 },
                new Hole () {DefX = 1238, DefY = 621 },
            };
        }

            cue = new Cue();
            hLine = new HelpingLine();
            {
                ball.ResetPosition();
            }

        public void AddBall(Ball b)
        }
            this.cue.Render(g);
            this.hLine.Render(g);

            for (int i = 0; i < this._balls_on_field.Count; i++)
            //pythagorus
            float xDifferece = b1.X - b2.X;
            float yDifferece = b1.Y - b2.Y;
            float hypotenuse2 = Convert.ToSingle(Math.Pow(xDifferece, 2) + Math.Pow(yDifferece, 2));


            if (Math.Sqrt(hypotenuse2) <= (b1.Radius + b2.Radius + b2.Radius))
            {

                if (b2 is Hole || b1 is Hole)
                {
                    Debug.WriteLine("ball is in the hole.");
                    b2.Vx = 0;
                    b2.Vy = 0;
                    b1.Vx = 0;
                    b1.Vy = 0;

                    if (b2 is Hole)
                    {
                        if (b1 is WhiteBall)
                            b1.ResetPosition();
                        else
                            _balls_on_field.Remove(b1);
                    }
                    else
                    {
                        if (b2 is WhiteBall)
                            b2.ResetPosition();
                        else
                            _balls_on_field.Remove(b2);
                    }

                }
                else
                {
                    float Vx = b2.Vx - b1.Vx;
                    float Vy = b2.Vy - b1.Vy;
                    float dotProduct = xDifferece * Vx + yDifferece * Vy;

                    if (dotProduct > 0)
                    {
                        float collisionScale = dotProduct / hypotenuse2;

                        float xCollision = (xDifferece * collisionScale);
                        float yCollision = (yDifferece * collisionScale);
                        float combinedMass = b1.Mass + b2.Mass;

                        float collisionWeightA = 2 * b2.Mass / combinedMass;
                        float collisionWeightB = 2 * b1.Mass / combinedMass;

                        b1.Vx += collisionWeightA * xCollision;
                        b1.Vy += collisionWeightA * yCollision;
                        b2.Vx -= collisionWeightB * xCollision;
                        b2.Vy -= collisionWeightB * yCollision;
                    }
                }
            }