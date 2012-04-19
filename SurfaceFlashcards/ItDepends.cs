using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace HelloWorld
{
    class DummyData
    {
        public static List<string> GetDemoData()
        {
            List<string> l = new List<string>();
            l.Add("janvier"); l.Add("January");
            l.Add("fevrier"); l.Add("February");
            l.Add("mars"); l.Add("March");
            l.Add("教えて"); l.Add("おしえて");
            l.Add("心"); l.Add("こころ");
            l.Add("学ぶ"); l.Add("まなぶ");
            l.Add("lundi"); l.Add("Monday");
            l.Add("mardi"); l.Add("Tuesday");
            l.Add("mercredi"); l.Add("Wednesday");
            l.Add("jeudi"); l.Add("Thursday");
            l.Add("vendredi"); l.Add("Friday");
            l.Add("samedi"); l.Add("Saturday");
            l.Add("dimanche"); l.Add("Sunday");
            l.Add("janvier"); l.Add("January");
            l.Add("fevrier"); l.Add("February");
            l.Add("mars"); l.Add("March");
            l.Add("avril"); l.Add("April");
            l.Add("mai"); l.Add("May");
            l.Add("juin"); l.Add("June");
            l.Add("juillet"); l.Add("July");
            l.Add("aout"); l.Add("August");
            l.Add("septembre"); l.Add("September");
            l.Add("octobre"); l.Add("October");
            l.Add("novembre"); l.Add("November");
            l.Add("decembre"); l.Add("December");
            l.Add("tokens"); l.Add("objects that physically resemble the information they represent");
            l.Add("core tangible"); l.Add("physical interaction elements serving common roles across a varient of tangible UIs");
            return l;
        }
    }

    public class P4Helper
    {
        private static Boolean IsDebugOn = true;

        public static void Log(string format, params object[] args)
        {
            if (IsDebugOn == true)
                Console.WriteLine(format, args);
        }

        public static Boolean BoxBoxIntersection(Point c1, double w1, double h1, double theta1,
                                          Point c2, double w2, double h2, double theta2)
        {
            double k = 180 / Math.PI;
            theta1 = theta1 / k;
            theta2 = theta2 / k;
            // Axis separation method
            Vector axis_x1 = new Vector(Math.Cos(theta1), Math.Sin(theta1));
            Vector axis_y1 = new Vector(Math.Sin(theta1), -Math.Cos(theta1));
            Vector axis_x2 = new Vector(Math.Cos(theta2), Math.Sin(theta2));
            Vector axis_y2 = new Vector(Math.Sin(theta2), -Math.Cos(theta2));

            //            Console.WriteLine("Four axes: \n{0}\n{1}\n{2}\n{3}\n", axis_x1.ToString(), axis_y1.ToString(), axis_x2.ToString(), axis_y2.ToString());

            Vector c1c2 = c2 - c1;

            double prj_x1 = Math.Abs(c1c2 * axis_x1)
                - (Math.Abs(axis_y2 * h2 * axis_x1) + Math.Abs(axis_x2 * w2 * axis_x1)) * 0.5 - w1 * 0.5;

            double prj_y1 = Math.Abs(c1c2 * axis_y1)
                - (Math.Abs(axis_y2 * h2 * axis_y1) + Math.Abs(axis_x2 * w2 * axis_y1)) * 0.5 - h1 * 0.5;

            double prj_x2 = Math.Abs(c1c2 * axis_x2)
                - (Math.Abs(axis_y1 * h1 * axis_x2) + Math.Abs(axis_x1 * w1 * axis_x2)) * 0.5 - w2 * 0.5;

            double prj_y2 = Math.Abs(c1c2 * axis_y2)
                - (Math.Abs(axis_y1 * h1 * axis_y2) + Math.Abs(axis_x1 * w1 * axis_y2)) * 0.5 - h2 * 0.5;

            P4Helper.Log("Test result: " + prj_x1 + ", " + prj_y1 + ", " + prj_x2 + ", " + prj_y2);

            if (prj_x1 > 0) return false;
            if (prj_y1 > 0) return false;
            if (prj_x2 > 0) return false;
            if (prj_y2 > 0) return false;
            return true;
        }
    }
}
