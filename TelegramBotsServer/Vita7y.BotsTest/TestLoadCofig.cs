using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Vita7y.SqlBot;
using Xunit;

namespace Vita7y.BotsTest
{
    public class TestLoadCofig
    {
        [Fact]
        public void CanBindObjectTree()
        {
            var dict = new Dictionary<string, string>
            {
                {"SqlBot:ConnectString", "Data Source=localhost\\sqlexpress;Initial Catalog=FiluetLockers;Integrated Security=True;MultipleActiveResultSets=True"},
            };
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(dict);
            var config = builder.Build();

            var settings = new SqlBotSettings();
            config.GetSection("App").Bind(settings);

            Assert.Equal("Rick", settings.Profile.Machine);
            Assert.Equal(11, settings.Window.Height);
            Assert.Equal(11, settings.Window.Width);
            Assert.Equal("connectionstring", settings.Connection.Value);
        }
    }
}