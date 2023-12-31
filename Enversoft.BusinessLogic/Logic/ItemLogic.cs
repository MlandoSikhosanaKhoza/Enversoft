﻿
using Enversoft.Shared;
using Enversoft.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Enversoft.BusinessLogic
{
    public class ItemLogic:IItemLogic
    {
        private IItemRepository _itemRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ItemLogic(IItemRepository itemRepository,IWebHostEnvironment webHostEnvironment)
        {
            _itemRepository = itemRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Item> GetAllItems()
        {
            return _itemRepository.GetAllItems();
        }


        public Item AddItem(ItemInputModel ItemToAdd)
        {
            string path = StoreByteArrayFromBase64.Execute(ItemToAdd.Base64, $"{_webHostEnvironment.WebRootPath}/Images/", Path.GetExtension(ItemToAdd.ImageName));
            Item itemAdded = _itemRepository.AddItem(new Item { ImageName=Path.GetFileName(path), Description=ItemToAdd.Description, Price=ItemToAdd.Price,IsDeleted=false});
            return itemAdded;
        }

        public async Task<string> GetBase64ImageForImageName(string ImageName)
        {
            string path = System.IO.Path.Combine(_webHostEnvironment.WebRootPath,"Images", ImageName);
            byte[] bytes;
            string base64;
            if (!string.IsNullOrEmpty(ImageName))
            {
                if (System.IO.File.Exists(path))
                {
                    bytes = await System.IO.File.ReadAllBytesAsync(path);
                    base64 = Convert.ToBase64String(bytes);
                    return base64;
                }
            }
            return "";    
        }

        public Item GetItem(int ItemId)
        {
            return _itemRepository.GetItem(ItemId);
        }

        public bool UpdateItem(ItemInputModel ItemToUpdate)
        {
            Item item = GetItem(ItemToUpdate.ItemId);
            string path,imageName;
            
            item.Description= ItemToUpdate.Description;
            item.Price = ItemToUpdate.Price;
            
            if (!string.IsNullOrEmpty(ItemToUpdate.Base64))
            {
                DeleteExistingFile.Execute($"{_webHostEnvironment.WebRootPath}/Images/{item.ImageName}");
                path = StoreByteArrayFromBase64.Execute(ItemToUpdate.Base64, $"{_webHostEnvironment.WebRootPath}/Images/{item.ImageName}", Path.GetExtension(ItemToUpdate.Base64));
                imageName=Path.GetFileName(path);
                item.ImageName = imageName;
            }

            _itemRepository.UpdateItem(item);
            return true;
        }

        public bool DeleteItem(int ItemId)
        {
            return _itemRepository.DeleteItem(ItemId);
        }
    }
}
