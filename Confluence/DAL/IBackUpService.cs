using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public interface IBackUpService
    {
        void BackUp();
        void Restore();
    }
}
