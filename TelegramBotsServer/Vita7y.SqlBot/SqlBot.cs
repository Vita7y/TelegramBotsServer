using System;
using System.Reflection;
using Vita7y.Core;

namespace Vita7y.SqlBot
{
    public class SqlBot: IBotModule
    {
        private SqlBotSettings _sqlBotSettings;
        public SqlBot()
        {
            _sqlBotSettings = CoreHelper.LoadSettings< SqlBotSettings>(Assembly.GetCallingAssembly().Location, "SqlBot");
        }

        public string Name => nameof(SqlBot);

        public Version Version => Assembly.GetCallingAssembly().GetName().Version;

        public void Dispose()
        {
        }
    }
}