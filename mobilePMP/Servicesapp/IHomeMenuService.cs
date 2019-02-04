using System;
using System.Collections.Generic;
using mobilePMP.Modelsapp;

namespace mobilePMP.Servicesapp
{
    public interface IHomeMenuService
    {
        List<ShellMenuItem> GetMenuItems();
    }
}
