using System;
using System.Text.RegularExpressions;

public static class Bob
{
    private static readonly StateEngine engine = new StateEngine(
        s => s.Trim().EndsWith('?'),
        s => s.ToUpper().Equals(s)
    );

    public static string Response(string statement)
    {
        switch (engine.Interpret(statement))
        {
            case States.Exclamation:
                return "Whoa, chill out!";
            case States.Question:
                return "Sure.";
            case States.Exclamation | States.Question:
                return "Calm down, I know what I'm doing!";
            case States.Silent:
                return "Fine. Be that way!";
            default:
                return "Whatever.";
        }
    }

    private unsafe static byte ToByte(this bool val)
        => *(byte*)&val;

    [Flags]
    internal enum States
    {
        Default = 0,
        Exclamation = 1,
        Question = 2,
        Silent = -1
    }

    internal class StateEngine
    {
        private readonly Predicate<string> questioning;
        private readonly Predicate<string> yelling;
        private readonly Predicate<string> silence = s => string.IsNullOrWhiteSpace(s);
        private readonly Predicate<string> intelligable = s => Regex.Match(s, "[A-z]").Success;

        public StateEngine(
            Predicate<string> QuestionPredicate,
            Predicate<string> YellingPredicate)
        {
            questioning = QuestionPredicate;
            yelling = YellingPredicate;
        }

        internal States Interpret(string statement)
            => silence(statement) ? States.Silent
                : (States)(questioning(statement).ToByte() << 1 | (intelligable(statement) & yelling(statement)).ToByte());
    }    
}