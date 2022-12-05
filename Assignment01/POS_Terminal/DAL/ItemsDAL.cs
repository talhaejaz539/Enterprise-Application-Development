using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DTO;

namespace DAL
{
    public class ItemsDAL : BaseDAL
    {
        public int AddItem(ItemsDTO itemDTO)
        {
            return SaveItem(itemDTO);
        }

        public ItemsDTO checkItem(int itemID)
        {
            ItemsDTO itemDTO = new ItemsDTO();
            itemDTO = ItemCheck(itemID);

            return itemDTO;

        }

        public int updateItem(ItemsDTO itemDTO) {
            return ItemUpdate(itemDTO);
        }

        public List<ItemsDTO> findItems(ItemsDTO itemDTO)
        {
            List<ItemsDTO> list = new List<ItemsDTO>();
            list = itemsFind(itemDTO);
            return list;
        }

        public int deleteItem(int itemId)
        {
            return itemDelete(itemId);
        }
    }
}
