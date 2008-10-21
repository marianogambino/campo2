using System;
using System.Collections.Generic;
using System.Text;
using Spring.Testing.NUnit;

namespace Confluence.Services.Tests
{
    public abstract class ServiceTest : AbstractDependencyInjectionSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new String[] {   "assembly://Web.Code/Web.Code.Config/StubData.xml",
                                        "assembly://Web.Code/Web.Code.Config/Services.xml"};
            }
        }
    }
}
