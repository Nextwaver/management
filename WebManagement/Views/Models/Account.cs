using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebManagement.Models
{
    public class Account
    {
        public enum NameType
        {
            ID,
            Titile,
            FirstName,
            LastName,
            Position,
            Username,
            Password
        }
        public string ID { get; set; }
        public string Titile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Password_cof { get; set; }
        public string SpaceUser { get; set; }

        public ErrorMessageModel _ErrorMessageModel = new ErrorMessageModel();
    }
    public class PositionList
    {
        public List<Position> Position = new List<Position>();

        public ErrorMessageModel _ErrorMessageModel = new ErrorMessageModel();
    }
    public class Position
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Check { get; set; }
    }

    public class PositionManage
    {
        public string ID { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string MenuActive { get; set; }

        public ErrorMessageModel _ErrorMessageModel = new ErrorMessageModel();
    }
}

