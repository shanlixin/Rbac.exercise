using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Repository
{
    public class MenuRepository : BaseRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(MyDbContext db)
        {
            DbContext = db;
        }

        public bool UpdMenu(Menu menu)
        {
            var list = GetByWhere(menu.MenuId);
            if (menu.ParentId == 0)
            {
                list.MenuId = menu.MenuId;
                list.MenuName = menu.MenuName;
                list.LinkUrl = menu.LinkUrl;
                list.DelState = menu.DelState;
                return DbContext.SaveChanges() > 0;
            }
            else
            {
                list.MenuId = menu.MenuId;
                list.ParentId = menu.ParentId;
                list.MenuName = menu.MenuName;
                list.LinkUrl = menu.LinkUrl;
                list.DelState = menu.DelState;
                return DbContext.SaveChanges() > 0;
            }
        }
    }
}
