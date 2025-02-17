using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManagement.Models
{
    public static class _ManagementConfigs
    {
        public static ManagementConfig ManagementConfig { get; set; }
    }
    public class ManagementActive
    {
        public string TabName { get; set; }
        public Boolean isActive { get; set; }
    }
    public class ManagementListConfig
    {
        public List<ManagementConfig> _ManagementConfig = new List<ManagementConfig>();
        public List<ManagementConfig> ManagementConfig
        {
            get
            {
                return _ManagementConfig;
            }
            set
            {
                _ManagementConfig = value;
            }
        }
    }

    public class ManagementConfig
    {

        public List<ManagementActive> _ManagementActive = new List<ManagementActive>();
        public List<ManagementActive> ManagementActive
        {
            get
            {
                return _ManagementActive;
            }
            set
            {
                _ManagementActive = value;
            }
        }

        public List<Records> _Records = new List<Records>();
        public List<Records> Records
        {
            get
            {
                return _Records;
            }
            set
            {
                _Records = value;
            }
        }
        public List<Columns> _Columns = new List<Columns>();
        public List<Columns> Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                _Columns = value;
            }
        }
        public List<Tools> _Tools = new List<Tools>();
        public List<Tools> Tools
        {
            get
            {
                return _Tools;
            }
            set
            {
                _Tools = value;
            }
        }
        public List<Search> _Search = new List<Search>();
        public List<Search> Search
        {
            get
            {
                return _Search;
            }
            set
            {
                _Search = value;
            }
        }
        public List<Group> _Group = new List<Group>();
        public List<Group> Group
        {
            get
            {
                return _Group;
            }
            set
            {
                _Group = value;
            }
        }

        public string Title { get; set; }
        public string GroupText { get; set; }
        public string GroupValue { get; set; }
        public string PageDisplay { get; set; }
        public string nSearchCount { get; set; }
        public string ST1 { get; set; }
        public string ST2 { get; set; }
        public string ST3 { get; set; }
        public string ST4 { get; set; }
        public string NFN1 { get; set; }
        public string NFN2 { get; set; }
        public string NFN3 { get; set; }
        public string NFN4 { get; set; }
        public string NFN5 { get; set; }
        public string NFN6 { get; set; }
        public string NT1 { get; set; }
        public string NT2 { get; set; }
        public string NT3 { get; set; }
        public string NT4 { get; set; }
        public string NT5 { get; set; }
        public string NT6 { get; set; }
        public string NV1 { get; set; }
        public string NV2 { get; set; }
        public string NV3 { get; set; }
        public string NV4 { get; set; }
        public string NV5 { get; set; }
        public string NV6 { get; set; }
    }
    public class Records
    {
        public string RowID { get; set; }

        public List<Column> _Column = new List<Column>();
        public List<Column> Column
        {
            get
            {
                return _Column;
            }
            set
            {
                _Column = value;
            }
        }
    }
    public class Column
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Class { get; set; }
        public string ClassStatus { get; set; }
    }
    public class Columns
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Width { get; set; }
        public string Class { get; set; }
    }
    public class Tools
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Click { get; set; }
        public string ToolID { get; set; }
        public string ConfigName { get; set; }
        public string ToolTip { get; set; }
        public string Index { get; set; }
    }
    public class Search
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
    public class Group
    {
        public string Value { get; set; }
        public string Title { get; set; }
        public string Val { get; set; }
    }

    public static class _Searching
    {
        public static Searching Searching { get; set; }
    }
    public  class  Searching
    {
        public Boolean IsSearch { get; set; }
        public string CFN { get; set; }
        public string MID { get; set; }
        public string TID { get; set; }
        public string GRP_ID { get; set; }
        public string SC01 { get; set; }
        public string ST01 { get; set; }
        public string SC02 { get; set; }
        public string ST02 { get; set; }
        public string SC03 { get; set; }
        public string ST03 { get; set; }
        public string SC04 { get; set; }
        public string ST04 { get; set; }
        public string ST05 { get; set; }
        public string NSC01{ get; set; }
        public string NSC02{ get; set; }
        public string NSC03{ get; set; }
        public string NSC04{ get; set; }
        public string NSC05{ get; set; }
        public string NSC06 { get; set; }
        public string NST01{ get; set; }
        public string NST02{ get; set; }
        public string NST03{ get; set; }
        public string NST04{ get; set; }
        public string NST05{ get; set; }
        public string NST06 { get; set; }
        public string WHERE { get; set; }

        public NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
    }

}
