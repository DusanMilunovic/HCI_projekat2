using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace emlekmu.commands
{
    public static class RoutedCommands
    {
        public static readonly RoutedUICommand AddMonument = new RoutedUICommand("Add Monument", "AddMonument", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand AddType = new RoutedUICommand("Add Type", "AddType", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Y, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand AddTag = new RoutedUICommand("Add Tag", "AddTag", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }
            );
    }
}
