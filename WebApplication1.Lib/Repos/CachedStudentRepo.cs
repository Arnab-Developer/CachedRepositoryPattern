using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using WebApplication1.Lib.Data;
using WebApplication1.Lib.Models;

namespace WebApplication1.Lib.Repos
{
    public class CachedStudentRepo : StudentRepo
    {
        private readonly static object _cacheLockObject;
        private readonly IDistributedCache _cache;

        static CachedStudentRepo()
        {
            _cacheLockObject = new object();
        }

        public CachedStudentRepo(StudentContext studentContext, IDistributedCache cache)
            : base(studentContext)
        {
            _cache = cache;
        }

        public override IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student>? students
                = SerializationHelper.FromByteArray<IEnumerable<Student>>(_cache.Get("Students"));
            if (students == null)
            {
                lock (_cacheLockObject)
                {
                    students = SerializationHelper.FromByteArray<IEnumerable<Student>>(_cache.Get("Students"));
                    if (students == null)
                    {
                        students = base.GetAllStudents();

                        DistributedCacheEntryOptions options = new();
                        options.SetSlidingExpiration(TimeSpan.FromSeconds(60));
                        options.SetAbsoluteExpiration(TimeSpan.FromSeconds(300));

                        _cache.Set("Students", SerializationHelper.ToByteArray(students), options);
                    }
                }
            }
            return students;
        }
    }
}
