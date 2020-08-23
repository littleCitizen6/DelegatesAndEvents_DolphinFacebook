using System;

namespace DolphinFacebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FacebookClientFactory();
            var displayer = new ConsoleDisplay();
            var dol1 = factory.CreateClient(displayer);
            var dol2 = factory.CreateClient(displayer);
            var dol3 = factory.CreateClient(displayer);
            dol1.WriteNewWallPost("shouldnt see that");
            dol2.Subscribe(dol1);
            dol3.Subscribe(dol1);
            dol1.WriteNewWallPost("should see twice");
            dol2.Unsubscribe(dol1);
            dol1.WriteNewWallPost("should see once");

        }
    }
}
