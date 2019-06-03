﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static emlekmu.MainWindow;



namespace emlekmu
{

    

    class DemonFramework
    {
        public static bool isAlive = false;

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }



        public static void AddTagDemon(MenuItem file, MenuItem tag)
        {
            
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(file);
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            file.Dispatcher.Invoke(() =>
            {
                file.IsSubmenuOpen = true;
            });
            absolutePos = getElementPos(file);
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            absolutePos = getElementPos(tag);
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(100);
            MouseEvent(MouseEventFlags.LeftUp);
            
            /*file.Dispatcher.Invoke(() =>
            {
                dialog.Show();
            });*/
        }

        public static void MapDemon(MainContent main)
        {
            while(true)
            {
                System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
                absolutePos = getElementPos(main.MonumentTable);
                MoveCursorSlowly((int)absolutePos.X + 100, (int)absolutePos.Y + 50);
                MouseEvent(MouseEventFlags.LeftDown);
                double width = 0;
                double height = 0;
                bool done = false;
                main.MapsContainer.Dispatcher.Invoke(() =>
                {
                    width = main.MapsContainer.ActualWidth;
                    height = main.MapsContainer.ActualHeight;
                    done = true;
                });
                while (!done) { }
                absolutePos = getElementPos(main.Map1.Kartocka);
                absolutePos.X = (int)absolutePos.X + Convert.ToInt32(width / 2);
                absolutePos.Y = (int)absolutePos.Y + Convert.ToInt32(height / 2);
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                MouseEvent(MouseEventFlags.LeftUp);

                Thread.Sleep(500);

                absolutePos.Y -= 10;
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                MouseEvent(MouseEventFlags.RightDown);
                Thread.Sleep(200);
                MouseEvent(MouseEventFlags.RightUp);

                absolutePos.X += 30;
                absolutePos.Y += 65;
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                MouseEvent(MouseEventFlags.LeftDown);
                Thread.Sleep(200);
                MouseEvent(MouseEventFlags.LeftUp);

            }


        }

        public static void SearchDemon(Button searchButton, TextBox idTextBox, Button finalizeButton)
        {
            /*
            while (true)
            {
                System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
                absolutePos = getElementPos(searchButton);
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                clickButton(searchButton);
                Thread.Sleep(1500);
                absolutePos = getElementPos(idTextBox);
                MoveCursorSlowly((int)absolutePos.X + 10, (int)absolutePos.Y);
                fillTextBox(idTextBox, "15");
                absolutePos = getElementPos(finalizeButton);
                MoveCursorSlowly((int)absolutePos.X + 15, (int)absolutePos.Y + 10);
                Thread.Sleep(500);
                clickButton(finalizeButton);
                Thread.Sleep(3000);
                resetTextBox(idTextBox);
                clickButton(finalizeButton);
                clickButton(searchButton);
            }
            */
            
        }

        public static void resetTextBox(TextBox textBox)
        {
            bool done = false;
            textBox.Dispatcher.Invoke(() =>
            {
                textBox.Text = "";
                done = true;
            });
            while (!done) { }
        }

        public static void fillTextBox(TextBox textBox, string text)
        {
            bool done = false;
            textBox.Dispatcher.Invoke(() =>
            {
                foreach (char c in text)
                {
                    textBox.Text += c;
                    Thread.Sleep(600);
                }
                done = true;
            });
            while (!done) { }
        }

        public static System.Windows.Point getElementPos(System.Windows.Media.Visual element)
        {
            System.Windows.Point retVal = new System.Windows.Point(0, 0);
            bool done = false;
            element.Dispatcher.Invoke(() =>
            {
                retVal = element.PointToScreen(new System.Windows.Point(0, 0));
                done = true;
            });
            while (!done) { }
            return retVal;
        }

        public static void clickButton(Button button)
        {
            bool done = false;
            button.Dispatcher.Invoke(() =>
            {
                button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                done = true;
            });
            while (!done) { }
        }

        public static void MoveCursorSlowly(int x, int y)
        {
            int oldX = System.Windows.Forms.Cursor.Position.X;
            int oldY = System.Windows.Forms.Cursor.Position.Y;

            while (oldX != x || y != oldY)
            {
                if (oldX != x)
                {
                    if (oldX > x)
                    {
                        oldX -= 1;
                    }
                    else
                    {
                        oldX += 1;
                    }
                    
                }
                if (oldY != y)
                {
                    if (oldY > y)
                    {
                        oldY -= 1;
                    }
                    else
                    {
                        oldY += 1;
                    }

                }
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(oldX, oldY);
                oldX = System.Windows.Forms.Cursor.Position.X;
                oldY = System.Windows.Forms.Cursor.Position.Y;
                Thread.Sleep(2);
            }
        }

 
    }
}