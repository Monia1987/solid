using System;
using System.Collections.Generic;
using System.Linq;

namespace TelegramBot.App.Services
{
    public class DummyMessagesService
    {
        private readonly List<string> _phrases = new List<string>
            {
                "May the force be with you.",
                "May the force be with you.",
                "May the force be with you.",
                "May the force be with you.",
                "May the force be with you.",
                "May the force be with you.",
                "Do. Or do not. There is no try.",
                "In my experience there is no such thing as luck.",
                "I find your lack of faith disturbing.",
                "I’ve got a bad feeling about this.",
                "It’s a trap!",
                "So this is how liberty dies…with thunderous applause.",
                "Your eyes can deceive you. Don’t trust them.",
                "Mind tricks don’t work on me.",
                "I’m one with the Force, and the Force will guide me.",
                "For my ally is the Force, and a powerful ally it is.",
                "Close your eyes. Feel it. The light…it’s always been there. It will guide you.",
                "Don’t underestimate the Force."
            };

        public string GetPhrase()
        {
            return _phrases.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}
