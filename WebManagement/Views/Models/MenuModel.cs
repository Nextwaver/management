using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManagement.Models
{

    public static class MenuConfigs
    {
        public static MenuList MenuConfig { get; set; }
    }
    public static class MenuManage
    {
        public static MenuList MenuConfig { get; set; }
    }
    public class MenuList
    {
        public List<Menu> _Menu = new List<Menu>();
        public List<Menu> Menu
        {
            get
            {
                return _Menu;
            }
            set
            {
                _Menu = value;
            }
        }
    }
    public class Menu
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Check { get; set; }
        public string Path { get; set; }
        public string Class { get; set; }
        public string IsSub { get; set; }
        public string Active { get; set; }

        public List<SubMenuList> _SubMenuList = new List<SubMenuList>();
        public List<SubMenuList> SubMenuList
        {
            get
            {
                return _SubMenuList;
            }
            set
            {
                _SubMenuList = value;
            }
        }
    }
    public class SubMenuList
    {
        public List<SubMenu> _SubMenu = new List<SubMenu>();
        public List<SubMenu> SubMenu
        {
            get
            {
                return _SubMenu;
            }
            set
            {
                _SubMenu = value;
            }
        }
    }
    public class SubMenu
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Class { get; set; }
        public string IsSub { get; set; }
        public string Check { get; set; }

        public List<SubMenuLast> _SubMenuLast = new List<SubMenuLast>();
        public List<SubMenuLast> SubMenuLast
        {
            get
            {
                return _SubMenuLast;
            }
            set
            {
                _SubMenuLast = value;
            }
        }
    }
    public class SubMenuLast
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ConfigName { get; set; }
        public string ManagementID { get; set; }
        public string ToolID { get; set; }
        public string SRD { get; set; }
        public string Active { get; set; }
        public string Check { get; set; }
    }
}
