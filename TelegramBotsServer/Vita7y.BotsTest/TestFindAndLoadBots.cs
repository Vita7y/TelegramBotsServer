using System;
using System.Linq;
using Vita7y.Core;
using Vita7y.TelegramBotsServer;
using Xunit;

namespace Vita7y.BotsTest
{
    public class TestFindAndLoadBots
    {
        [Fact]
        public void TestFindBoot()
        {
            var bots = AssemblyBrowser.GeTypeses().Where(am => am.IsClass && am.GetInterfaces().Contains(typeof(IBotModule)));
            Assert.NotNull(bots);
            Assert.NotEmpty(bots);
            Assert.True(bots.Contains(typeof(SqlBot.SqlBot)));

        }
    }
}
