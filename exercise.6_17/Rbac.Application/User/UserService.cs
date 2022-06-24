using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rbac.Repository;
using System.Security.Cryptography;

namespace Rbac.Application
{
    public class UserService: BaseService<User, UserDto>, IUserService
    {
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository,IMapper mapper) : base(userRepository,mapper)
        {
            UserRepository = userRepository;
            this.mapper = mapper;
        }

        public IUserRepository UserRepository { get; }

        public ResaultDto AddUserInfo(UserDto user)
        {
            if (UserRepository.GetByWhere(m => m.UserName == user.UserName) != null)
            {
                return new ResaultDto { Code = false, Msg = "该用户名已存在" };
            }
            else
            {
                user.LastLoginDate = null;
                user.CreateTime = DateTime.Now;
                user.Password = Md5(user.Password);
                UserRepository.Add(mapper.Map<User>(user));
                return new ResaultDto { Code = true, Msg = "用户添加成功" };
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }
    }
}
