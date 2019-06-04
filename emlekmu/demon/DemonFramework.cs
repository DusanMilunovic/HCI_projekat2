using System;
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


 

        private void maximizeMainWindow(MainWindow window)
        {
            bool done = false;
            window.Dispatcher.Invoke(() =>
            {
                window.WindowState = WindowState.Maximized;
                done = true;
            });
            while (!done) { }
        }
        

        public static void MapDemon(MainContent main)
        {
           
            while (true)
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
                absolutePos.Y += 105;
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                MouseEvent(MouseEventFlags.LeftDown);
                Thread.Sleep(200);
                MouseEvent(MouseEventFlags.LeftUp);
                

            }
        }

        public static void SearchDemon(Button searchButton, TextBox idTextBox, Button finalizeButton)
        {
            while (true)
            {
                System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
                absolutePos = getElementPos(searchButton);
                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
                clickButton(searchButton);
                Thread.Sleep(1500);
                absolutePos = getElementPos(idTextBox);
                MoveCursorSlowly((int)absolutePos.X + 40, (int)absolutePos.Y);
                MouseEvent(MouseEventFlags.LeftDown);
                Thread.Sleep(100);
                MouseEvent(MouseEventFlags.LeftUp);
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
        }

        public static void AddMonumentFormDemon(AddMonument form)
        {
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(form.IdTextBox);
            MoveCursorSlowly((int)absolutePos.X + 20, (int)absolutePos.Y + 5);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBox(form.NameTextBox, "Demon monument");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBox(form.DescriptionTextBox, "Slightly demonic");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Windows.Forms.SendKeys.SendWait("{DELETE}");
            fillTextBox(form.IncomeTextBox, "666");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBoxPeasentMode(form.DateTextBox, "1205666");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Windows.Forms.SendKeys.SendWait("{DOWN}");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBox(form.ImageTextBox, @"C:\Users\Nenad\Desktop\test.png");
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{DOWN}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{DOWN}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{DOWN}");
            Thread.Sleep(150);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            absolutePos = getElementPos(form.ArcheologicalCheckBox);
            MoveCursorSlowly((int)absolutePos.X + 5, (int)absolutePos.Y + 5);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);

            absolutePos = getElementPos(form.PopulatedCheckBox);
            MoveCursorSlowly((int)absolutePos.X + 5, (int)absolutePos.Y + 5);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);

            absolutePos = getElementPos(form.TagListBox);
            MoveCursorSlowly((int)absolutePos.X + 40, (int)absolutePos.Y + 10);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            Thread.Sleep(100);
            MoveCursorSlowly((int)absolutePos.X + 40, (int)absolutePos.Y + 40);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);

            absolutePos = getElementPos(form.AddMonumentButton);
            MoveCursorSlowly((int)absolutePos.X + 30, (int)absolutePos.Y + 15);
            clickButton(form.AddMonumentButton);

            absolutePos = getElementPos(form.TypesComboBox);
            MoveCursorSlowly((int)absolutePos.X + 30, (int)absolutePos.Y + 10);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            Thread.Sleep(150);
            MoveCursorSlowly((int)absolutePos.X + 30, (int)absolutePos.Y + 40);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            Thread.Sleep(150);
            absolutePos = getElementPos(form.AddMonumentButton);
            MoveCursorSlowly((int)absolutePos.X + 30, (int)absolutePos.Y + 15);
            clickButton(form.AddMonumentButton);
        }

        
        public static void MonumentDemon(MainContent mainContent)
        {

            while (true)
            {
                System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
                absolutePos = getElementPos(mainContent.MonumentTable.AddMonumentButton);
                MoveCursorSlowly((int)absolutePos.X + 10, (int)absolutePos.Y + 5);

                //uvek koristi ovo da bi otvarao dijaloge, nemoj ni slucajno ono moje cudo clickButton
                MouseEvent(MouseEventFlags.LeftDown);
                MouseEvent(MouseEventFlags.LeftUp);

                //Thread sleep da bi dijalog stigao da se inicijalizuje
                Thread.Sleep(1000);
                AddMonumentFormDemon(mainContent.AddMonumentDemonDialog);

                //ova logika pronalazi monument koji treba da se edituje
                Thread.Sleep(1000);
                mainContent.MonumentTable.FindVisualChildren<MonumentRowDetail>(mainContent.MonumentTable.RootWoot);
                List<MonumentRowDetail> myList = new List<MonumentRowDetail>();
                bool done = false;
                MonumentRowDetail rowDetail = null;
                mainContent.MonumentTable.Dispatcher.Invoke(() =>
                {
                    foreach (MonumentRowDetail m in mainContent.MonumentTable.FindVisualChildren<MonumentRowDetail>(mainContent.MonumentTable.RootWoot))
                    {
                        if (m.Tag.Equals(mainContent.MonumentTable.EnlargenedMonuments.SingleOrDefault()))
                        {
                            rowDetail = m;
                            absolutePos = getElementPos(m.EditButton);
                            done = true;
                        }
                    }
                });
                while (!done) { }


                //nakon sto ga nadjemo kliknemo ga
                MoveCursorSlowly((int)absolutePos.X + 10, (int)absolutePos.Y + 5);
                MouseEvent(MouseEventFlags.LeftDown);
                MouseEvent(MouseEventFlags.LeftUp);



                //Thread sleep da bi dijalog stigao da se inicijalizuje
                Thread.Sleep(1000);
                EditMonumentFormDemon(mainContent.EditMonumentDemonDialog);



                Thread.Sleep(1000);

                rowDetail = null;
                done = false;

                mainContent.MonumentTable.Dispatcher.Invoke(() =>
                {
                    foreach (MonumentRowDetail m in mainContent.MonumentTable.FindVisualChildren<MonumentRowDetail>(mainContent.MonumentTable.RootWoot))
                    {
                        if (m.Tag.Equals(mainContent.MonumentTable.EnlargenedMonuments.SingleOrDefault()))
                        {
                            rowDetail = m;
                            done = true;
                        }
                    }
                });
                while (!done) { }



                //ovo bi radilo vrv ukoliko bi rowDetail bio dobar
                absolutePos = getElementPos(rowDetail.DeleteBtn);
                MoveCursorSlowly((int)absolutePos.X + 10, (int)absolutePos.Y + 5);
                MouseEvent(MouseEventFlags.LeftDown);
                MouseEvent(MouseEventFlags.LeftUp);
                Thread.Sleep(1000);
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            }
        }

        public static void EditMonumentFormDemon(EditMonument form)
        {
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(form.DescriptionTextBox);
            MoveCursorSlowly((int)absolutePos.X + 20, (int)absolutePos.Y + 5);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            slowlyDeleteTextBox(form.DescriptionTextBox);
            fillTextBox(form.DescriptionTextBox, "Slightly more demonic");
            absolutePos = getElementPos(form.IconTextBox);
            MoveCursorSlowly((int)absolutePos.X + 20, (int)absolutePos.Y + 5);
            MouseEvent(MouseEventFlags.LeftDown);
            MouseEvent(MouseEventFlags.LeftUp);
            slowlyDeleteTextBox(form.IconTextBox);
            absolutePos = getElementPos(form.EditMonumentButton);
            MoveCursorSlowly((int)absolutePos.X + 15, (int)absolutePos.Y + 5);
            clickButton(form.EditMonumentButton);

        }


        public static void TypeDemon(MainContent mainContent)
        {
            while (true)
            {
                System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
                absolutePos = getElementPos(mainContent.FileMenu);
                MoveCursorSlowly((int)absolutePos.X + 10, (int)absolutePos.Y + 5);

                MouseEvent(MouseEventFlags.LeftDown);
                Thread.Sleep(200);
                MouseEvent(MouseEventFlags.LeftUp);

                absolutePos.X += 20;
                absolutePos.Y += 30;

                MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);

                MouseEvent(MouseEventFlags.LeftDown);
                Thread.Sleep(200);
                MouseEvent(MouseEventFlags.LeftUp);

                Thread.Sleep(1000);

                MainWindow window = null;
                TypeSection typeSection = null;
                bool done = false;
                mainContent.Dispatcher.Invoke(() =>
                {
                    window = (MainWindow)Application.Current.MainWindow;
                    typeSection = window.TypeSectionDemonDialog;
                    done = true;
                });
                while (!done) { }


                TypeSectionDemon(typeSection);
           }

        }

        public static void TypeSectionDemon(TypeSection typeSection)
        {
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(typeSection.AddTypeButton);
            absolutePos.X += 30;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

            Thread.Sleep(1000);
            bool done = false;
            AddType addType = null;

            typeSection.Dispatcher.Invoke(() =>
            {
                addType = typeSection.AddTypeDemonDialog;
                done = true;
            });
            while (!done) { }

            AddTypeDemon(addType);


            Thread.Sleep(1000);


            //Finds the edit button
            TypeSection.FindVisualChildren<TypeRowDetail>(typeSection.RootWoot);
            List<TypeRowDetail> myList = new List<TypeRowDetail>();
            done = false;
            TypeRowDetail rowDetail = null;
            typeSection.Dispatcher.Invoke(() =>
            {
                foreach(TypeRowDetail m in TypeSection.FindVisualChildren<TypeRowDetail>(typeSection.RootWoot))
                {
                    if (m.Tag.Equals(typeSection.EnlargenedTypes.SingleOrDefault()))
                    {
                        rowDetail = m;
                        absolutePos = getElementPos(m.EditTagButton);
                        done = true;
                    }
                }
            });
            while (!done) { }
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

            Thread.Sleep(1000);

            EditTypeDemon(typeSection.EditTypeDemonDialog);


            //Finds the delete button
            myList = new List<TypeRowDetail>();
            done = false;
            rowDetail = null;
            typeSection.Dispatcher.Invoke(() =>
            {
                foreach(TypeRowDetail m in TypeSection.FindVisualChildren<TypeRowDetail>(typeSection.RootWoot))
                {
                    if (m.Tag.Equals(typeSection.EnlargenedTypes.SingleOrDefault()))
                    {
                        rowDetail = m;
                        absolutePos = getElementPos(m.DeleteTagButton);
                        done = true;
                    }
                }
            });
            while (!done) { }

            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

            Thread.Sleep(1000);

            System.Windows.Forms.SendKeys.SendWait("{ENTER}");

            absolutePos = getElementPos(typeSection.CloseButton);
            absolutePos.X += 30;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

        }

        public static void AddTypeDemon(AddType addType)
        {
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(addType.NameTextBox);
            absolutePos.X += 30;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);

            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

            fillTextBox(addType.NameTextBox, "Demonic type");

            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBox(addType.DescriptionTextBox, "A very demonic type of monuments");

            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            fillTextBox(addType.IconTextBox, @"C:\Users\Nenad\Desktop\test.png");

            absolutePos = getElementPos(addType.AddTypeButton);
            absolutePos.X += 10;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);

           

        }

        public static void EditTypeDemon(EditType form)
        {
            System.Windows.Point absolutePos = new System.Windows.Point(0, 0);
            absolutePos = getElementPos(form.DescriptionTextBox);
            absolutePos.X += 10;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);
            slowlyDeleteTextBox(form.DescriptionTextBox);
            fillTextBox(form.DescriptionTextBox, "Perhaps its angelic");
            absolutePos = getElementPos(form.EditTypeButton);
            absolutePos.X += 10;
            absolutePos.Y += 10;
            MoveCursorSlowly((int)absolutePos.X, (int)absolutePos.Y);
            MouseEvent(MouseEventFlags.LeftDown);
            Thread.Sleep(200);
            MouseEvent(MouseEventFlags.LeftUp);
        }





        private static void slowlyDeleteTextBox(TextBox textBox)
        {

            bool done = false;
            int len = 0;
            textBox.Dispatcher.Invoke(() =>
            {
                len = textBox.Text.Length;
                done = true;
            });

            while (!done) { }

            for (int i = 0; i < len; i++)
            {
                textBox.Dispatcher.Invoke(() =>
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                    
                });
                Thread.Sleep(150);
            }
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
            foreach (char c in text)
            {
                textBox.Dispatcher.Invoke(() =>
                {
                    textBox.Text += c;
                });
                Thread.Sleep(150);
            }
        }

        public static void fillTextBoxPeasentMode(TextBox textBox, string text)
        {
            foreach (char c in text)
            {
                System.Windows.Forms.SendKeys.SendWait("{" + c + "}");
                Thread.Sleep(150);
            }
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
