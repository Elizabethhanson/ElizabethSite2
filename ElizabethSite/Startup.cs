﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ElizabethLibrary.Startup))]

namespace ElizabethLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
