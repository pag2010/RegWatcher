using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Interfaces.IRepositories
{
    public interface ITagRepository
    {
        Task AddTag(Tag tag);
        Tag GetTag(int tagId);
        Tag GetTag(string tagName);
    }
}
