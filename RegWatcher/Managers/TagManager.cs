using RegWatcher.Data;
using RegWatcher.Interfaces.IManagers;
using RegWatcher.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Managers
{
    public class TagManager : ITagManager
    {
        private readonly ITagRepository _tagRepository;
        private readonly DataContext _context;

        public TagManager(DataContext context, ITagRepository tagRepository)
        {
            _context = context;
            _tagRepository = tagRepository;
        }

        public void AddTag(Tag tag)
        {
            if (_context.Tags.Any(t => t.Name.ToLower() == tag.Name.Trim().ToLower()))
                throw new Exception($"Тег {tag.Name} уже есть в базе");
            _tagRepository.AddTag(tag);
        }
    }
}
