using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ItemsBLL
    {
        public int AddItem(ItemsDTO itemDTO)
        {
            itemDTO.CreationDate = DateTime.Now;
            ItemsDAL itemDAL = new ItemsDAL();
            return itemDAL.AddItem(itemDTO);
        }

        public ItemsDTO checkItem(int itemId)
        {
            ItemsDTO itemDTO = new ItemsDTO();
            ItemsDAL itemDAL = new ItemsDAL();
            itemDTO = itemDAL.checkItem(itemId);
            return itemDTO;
        }

        public int updateItem(ItemsDTO itemDTO)
        {
            ItemsDAL itemDAL = new ItemsDAL();
            return itemDAL.updateItem(itemDTO);
        }

        public List<ItemsDTO> findItems(ItemsDTO itemDTO)
        {
            List<ItemsDTO> list = new List<ItemsDTO>();
            ItemsDAL itemDAL = new ItemsDAL();
            list = itemDAL.findItems(itemDTO);
            return list;
        }

        public int deleteItem(int itemId)
        {
            ItemsDAL itemsDAL = new ItemsDAL();
            return itemsDAL.deleteItem(itemId);
        }
    }
}
