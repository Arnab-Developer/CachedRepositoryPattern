using ProtoBuf;

namespace WebApplication1.Lib.Models
{
    [ProtoContract]
    public class Student
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string FirstName { get; set; }

        [ProtoMember(3)]
        public string LastName { get; set; }

        public Student()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
