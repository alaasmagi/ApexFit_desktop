using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class CInterface
    {
        public SecurityLayer.ISecurity Security { get; private set; }
        public UserProfileComponent.IUserProfile UserProfile { get; private set; }
        public CoreComponent.ICore Core { get; private set; }

        public CInterface(SecurityLayer.ISecurity security, UserProfileComponent.IUserProfile userProfile, CoreComponent.ICore core)
        {
            Security = security;
            UserProfile = userProfile;
            Core = core;
        }
    }
}
