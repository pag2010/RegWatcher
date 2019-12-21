using RegWatcher.Data;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
      
        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddTag(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public Tag GetTag(int tagId)
        {
            return _context.Tags.Where(t => t.TagId == tagId).SingleOrDefault();
        }

        public Tag GetTag(string tagName)
        {
            return _context.Tags.Where(t => t.Name == tagName).SingleOrDefault();
        }

    }
}
