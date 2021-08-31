using System;
using System.Text.RegularExpressions;

namespace Day06
{
    public enum Action
    {
        TurnOn,
        Toggle,
        TurnOff
    }

    public class Command
    {
        public Action Action { get; private set; }
        public Point From { get; private set; }
        public Point To { get; private set; }

        private Command() {}

        public Command(string cmd)
        {
            var turnOn = new Regex(@"(turn on|turn off|toggle) (\d*),(\d*) through (\d*),(\d*)");
            var onMatch = turnOn.Match(cmd);
            if (onMatch.Success)
            {
                switch (onMatch.Groups[1].Value)
                {
                    case "turn on":
                        this.Action = Action.TurnOn;
                        break;
                    case "turn off":
                        this.Action = Action.TurnOff;
                        break;
                    case "toggle":
                        this.Action = Action.Toggle;
                        break;
                }
                
                this.From = new Point()
                {
                    X = Int32.Parse(onMatch.Groups[2].Value),
                    Y = Int32.Parse(onMatch.Groups[3].Value)
                };
                this.To = new Point()
                {
                    X = Int32.Parse(onMatch.Groups[4].Value),
                    Y = Int32.Parse(onMatch.Groups[5].Value)
                };
            }
            else
            {
                throw new ApplicationException("Unsupported command: " + cmd);
            }
        }
    }

    public class Point
    {
        public int X;
        public int Y;
    }
}
