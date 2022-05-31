using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Data;
using WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate;

namespace WebsiteBuilder.Core.Repositories
{
    public class UnitOfWork
    {
        private readonly MyDBContext _context;

        public UnitOfWork(MyDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private GenericRepository<CreateUserTemplateModel> userRepository;
        public GenericRepository<CreateUserTemplateModel> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new GenericRepository<CreateUserTemplateModel>(_context);
                return userRepository;
            }
        }

        private GenericRepository<TemplateModel> templateRepository;
        public GenericRepository<TemplateModel> TemplateRepository
        {
            get
            {
                if (this.templateRepository == null)
                    this.templateRepository = new GenericRepository<TemplateModel>(_context);
                return templateRepository;
            }
        }
    }
}
