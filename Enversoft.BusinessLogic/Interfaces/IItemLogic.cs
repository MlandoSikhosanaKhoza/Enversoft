﻿using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enversoft.BusinessLogic
{
    public interface IItemLogic
    {
        List<Item> GetAllItems();
        Item AddItem(ItemInputModel Item);
        Item GetItem(int ItemId);
        bool UpdateItem(ItemInputModel Item);
        bool DeleteItem(int ItemId);
        Task<string> GetBase64ImageForImageName(string ImageName);
    }
}
