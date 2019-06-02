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

        public static readonly RoutedUICommand EditMonument = new RoutedUICommand("Edit Monument", "EditMonument", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand EditTag = new RoutedUICommand("Edit Tag", "EditTag", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand EditType = new RoutedUICommand("Edit Type", "EditType", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand DeleteMonument = new RoutedUICommand("Delete Monument", "DeleteMonument", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand DeleteType = new RoutedUICommand("Delete Type", "DeleteType", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand DeleteTag = new RoutedUICommand("Delete Tag", "DeleteTag", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand ListTypes = new RoutedUICommand("List Types", "ListTypes", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Y, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand ListTags = new RoutedUICommand("List Tags", "ListTags", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand NextTab = new RoutedUICommand("Next Tab", "NextTab", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Tab, ModifierKeys.Control)
            }
            );
        
        public static readonly RoutedUICommand PreviousTab = new RoutedUICommand("Previous Tab", "PreviousTab", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Tab, (ModifierKeys.Control | ModifierKeys.Shift))
            }
            );

        public static readonly RoutedUICommand Tab1 = new RoutedUICommand("Tab1", "Tab1", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D1, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand Tab2 = new RoutedUICommand("Tab2", "Tab2", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D2, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand Tab3 = new RoutedUICommand("Tab3", "Tab3", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D3, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand Tab4 = new RoutedUICommand("Tab4", "Tab4", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D4, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand OpenCheatSheet = new RoutedUICommand("Shorcut cheatsheet", "ShorcutCheatSheet", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand OpenHelpDocumentation = new RoutedUICommand("Help documentation", "HelpDocumentation", typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F1)
            }
            );



    }
}
