using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Modules;
using Discord.API;
using NadekoBot.Classes;
using NadekoBot.Modules.Permissions.Classes;
using Newtonsoft.Json.Linq;
using ChatterBotAPI;
namespace NadekoBot.Modules.CleverBot
{
    internal class CleverBotModule : DiscordModule
    {
        public override string Prefix { get; } = String.Format(NadekoBot.Config.CommandPrefixes.Conversations, NadekoBot.Creds.BotId);

        public override void Install(ModuleManager manager)
        {
            manager.CreateCommands(NadekoBot.BotMention, cgb =>
            {
                string message;
                ChatterBotFactory factory = new ChatterBotFactory();
                ChatterBot bot1 = factory.Create(ChatterBotType.CLEVERBOT);
                ChatterBotSession bot1session = bot1.CreateSession();


                cgb.CreateCommand("")
                    .Description("")
                    .Parameter("query", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        if (e.GetArg("query") == null || e.GetArg("query").Length < 1) return;

                        message = e.GetArg("query");
                        Console.WriteLine(message);

                        await e.Channel.SendMessage(bot1session.Think(message))
                                       .ConfigureAwait(false);
                    });
            });

        }
    



    }
}
