/* CSC4700 P4 Hello World
 * To do list as of 04-18:
 * 
 * >> PHASE 1
 * >> [SOLVED] What is the callback with a ScatterItem being the sender? Answer: ScatterManipulation*
 * >> Flipping a piece, how to do with XAML? How to copy all the properties of one object to all spawned objects?
 * >> [SOLVED] How to get the bounding box of ScatterItem's ? Answer: Using ActualWidth, ActualHeight and ActualOrientation
 * >> How to assign an animtation to a ScatterViewItem and make the animation play through code ?
 * 
 * >> PHASE 1.5
 * >> How to use Quizlet's API?
 * 
 * >> PHASE 2.0
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for Application activation events
            AddActivationHandlers();

            List<string> l = DummyData.GetDemoData();
            int i = 0;
            foreach (string s in l)
            {
                ScatterViewItem svi = new ScatterViewItem();
                svi.Content = s;
                svi.Tag = i & 0xFFFFFFFE;
                P4Helper.Log("Tag of " + s + " = " + svi.Tag);
                if (i % 2 == 1) svi.Background = Brushes.Aqua;
                else svi.Background = Brushes.Beige;
                svi.MouseDown += new MouseButtonEventHandler(label_MouseDown);
                svi.ScatterManipulationCompleted += new ScatterManipulationCompletedEventHandler(svi_ScatterManipulationCompleted);
                MyScatterView.Items.Add(svi);
                i++;
            }
        }

        void svi_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            ScatterViewItem s = (ScatterViewItem)sender;
            int i = -1;
            foreach (ScatterViewItem svi in MyScatterView.Items)
            {
                i = i + 1;
                if (svi == s) continue;
                Boolean k = ScatterViewItemsIntersect(s, svi);
                if (k == true)
                {
                    if (svi.Tag.Equals(s.Tag))
                    {
                        s.Background = Brushes.LightGreen;
                        svi.Background = Brushes.LightGreen;
                        s.CanMove = false;
                        svi.CanMove = false;
                    }
                }
            }
        }

        void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScatterViewItem svi = (ScatterViewItem)sender;
            Console.WriteLine(svi.PointToScreen(new Point(0, 0)).ToString(), svi.ActualOrientation);
        }


        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for Application activation events
            RemoveActivationHandlers();
        }

        /// <summary>
        /// Adds handlers for Application activation events.
        /// </summary>
        private void AddActivationHandlers()
        {
            // Subscribe to surface application activation events
            ApplicationLauncher.ApplicationActivated += OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed += OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated += OnApplicationDeactivated;
        }

        /// <summary>
        /// Removes handlers for Application activation events.
        /// </summary>
        private void RemoveActivationHandlers()
        {
            // Unsubscribe from surface application activation events
            ApplicationLauncher.ApplicationActivated -= OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed -= OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated -= OnApplicationDeactivated;
        }

        /// <summary>
        /// This is called when application has been activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationActivated(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when application is in preview mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationPreviewed(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        ///  This is called when application has been deactivated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationDeactivated(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void SurfaceButtonAddExplicit_Click(object sender, RoutedEventArgs e)
        {
            ScatterViewItem item = new ScatterViewItem();
            item.Content = "Item 180 Orientation";
            item.Orientation = 180.0;
            MyScatterView.Items.Add(item);
        }

        private void SurfaceButtonAddImplicit_Click(object sender, RoutedEventArgs e)
        {
            Label L = new Label();
            // Set the content of the label.
            L.Content = "Item " + (MyScatterView.Items.Count + 1).ToString();
            // Add the label to the ScatterView control.
            // It is automatically wrapped in a ScatterViewItem control.
            L.DragEnter += new DragEventHandler(L_DragEnter);
            MyScatterView.Items.Add(L);
        }

        void L_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("L_DragEnger");
        }

        private void OnItemClicked(object sender, RoutedEventArgs e)
        {

        }

        private void MagicButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(">> Objects in the ScatterView:");
            int i, j;
            for (i = 0; i < MyScatterView.Items.Count; i++)
            {
                for (j = i + 1; j < MyScatterView.Items.Count; j++)
                {
                    ScatterViewItem svi1 = (ScatterViewItem)MyScatterView.Items.GetItemAt(i);
                    //                    Console.WriteLine(String.Format("#{0} \"{1}\" ({2})@{3}", i.ToString(),
                    //                        svi.Content.ToString(), svi.PointToScreen(new Point(0, 0)),
                    //                        svi.Orientation.ToString()));
                    ScatterViewItem svi2 = (ScatterViewItem)MyScatterView.Items.GetItemAt(j);
                    ScatterViewItemsIntersect(svi1, svi2);
                }

            }
        }

        private Boolean ScatterViewItemsIntersect(ScatterViewItem svi1, ScatterViewItem svi2)
        {
            Console.WriteLine("Testing {0} and {1}", svi1.Content.ToString(), svi2.Content.ToString());
            Boolean isOverlap = P4Helper.BoxBoxIntersection(svi1.PointToScreen(new Point(svi1.ActualWidth / 2, svi1.ActualHeight / 2)), svi1.ActualWidth, svi1.ActualHeight, svi1.ActualOrientation,
                                                            svi2.PointToScreen(new Point(svi2.ActualWidth / 2, svi2.ActualHeight / 2)), svi2.ActualWidth, svi2.ActualHeight, svi2.ActualOrientation);
            if (isOverlap == true)
            {
                Console.WriteLine(String.Format("{0} and {1} are intersecting.", svi1.Content.ToString(), svi2.Content.ToString()));
            }
            return isOverlap;
        }
    }
}