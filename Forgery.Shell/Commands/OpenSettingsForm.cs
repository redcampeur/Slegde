﻿using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;
using Forgery.Shell.Properties;

namespace Forgery.Shell.Commands
{
    /// <summary>
    /// Opens the settings window
    /// </summary>
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("Tools:Settings")]
    [MenuItem("Tools", "", "Settings", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Options))]
    public class OpenSettingsForm : ICommand
    {
        public string Name { get; set; } = "Settings";
        public string Details { get; set; } = "Open the settings form";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("SettingsForm"));
        }
    }
}
