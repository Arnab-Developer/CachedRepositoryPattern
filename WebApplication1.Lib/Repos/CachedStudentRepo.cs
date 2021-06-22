using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using WebApplication1.Lib.Abstractions;
using WebApplication1.Lib.Models;

namespace WebApplication1.Lib.Repos
{
    public class CachedStudentRepo : ICachedStudentRepo
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IDistributedCache _cache;

        public CachedStudentRepo(IStudentRepo studentRepo, IDistributedCache cache)
        {
            _studentRepo = studentRepo;
            _cache = cache;
        }

        IEnumerable<Student> ICachedStudentRepo.GetAllStudents()
        {
            byte[] resultFromCache = _cache.Get("Students");
            IEnumerable<Student> students;
            if (resultFromCache != null)
            {
                students = SerializationHelper.FromByteArray<IEnumerable<Student>>(resultFromCache);
            }
            else
            {
                students = _studentRepo.GetAllStudents();

                DistributedCacheEntryOptions options = new();
                options.SetSlidingExpiration(TimeSpan.FromSeconds(60));
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(300));

                _cache.Set("Students", SerializationHelper.ToByteArray(students), options);
            }
            return students;
        }
    }
}
